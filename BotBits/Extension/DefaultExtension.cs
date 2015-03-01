namespace BotBits
{
    internal sealed class DefaultExtension : Extension<DefaultExtension>
    {
        public static void LoadInto(BotBitsClient client)
        {
            LoadInto(client, null);
        }
    }
}
