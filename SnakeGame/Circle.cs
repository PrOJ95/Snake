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