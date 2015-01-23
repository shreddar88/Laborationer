using System;

namespace Asterisker
{
    class Program
    {

        static void Main(string[] args)
        {
            for (int rad = 0; rad < 25; rad++)
            {
                int farg = rad % 3;
                switch (farg)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }

                if (rad % 2 == 1)
                {
                    Console.Write(" ");
                }

                for (int kolumn = 0; kolumn < 39; kolumn++)
                {
                    Console.Write("* ");
                }

                Console.WriteLine();
                Console.ResetColor();

            }
        }
    }
}


