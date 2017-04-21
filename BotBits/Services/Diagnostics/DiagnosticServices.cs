using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using BotBits.Events;
using BotBits.SendMessages;
using JetBrains.Annotations;

namespace BotBits
{
    public static class DiagnosticServices
    {
        private static readonly string _uninitializedFix = $" To fix this issue, wait for {nameof(JoinCompleteEvent)} before accessing the room.";
        private static readonly string _loaderIgnore = " You may disable this warning by adding [DiagnosticIgnore] to the offending EventListener.";

        [ThreadStatic]
        private static bool _disabled;
        
        public static bool Enabled => Debugger.IsAttached && !_disabled;

        public static void WithDiagnosticsDisabled([InstantHandle] Action task)
        {
            var oldvalue = _disabled;
            _disabled = true;
            task();
            _disabled = oldvalue;
        }

        internal static void Eventloader_LoadStatic<T>()
        {
            if (!Enabled) return;

            var nonstatics = Filter(EventLoader.GetMethods(typeof(T)));
            if (nonstatics.Length > 0)
                throw new DiagnosticException($"An EventListener in {typeof(T).Name} is missing the \"static\" attribute. To fix this issue, add \"static\" to the EventListener in question." + _loaderIgnore);
        }

        internal static void Eventloader_Load(Type type)
        {
            if (!Enabled) return;

            var statics = Filter(EventLoader.GetStaticMethods(type));
            if (statics.Length > 0)
                throw new DiagnosticException($"An EventListener in {type.Name} is has the \"static\" attribute. To fix this issue, remove \"static\" from the EventListener in question." + _loaderIgnore);
        }

        internal static void Eventloader_GetBinder(BotBitsClient client, Type type, MethodInfo callback)
        {
            if (!Enabled) return;

            var assembly = callback.DeclaringType?.Assembly;
            var extentionId = ExtensionServices.GetExtensionId(client, assembly);

            CheckBind(client, type, extentionId.HasValue, _loaderIgnore);
        }

        internal static void EventHandle_BindInternal<T>(BotBitsClient client, bool isExtension)
        {
            if (!Enabled) return;

            CheckBind(client, typeof(T), isExtension, String.Empty);
        }

        private static void CheckBind(BotBitsClient client, Type type, bool isExtension, string extraText)
        {
            var message = isExtension
                ? "This extention does not support being loaded after {1} has already been received because it relies on receiving {0}." + extraText
                : "Cannot listen to {0}, a {1} has already been received. To fix this issue, load your EventListeners before joining a room." + extraText;

            if (type == typeof(ConnectEvent))
                if (ConnectionManager.Of(client).Connection != null)
                    throw new DiagnosticException(String.Format(message, type.Name, nameof(ConnectEvent)));
            if (type == typeof(InitEvent))
                if (Room.Of(client).InitComplete)
                    throw new DiagnosticException(String.Format(message, type.Name, nameof(InitEvent)));
            if (type == typeof(JoinFailureEvent) ||
                type == typeof(JoinCompleteEvent))
                if (Room.Of(client).JoinComplete ||
                    !(ConnectionManager.Of(client).Connection?.Connected ?? true))
                    throw new DiagnosticException(String.Format(message, type.Name, nameof(JoinCompleteEvent) + " or " + nameof(JoinFailureEvent)));
        }

        private static MethodInfo[] Filter(IEnumerable<MethodInfo> methods)
        {
            return methods
                .Where(m => !m.IsDefined(typeof(DiagnosticIgnoreAttribute), true))
                .Where(m => m.IsDefined(typeof(EventListenerAttribute), true))
                .ToArray();
        }

        internal static void GetEnumerator<T>(BotBitsClient client)
        {
            if (!Enabled) return;

            if (!Room.Of(client).InitComplete)
                throw new DiagnosticException($"You are trying to access an uninitialized {typeof(T).Name}." + _uninitializedFix);
        }

        internal static void SendMessage_SendIn<T>(BotBitsClient client)
        {
            if (!Enabled) return;

            if (!Room.Of(client).InitComplete && typeof(T) != typeof(InitSendMessage))
                throw new DiagnosticException($"You are trying to send messages before {nameof(InitEvent)} is received." + _uninitializedFix);
        }

        internal static void Chat_QueueChat(BotBitsClient client)
        {
            if (!Enabled) return;

            if (!Room.Of(client).InitComplete)
                throw new DiagnosticException($"You are trying to send chats before {nameof(InitEvent)} is received." + _uninitializedFix);
        }
    }
}