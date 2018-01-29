using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using GDIDrawer;


public struct Bubble
{
    public enum State { Alive, Dead };

    public Color color;
    public State state;
    public bool highlight;

    public Bubble(Color _color)
    {
        color = _color;
        state = State.Alive;
        highlight = false;
    }
}

namespace BubblePopper
{
    public enum Difficulty { Easy = 3, Medium, Hard };

    public partial class BubblePop : Form
    {
        // Constants for window dimension, bubble size, rows, columns
        private const int WIDTH = 800;
        private const int HEIGHT = 600;
        private const int BUBBLESIZE = 50;
        private const int ROWS = HEIGHT / BUBBLESIZE;
        private const int COLS = WIDTH / BUBBLESIZE;
        private const int OFFSET = 100;

        private enum State { Alive, Dead };

        private static Random _rand = new Random();

        private CDrawer _canvas;
        private Bubble[,] Bubbles = new Bubble[COLS, ROWS];
        private long _score;


        public BubblePop()
        {
            InitializeComponent();
        }

        /* ***************** METHODS ****************** */

        // Initialize a game grid to start a new game
        public void Randomize(Difficulty setting)
        {
            // Possible Colors for Bubbles
            Color[] BubbleColors = new Color[5]
            { Color.Red, Color.Blue, Color.Yellow, Color.Green, Color.LightGray };

            for (int x = 0; x < COLS; ++x)
                for (int y = 0; y < ROWS; ++y)
                    Bubbles[x, y] = new Bubble(BubbleColors[_rand.Next(0, (int)setting)]);
        }

        // Display the game in graphics window
        public void Display()
        {
            _canvas.Clear();
            _canvas.AddText("Score: ", 50, 0, 10, 220, 60, Color.White);
            _canvas.AddText(_score.ToString(), 50, 250, 10, 350, 60, Color.White);
            
            for (int x = 0; x < COLS; ++x)
                for (int y = 0; y < ROWS; ++y)
                {
                    if (Bubbles[x, y].highlight)
                        _canvas.AddEllipse(x * BUBBLESIZE, y * BUBBLESIZE + OFFSET, BUBBLESIZE, BUBBLESIZE,
                            Color.Pink);
                    else if (Bubbles[x, y].state == Bubble.State.Alive)
                    {
                        _canvas.AddEllipse(x * BUBBLESIZE, y * BUBBLESIZE + OFFSET, BUBBLESIZE, BUBBLESIZE,
                            Bubbles[x, y].color);
                    }
                }
        }

        // Main game processing function - picks the next mouse click
        private int Pick()
        {
            int bubblesPopped = 0;
            int score = 0;

            // Check if a new mouse click occur
            if (!_canvas.GetLastMouseLeftClick(out Point position))
                return 0;

            if (position.Y < OFFSET)
                return 0;

            int x = position.X / BUBBLESIZE;
            int y = (position.Y - OFFSET) / BUBBLESIZE;

            // Check to ensure at least one neighbouring cell of the same color is alive
            if (!MultipleSameColorBubble(x, y, Bubbles[x, y].color))
                return 0;

            bubblesPopped = CheckBubble(x, y, Bubbles[x, y].color);
            score = (int)Math.Pow(bubblesPopped, 2) * 50;

            StepDown();
            ShiftLeft();
            return score;
        }

        // Get mouse position and highlight potential matches 
        private void Highlight()
        {
            // Clear previous highlight
            for (int y = 0; y < ROWS; ++y)
                for (int x = 0; x < COLS; ++x)
                    Bubbles[x, y].highlight = false;

            _canvas.GetLastMousePosition(out Point position);

            int xPos = position.X / BUBBLESIZE;
            int yPos = (position.Y - OFFSET) / BUBBLESIZE;

            if (xPos < 0 || xPos > WIDTH || yPos < 0 || yPos > HEIGHT)
                return;

            if (!MultipleSameColorBubble(xPos, yPos, Bubbles[xPos, yPos].color))
                return;

            HighlightBubbles(xPos, yPos, Bubbles[xPos, yPos].color);
        }

        private void HighlightBubbles(int x, int y, Color colorIn)
        {
            // Conditional test to see if bubble is in bounds, alive, and the same color
            if (x < 0 || x >= COLS || y < 0 || y >= ROWS)
                return;

            if (Bubbles[x, y].state == Bubble.State.Dead)
                return;

            if (Bubbles[x, y].color != colorIn)
                return;

            if (Bubbles[x, y].highlight)
                return;

            Bubbles[x, y].highlight = true;

            // Recursive call to neighbouring cells
            HighlightBubbles(x - 1, y, colorIn);
            HighlightBubbles(x + 1, y, colorIn);
            HighlightBubbles(x, y - 1, colorIn);
            HighlightBubbles(x, y + 1, colorIn);

            return;
        }

        // Checks to see if a neighbouring live bubble is of the same color
        private bool MultipleSameColorBubble(int x, int y, Color colorIn)
        {
            if (x - 1 >= 0 && Bubbles[x - 1, y].color == colorIn  && Bubbles[x - 1, y].state == Bubble.State.Alive)
                return true;
            if (x + 1 < COLS && Bubbles[x + 1, y].color == colorIn && Bubbles[x + 1, y].state == Bubble.State.Alive)
                return true;
            if (y - 1 >= 0 && Bubbles[x, y - 1].color == colorIn && Bubbles[x, y - 1].state == Bubble.State.Alive)
                return true;
            if (y + 1 < ROWS && Bubbles[x, y + 1].color == colorIn && Bubbles[x, y + 1].state == Bubble.State.Alive)
                return true;

            return false;
        }

