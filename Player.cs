using static System.Console;
using System;


namespace The_Maze
{
    public class Player
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMaker;
        private ConsoleColor PlayerColor;
        
        public Player(int initialX,int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMaker = "O";
            PlayerColor = ConsoleColor.Red;

        }

        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(X,Y);
            Write(PlayerMaker);
            ResetColor();
            
        }
    }
}