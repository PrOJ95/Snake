using System.Windows.Forms;

namespace SnakeGame
{
    public partial class GameWindow : Form
    {

        //TODO: let enter restart game without requiring esc beforehand

        private List<Circle> Snake = new();
        private Circle Food = new();
        private List<Circle> Blocker = new();
        internal static bool blockersActive = false;
        internal static bool speedUpActive = false;
        public GameWindow()
        {
            InitializeComponent();
            new Settings();
            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;
        }
        private void UpdateScreen(object sender, EventArgs e)
        {
            if (!Settings.GameOver)
            {
                HandleInput();
                MovePlayer();
            }
            else if (Input.KeyPress(Keys.Enter))
            {
                StartGame();
            }
            pbCanvas.Invalidate();
        }
        private static void HandleInput()
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
        }
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
            if (e.KeyCode == Keys.Escape)
            {
                this.ActiveControl = null;
            }
        }
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }
        private void UpdateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (Settings.GameOver)
            {
                GameOver();
            }
            else
            {
                DrawSnake(canvas);
                DrawFood(canvas);
                DrawBlocker(canvas);
            }
        }
        private void DrawSnake(Graphics canvas)
        {
            Brush SnakeColour;
            for (int i = 0; i < Snake.Count; i++)
            {
                SnakeColour = i == 0 ? Brushes.Green : Brushes.DarkGreen;
                canvas.FillEllipse(SnakeColour, new Rectangle(Snake[i].xPosition * Settings.Width, Snake[i].yPosition * Settings.Height, Settings.Width, Settings.Height));
            }
        }
        private void DrawFood(Graphics canvas)
        {
            canvas.FillEllipse(Brushes.Red, new Rectangle(Food.xPosition * Settings.Width, Food.yPosition * Settings.Height, Settings.Width, Settings.Height));
        }
        private void DrawBlocker(Graphics canvas)
        {
            for (int i = 0; i < Blocker.Count; i++)
            {
                canvas.FillEllipse(Brushes.Gold, new Rectangle(Blocker[i].xPosition * Settings.Width, Blocker[i].yPosition * Settings.Height, Settings.Width, Settings.Height));
            }
        }
        private void GameOver()
        {
            string gameOver = $"Game Over\nYour final score is {Settings.Score}\nPress enter to restart";
            lblGameEndText.Text = gameOver;
            lblGameEndText.Visible = true;
        }
        private void StartGame()
        {
            lblGameEndText.Visible = false;
            new Settings();
            Blocker.Clear();
            Snake.Clear();
            Circle head = new(10, 5);
            Snake.Add(head);
            lblScoreNumber.Text = Settings.Score.ToString();
            UserSettingsButton.Enabled = false;
            GenerateNewFood();
        }
        private void MovePlayer()
        {
            for (int currentSegmentIndex = Snake.Count - 1; currentSegmentIndex >= 0; currentSegmentIndex--)
            {
                if (currentSegmentIndex == 0)
                {
                    MoveHead();
                }
                else
                {
                    MoveTail(currentSegmentIndex);
                }
            }
        }
        private void MoveHead()
        {
            switch (Settings.Direction)
            {
                case Directions.Left:
                    Snake[0].xPosition--;
                    break;
                case Directions.Right:
                    Snake[0].xPosition++;
                    break;
                case Directions.Up:
                    Snake[0].yPosition--;
                    break;
                case Directions.Down:
                    Snake[0].yPosition++;
                    break;
            }
            int maxXPosition = pbCanvas.Size.Width / Settings.Width;
            int maxYPosition = pbCanvas.Size.Height / Settings.Height;
            if (IsOutOfBounds(Snake[0].xPosition, Snake[0].yPosition, maxXPosition, maxYPosition))
            {
                Die();
            }
            CheckForCollision();
        }
        private void MoveTail(int currentSegmentIndex)
        {
            Snake[currentSegmentIndex].xPosition = Snake[currentSegmentIndex - 1].xPosition;
            Snake[currentSegmentIndex].yPosition = Snake[currentSegmentIndex - 1].yPosition;
        }
        private void CheckForCollision()
        {
            for (int otherSegmentIndex = 1; otherSegmentIndex < Snake.Count; otherSegmentIndex++)
            {
                if (Snake[0].xPosition == Snake[otherSegmentIndex].xPosition && Snake[0].yPosition == Snake[otherSegmentIndex].yPosition)
                {
                    Die();
                }
            }
            if (Snake[0].xPosition == Food.xPosition && Snake[0].yPosition == Food.yPosition)
            {
                EatFood();
            }
            foreach (Circle blocker in Blocker)
            {
                if (Snake[0].xPosition == blocker.xPosition && Snake[0].yPosition == blocker.yPosition)
                {
                    Die();
                }
            }
        }
        private static bool IsOutOfBounds(int x, int y, int maxX, int maxY)
        {
            return x < 0 || y < 0 || x >= maxX || y >= maxY;
        }
        private void GenerateNewFood()
        {
            int maxXposition = pbCanvas.Size.Width / Settings.Width;
            int maxYposition = pbCanvas.Size.Height / Settings.Height;
            Random foodPositionRandom = new();
            Food = new Circle(foodPositionRandom.Next(0, maxXposition), foodPositionRandom.Next(0, maxYposition));
            if (speedUpActive)
            {
                Settings.Speed++;
                gameTimer.Interval = 1000 / Settings.Speed;
            }
            Random blockerChanceToSpawn = new();
            if (blockerChanceToSpawn.Next(0, 19) <= 1 && blockersActive)
            {
                GenerateBlocker(maxXposition, maxYposition);
            }
        }
        private void EatFood()
        {
            Circle body = new(Snake[^1].xPosition, Snake[^1].yPosition);
            Snake.Add(body);
            Settings.Score += Settings.Points;
            lblScoreNumber.Text = Settings.Score.ToString();
            GenerateNewFood();
        }
        private void GenerateBlocker(int maxXposition, int maxYposition)
        {
            Random blockerPositionRandom = new();
            Circle blocker = new(blockerPositionRandom.Next(0, maxXposition), blockerPositionRandom.Next(0, maxYposition));
            Blocker.Add(blocker);
        }
        private void Die()
        {
            Settings.GameOver = true;
            UserSettingsButton.Enabled = true;
            this.ActiveControl = null;
        }

        private void ShowUserSettings(object sender, EventArgs e)
        {
            UserSettings UserSettings = new UserSettings();
            UserSettings.ShowDialog();
            this.ActiveControl = null;
        }

        private void OnClick_StartButton(object sender, EventArgs e)
        {
            gameTimer.Start();
            StartButton.Dispose();
            StartGame();
        }
    }
}