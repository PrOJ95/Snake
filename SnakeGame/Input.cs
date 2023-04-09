using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Input
    {
        private static Hashtable keyTable = new();
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