
namespace SnakeConsole
{
    using System;
    using System.Threading;

    public class Snake
    {
        int height;
        int width;

        int[] X;
        int[] Y;

        int fruitX;
        int fruitY;

        int parts;
        int score = 0;
       
        bool lost;

        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;

        Random rnd = new Random();

        public Snake()
        {

        }

        void WritePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y); 
            Console.Write("#");
        }

        void DrawFruit(int x, int y)
        {
            fruitX = rnd.Next(1,width);
            fruitY = rnd.Next(1,height);

            for (int i = parts; i >= 1; i--)
            {
                if (X[i-1] == fruitX && Y[i-1] == fruitY)
                {
                    DrawFruit(width,height);
                }
            }
        }
        void WriteSnake()
        {
            for (int i = 0; i <= (parts-1); i++)
            {
                WritePoint(X[i], Y[i]);
            }
            if (X[parts] != 0)
            {
                Console.SetCursorPosition(X[parts],Y[parts]);
                Console.Write("\0");
            }
        }
        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
        }
        void Shift()
        {
            for (int i = parts + 1; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
        }
        // 
        void Setup()
        {
            height = 26;
            width = 26;

            X = new int[50];
            Y = new int[50];

            X[0] = 10;
            Y[0] = 10;
            X[1] = 10;
            Y[1] = 11;
            X[2] = 10;
            Y[2] = 12;

            fruitX = 10;
            fruitY = 3;

            parts = 3;
          
            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();

            Console.CursorVisible = false;
        }
        public bool Logic()
        {
            if (X[0] == fruitX)
            {
                if (Y[0] == fruitY)
                {
                    parts++; // удлиняем змейку
                    DrawFruit(width,height);
                    score++; // считаем съеденные фрукты
                }
            }
            // Отслеживаем нажатие клавиш 
            switch (consoleKey)
            {
                case ConsoleKey.W:
                    if ((Y[0] - Y[1]) == 1)
                    {
                        consoleKey = ConsoleKey.S;
                    }
                    break;
                case ConsoleKey.S:
                    if ((Y[0] - Y[1]) == -1)
                    {
                        consoleKey = ConsoleKey.W;
                    }
                    break;
                case ConsoleKey.A:
                    if ((X[0] - X[1]) == 1)
                    {
                        consoleKey = ConsoleKey.D;
                    }
                    break;
                case ConsoleKey.D:
                    if ((X[0] - X[1]) == -1)
                    {
                        consoleKey = ConsoleKey.A;
                    }
                    break;
                default:
                    break;
            }
            switch (consoleKey)
            {
                case ConsoleKey.W:
                    Shift();
                    Y[0]--;
                    break;
                case ConsoleKey.S:
                    Shift();
                    Y[0]++;
                    break;
                case ConsoleKey.A:
                    Shift();
                    X[0]--;
                    break;
                case ConsoleKey.D:
                    Shift();
                    X[0]++;
                    break;
                default:
                    break;
            }
            // Проверка границ
            if (X[0] <= 0 || X[0] > 36 || Y[0] <= 0 || Y[0] > 27)
            {
                lost = true;
            }
            for (int i = parts; i >= 2; i--)
            {
                if (X[0] == X[i - 1] && Y[0] == Y[i - 1])
                {
                    lost = true;
                }
            }
            if (!lost)
            {
                WriteSnake();
                WritePoint(fruitX, fruitY);
                Thread.Sleep(200);
                return false;
            }
            else
            {
                return true;
            }
           
        }

        public void Run()
        {
            while (true)
            {
                lost = false;
                Setup();
                Board board = new Board();
                board.Width = 36;
                board.Height = 26;
                board.Write();
                while (true)
                {
                    Input();
                    if (Logic())
                    {
                        break;// столкнулись со стеной ,вышли
                    }
                   
                }
                Console.Clear();
                Console.WriteLine($"You lose! You score {score}");
                Thread.Sleep(3000);
                Console.Clear();
                score = 0;
            }
           
        }
        
    }

}
