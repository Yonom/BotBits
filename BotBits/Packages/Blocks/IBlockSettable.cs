namespace BotBits
{
    public interface IBlockSettable<in TForeground, in TBackground>
    {
        void Set(TForeground block);
        void Set(TBackground block);
    }
}