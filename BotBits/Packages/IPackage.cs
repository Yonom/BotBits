namespace BotBits
{
    internal interface IPackage
    {
        void Setup(BotBitsClient client);
        void SignalInitializeFinish();
    }
}