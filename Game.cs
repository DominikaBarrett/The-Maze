using static System.Console;
using System;


namespace The_Maze
{
    public class Game
    {
        private World MyWorld;
        private Player MyPlayer;

        public void Start()
        {
            Title = "Welcome to the Maze!!!";
            CursorVisible = false;

            // SetCursorPosition(4,2);
            // Write("x");

            // string[,] grid = {
            //     {"1","2","3" },
            //     {"4","5","6" },
            //     {"7","8","9" },
            // };

            string[,] grid =
            {
                {"█", "█", "█", "█", "█", "█", "█"},
                {"█", " ", " ", "█", " ", " ", "X"},
                {"O", " ", " ", "█ ", " ", " ", "█"},
                {"█", " ", " ", " ", " ", "█ ", "█"},
                {"█", " ", " ", " ", " ", "█", "█"},
                {"█", "█", "█", "█", "█", "█", "█"},
            };
            MyWorld = new World(grid);
            MyPlayer = new Player(0, 2);

            RunGameLoop();
        }

        private void DisplayIntro()
        {
            Write("Welcome to the maze!");
            Write("\nInstructions...");
            Write("\n>Use the arrow keys to move");
            Write("\n>Try to reach the goal,which looks like this:");
            ForegroundColor = ConsoleColor.Green;
            Write("X");
            ResetColor();
            Write(">\nPress any key to start");
            ReadKey(true);
        }

        private void DisplayOutro()
        {
            Clear();
            WriteLine("You escaped!");
            WriteLine("Thanks for playing");
            WriteLine("Press any key to exit");
            ReadKey(true);
        }

        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            MyPlayer.Draw();
        }

        private void HandelPlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(MyPlayer.X, MyPlayer.Y - 1))
                    {
                        MyPlayer.Y -= 1;
                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(MyPlayer.X, MyPlayer.Y + 1))
                    {
                        MyPlayer.Y += 1;
                    }

                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(MyPlayer.X - 1, MyPlayer.Y))
                    {
                        MyPlayer.X -= 1;
                    }

                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(MyPlayer.X + 1, MyPlayer.Y))
                    {
                        MyPlayer.X += 1;
                    }

                    break;
                default:
                    break;
            }
        }

        private void RunGameLoop()
        {
            DisplayIntro();
            while (true)
            {
                // draw everything 
                DrawFrame();

                // check for player input from the keyboard and move a player
                HandelPlayerInput();

                //check if teh player reached the exit and end the game if so
                string elementAtPlayerPos = MyWorld.GetElementAt(MyPlayer.X, MyPlayer.Y);
                if (elementAtPlayerPos == "X")
                {
                    break;
                }


                // give a chanec console a vjance to render
                System.Threading.Thread.Sleep(20);
            }

            DisplayOutro();
        }
    }
}