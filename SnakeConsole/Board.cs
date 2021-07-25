
namespace SnakeConsole
{
    using System;

    public class Board
    {
        private int height;
        private int width;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public Board()
        {
            height = 10;
            width = 10;
        }
        public Board(int heigth, int width)
        {
            this.height = height;
            this.width = width;
        }
        public void Write()
        {
            for (int i = 1; i <= width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("-");
            }

            for (int i = 1; i <= width; i++)
            {
                Console.SetCursorPosition(i, height + 1);
                Console.Write("-");
            }

            for (int i = 1; i <= height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
            }

            for (int i = 1; i <= height; i++)
            {
                Console.SetCursorPosition((width + 1), i);
                Console.Write("|");
            }
       
        }
    }
}
