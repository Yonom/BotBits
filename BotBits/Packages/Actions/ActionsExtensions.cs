namespace BotBits
{
    public static class ActionsExtensions
    {
        public static void GetCrown(this Actions actions)
        {
            actions.GetCrown(0, 0);
        }

        public static void CompleteLevel(this Actions actions)
        {
            actions.CompleteLevel(0, 0);
        }
        
        public static void PressKey(this Actions actions, Key key)
        {
            actions.PressKey(key, 0, 0);
        }

        public static void MoveToBlock(this Actions actions, int x, int y)
        {
            actions.Move(x * 16, y * 16);
        }

        public static void Move(this Actions actions, int x, int y)
        {
            actions.Move(x, y, 0, 0, 0, 0, 0, 0);
        }

        public static void Move(this Actions actions,
            int x, int y,
            double speedX, double speedY,
            double modifierX, double modifierY,
            double horizontal, double vertical)
        {
            actions.Move(x, y, speedX, speedY, modifierX, modifierY, horizontal, vertical, false, false);
        }

        public static void Move(this Actions actions,
            int x, int y,
            double speedX, double speedY,
            double modifierX, double modifierY,
            double horizontal, double vertical,
            bool spaceDown, bool spaceJustDown)
        {
            actions.Move(x, y, speedX, speedY, modifierX, modifierY, horizontal, vertical, spaceDown, spaceJustDown, 0);
        }
    }
}