using System.Collections;

namespace SnakeGame
{
    internal class Input
    {
        private static readonly Hashtable keyTable = new();
        public static bool KeyPress(Keys key)
        {
            if (keyTable[key] == null)
            {
                return false;
            }
            return (bool)keyTable[key];
        }
        public static void ChangeState (Keys key, bool state)
        {
            keyTable[key] = state;
        }
    }
}