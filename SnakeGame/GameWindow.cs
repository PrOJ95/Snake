namespace SnakeGame
{
    public partial class GameWindow : Form
    {
        private List<Circle> Snake = new();
        private Circle Food = new();
        public GameWindow()
        {
            InitializeComponent();
            new Settings();
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();
            StartGame();
        }
        private void UpdateScreen(object sender, EventArgs e)
        {
            if (Settings.GameOver == true)
            {
                if (Input.KeyPress(Keys.Enter))
                {
                    StartGame();
                }
                else
                {
                    if (Input.KeyPress(Keys.Right) && Settings.Direction != Directions.Left)
                    {
                        Settings.Direction = Directions.Right;
                    }
                    else if (Input.KeyPress(Keys.Left) && Settings.Direction != Directions.Right)
                    {
                        Settings.Direction = Directions.Left;
                    }
                    else if (Input.KeyPress(Keys.Up) && Settings.Direction != Directions.Down)
                    {
                        Settings.Direction = Directions.Up;
                    }
                    else if (Input.KeyPress(Keys.Down) && Settings.Direction != Directions.Up)
                    {
                        Settings.Direction = Directions.Down;
                    }
                    MovePlayer();
                }
            }
            pbCanvas.Invalidate();
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
        private void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (Settings.GameOver == false)
            {
                Brush SnakeColour;
                for (int i = 0; i < Snake.Count; i++)
                {
                    SnakeColour = i == 0 ? Brushes.Green : Brushes.DarkGreen;
                    canvas.FillEllipse(SnakeColour, new Rectangle(Snake[i].xPosition * Settings.Width, Snake[i].yPosition * Settings.Height, Settings.Width, Settings.Height));
                    canvas.FillEllipse(Brushes.Red, new Rectangle(Food.xPosition * Settings.Width, Food.yPosition * Settings.Height, Settings.Width, Settings.Height));
                }
            }
            else
            {
                string gameOver = $"Game Over\nFinal Score is{Settings.Score}\nPress enter to restart...";
                lblGameEndText.Text = gameOver;
                lblGameEndText.Visible = true;
            }
        }
        private void StartGame()
        {
            lblGameEndText.Visible = false;
            new Settings();
            Snake.Clear();
            Circle head = new(10, 5);
            Snake.Add(head);
            lblScoreNumber.Text = Settings.Score.ToString();
            GenerateNewFood();
        }
        private void MovePlayer()
        {
            for (int currentSegmentIndex = Snake.Count - 1; currentSegmentIndex >= 0; currentSegmentIndex--)
            {
                if (currentSegmentIndex == 0)
                {
                    switch (Settings.Direction)
                    {
                        case Directions.Left:
                            Snake[currentSegmentIndex].xPosition--;
                            break;
                        case Directions.Right:
                            Snake[currentSegmentIndex].xPosition++;
                            break;
                        case Directions.Up:
                            Snake[currentSegmentIndex].yPosition--;
                            break;
                        case Directions.Down:
                            Snake[currentSegmentIndex].yPosition++;
                            break;
                    }
                    int maxXPosition = pbCanvas.Size.Width / Settings.Width;
                    int maxYPosition = pbCanvas.Size.Height / Settings.Height;
                    if (IsOutOfBounds(Snake[currentSegmentIndex].xPosition, Snake[currentSegmentIndex].yPosition, maxXPosition, maxYPosition))
                    {
                        Die();
                    }
                    for (int otherSegmentIndex = 1; otherSegmentIndex < Snake.Count; otherSegmentIndex++)
                    {
                        if (Snake[currentSegmentIndex].xPosition == Snake[otherSegmentIndex].xPosition && Snake[currentSegmentIndex].yPosition == Snake[otherSegmentIndex].yPosition)
                        {
                            Die();
                        }
                    }
                    if (Snake[0].xPosition == Food.xPosition && Snake[0].yPosition == Food.yPosition)
                    {
                        EatFood();
                    }
                    else
                    {
                        Snake[currentSegmentIndex].xPosition = Snake[currentSegmentIndex - 1].xPosition;
                        Snake[currentSegmentIndex].yPosition = Snake[currentSegmentIndex - 1].yPosition;
                    }
                }
            }
        }
        private bool IsOutOfBounds(int x, int y, int maxX, int maxY)
        {
            return x < 0 || y < 0 || x > maxX || y > maxY;
        }
        private void GenerateNewFood()
        {
            int maxXposition = pbCanvas.Size.Width / Settings.Width;
            int maxYposition = pbCanvas.Size.Height / Settings.Height;
            Random foodPositionRandom = new Random();
            Food = new Circle(foodPositionRandom.Next(0, maxXposition), foodPositionRandom.Next(0, maxYposition));
        }
        private void EatFood()
        {
            Circle body = new(Snake[Snake.Count - 1].xPosition, Snake[Snake.Count - 1].yPosition);
            Snake.Add(body);
            Settings.Score += Settings.Points;
            lblScoreNumber.Text = Settings.Score.ToString();
            GenerateNewFood();
        }
        private void Die()
        {
            Settings.GameOver = true;
        }
    }
}