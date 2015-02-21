using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SolidaVolymer
{
    class Program
    {  
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.CursorVisible = true;
                ViewMenu();
                switch (Console.ReadLine()) 
                {
                    case "0": return;
                    case "1": ViewSolidDetail(CreateSolid(SolidType.CircularCone));
                        break;
                    case "2": ViewSolidDetail(CreateSolid(SolidType.Cylinder));
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\nInte ett giltigt menyval!");
                        Console.ResetColor();
                        break;
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Tryck valfri tangent för att börja om - ESC avslutar.");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        static Solid CreateSolid(SolidType solidType)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("╔═════════════════════════════════════╗");
            switch (solidType)
            {
                case SolidType.CircularCone:
                    Console.WriteLine("║                Kon                  ║");
                    break;
                case SolidType.Cylinder:
                    Console.WriteLine("║             Cylinder                ║");
                    break;
            }
            Console.WriteLine("╚═════════════════════════════════════╝");
            double radius = ReadDoubleGreaterThenZero("\nAnge radien (r): ");
            double height = ReadDoubleGreaterThenZero("\nAnge höjden (h): ");

            if (solidType == SolidType.Cylinder)
            {
                return new Cylinder(radius, height);
            }
            else
            {
                return new CircularCone(radius, height);
            }
        }

        static double ReadDoubleGreaterThenZero(string prompt)
        {
            double choice;
            do
            {
                Console.ResetColor();
                Console.Write(prompt);

                if (double.TryParse(Console.ReadLine(), out choice) && choice > 0)
                {
                    return choice;
                }
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nFEL! Måste vara ett värde större än 0.");
                Console.ResetColor();
            } while (true);
        }

        static void ViewMenu()
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine("║                                     ║");
            Console.WriteLine("║            Solida volymer           ║");
            Console.WriteLine("║                                     ║");
            Console.WriteLine("╚═════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("0. Avsluta\n");
            Console.WriteLine("1. Kon\n");
            Console.WriteLine("2. Cylinder");
            Console.WriteLine();
            Console.WriteLine("═══════════════════════════════════════");
            Console.Write("Ange ditt menyval [0-2]: ");
        }
     
        static void ViewSolidDetail(Solid solid)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine("║              Detaljer               ║");
            Console.WriteLine("╚═════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write(solid.ToString());
            Console.WriteLine("\n═══════════════════════════════════════");
        }
    }
}