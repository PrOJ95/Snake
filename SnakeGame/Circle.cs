using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Circle
    {
        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public Circle()
        {
            xPosition = 0;
            yPosition = 0;
        }
        public Circle (int x, int y)
        {
            xPosition = x;
            yPosition = y;
        }
    }
}