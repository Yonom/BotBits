using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    public static class PlayerIOAsync
    {
        public static Task RefreshAsync(this PayVault payVault)
        {
            var tcs = new TaskCompletionSource<AsyncVoid>();
            payVault.Refresh(() => tcs.SetResult(default(AsyncVoid)), tcs.SetException);
            return tcs.Task;
        }
        
        public static Task<DatabaseObject> LoadAsync(this BigDB bigDB, string table, string key)
        {
            var tcs = new TaskCompletionSource<DatabaseObject>();
            bigDB.Load(table, key, tcs.SetResult, tcs.SetException);
            return tcs.Task;
        }

        public static Task<DatabaseObject> LoadMyPlayerObjectAsync(this BigDB bigDB)
        {
            var tcs = new TaskCompletionSource<DatabaseObject>();
            bigDB.LoadMyPlayerObject(tcs.SetResult, tcs.SetException);
            return tcs.Task;
        }

        public static Task<Connection> JoinRoomAsync(this Multiplayer multiplayer, string roomId, Dictionary<string, string> joinData)
        {
            var tcs = new TaskCompletionSource<Connection>();
            multiplayer.JoinRoom(roomId, joinData, tcs.SetResult, tcs.SetException);
            return tcs.Task;
        }
        
        public static Task<Connection> CreateJoinRoomAsync(this Multiplayer multiplayer, string roomId, string roomType, bool visible, Dictionary<string, string> roomData, Dictionary<string, string> joinData)
        {
            var tcs = new TaskCompletionSource<Connection>();
            multiplayer.CreateJoinRoom(roomId, roomType, visible, roomData, joinData, tcs.SetResult, tcs.SetException);
            return tcs.Task;
        }
        
        public static Task<string> CreateRoomAsync(this Multiplayer multiplayer, string roomId, string roomType, bool visible, Dictionary<string, string> roomData)
        {
            var tcs = new TaskCompletionSource<string>();
            multiplayer.CreateRoom(roomId, roomType, visible, roomData, tcs.SetResult, tcs.SetException);
            return tcs.Task;
        }

        public static Task<RoomInfo[]> ListRoomsAsync(this Multiplayer multiplayer, string roomType, Dictionary<string, string> searchCriteria, int resultLimit, int resultOffset)
        {
            var tcs = new TaskCompletionSource<RoomInfo[]>();
            multiplayer.ListRooms(roomType, searchCriteria, resultLimit, resultOffset, tcs.SetResult, tcs.SetException);
            return tcs.Task;
        }
    }
}