        // Recursive checking routine which clears currently selected bubble
        public int CheckBubble(int x, int y, Color colorIn)
        {
            // Conditional test to see if bubble is in bounds, alive, and the same color
            if (x < 0 || x >= COLS|| y < 0 || y >= ROWS)
                return 0;

            if (Bubbles[x, y].state == Bubble.State.Dead)
                return 0;

            if (Bubbles[x, y].color != colorIn)
                return 0;

            // Bubble is within bounds, alive, and the same color

            // Count how many bubbles have been killed;
            int bubbleCount = 0;

            // Kill the bubble, add to count
            Bubbles[x, y].state = Bubble.State.Dead;
            ++bubbleCount;

            // Recursive call to neighbouring cells
            bubbleCount +=
                  CheckBubble(x - 1, y, colorIn)
                + CheckBubble(x + 1, y, colorIn)
                + CheckBubble(x, y - 1, colorIn)
                + CheckBubble(x, y + 1, colorIn);

            return bubbleCount;
        }

        //Drop all bubbles in game grid by one level
        public void StepDown()
        {
            bool somethingDropped = false;

            for (int y = 1; y < ROWS; ++y)
                for (int x = 0; x < COLS; ++x)
                {
                    if (Bubbles[x, y].state == Bubble.State.Dead)
                        if (Bubbles[x, y - 1].state == Bubble.State.Alive)
                        {
                            Bubbles[x, y] = Bubbles[x, y - 1];
                            Bubbles[x, y - 1].state = Bubble.State.Dead;
                            somethingDropped = true;
                        }
                }

            // Recursively drop until all Bubbles have dropped to lowest point
            if (somethingDropped)
                StepDown();
        }

        // Shift all bubbles left in the game grid
        public void ShiftLeft()
        {
            // Check state of the bubble in lowest row of each column to check for a gap
            for (int x = 0; x < COLS - 1; ++x)
            {
                if (Bubbles[x, ROWS - 1].state == Bubble.State.Dead)
                {
                    // Empty field at the bottom, shift all bubbles from (col + 1) to current col
                    // And kill the bubbles in (col + 1)
                    for (int y = 0; y < ROWS; ++y)
                    {
                        Bubbles[x, y] = Bubbles[x + 1, y];
                        Bubbles[x + 1, y].state = Bubble.State.Dead;
                    }
                }
            }

            // Check if another shift is required to collapse bubbles
            bool shiftRequired = false;

            // Check if there are still gaps left and another shift required
            for (int x = 0; x < COLS - 1; ++x)
            {
                if (Bubbles[x, ROWS - 1].state == Bubble.State.Dead)
                {
                    // First Dead bubble found - check to see if any other bubble is alive in remaining columns
                    for (int xCheck = x + 1; xCheck < COLS - 1; ++xCheck)
                        if (Bubbles[xCheck, ROWS - 1].state == Bubble.State.Alive)
                            shiftRequired = true;
                }
            }
            
            // Recursive call until no empty gaps remain
            if (shiftRequired)
                ShiftLeft();
        }

        // Counts how many bubbles remain alive
        public int BubblesAlive()
        {
            int count = 0;

            for (int x = 0; x < COLS; ++x)
                for (int y = 0; y < ROWS; ++y)
                {
                    if (Bubbles[x, y].state == Bubble.State.Alive)
                        ++count;
                }

            return count;
        }

        // Checks if there all remaining live bubbles all singles
        private bool MoreMovesAvailable()
        {
            for (int y = 0; y < ROWS; ++y)
                for (int x = 0; x < COLS; ++x)
                {
                    if (Bubbles[x, y].state == Bubble.State.Alive && MultipleSameColorBubble(x, y, Bubbles[x, y].color))
                        return true;
                }

            return false;
        }

        private void UI_BTN_Play_Click(object sender, EventArgs e)
        {
            if (_canvas == null)
                _canvas = new CDrawer(800, 600 + OFFSET);

            _canvas.Clear();
            _score = 0;

            if (UI_RB_Easy.Checked)
                Randomize(Difficulty.Easy);
            else if (UI_RB_Medium.Checked)
                Randomize(Difficulty.Medium);
            else Randomize(Difficulty.Hard);

            Display();
            UI_Timer.Enabled = true;
            UI_BTN_Play.Enabled = false;
        }

        private void UI_Timer_Tick(object sender, EventArgs e)
        {
            if (BubblesAlive() == 0)
            {
                _score += 5000;
                Display();
                _canvas.AddText("You Win! Score: " + _score.ToString(), 50);
                UI_Timer.Enabled = false;
                UI_BTN_Play.Enabled = true;
            }
            else if (!MoreMovesAvailable())
            {
                _canvas.AddText("Game Over! Score: " + _score.ToString(), 25, Color.Cyan);
                UI_Timer.Enabled = false;
                UI_BTN_Play.Enabled = true;
            }
            else 
            {
                _score += Pick();
                Highlight();
                Display();
                UI_TB_Score.Text = _score.ToString();
            }
        }
    }
}
