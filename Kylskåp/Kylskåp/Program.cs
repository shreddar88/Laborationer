using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylskåp
{
    class Program
    {
        private const string HorizontalLine = "═";

        static void Main(string[] args)
        {
            Console.Title = "Kylskåp A";
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine("║ Kylskåpet COOLER <TM>               ║");
            Console.WriteLine("║ Modellnr: SN14                      ║");
            Console.WriteLine("╚═════════════════════════════════════╝");
            Console.ResetColor();

            Cooler cooler = new Cooler();
            ViewTestHeader("\nTest 1.\nTest av standardkonstruktorn.\n");
            Console.WriteLine(cooler.ToString());
            
            Cooler cooler1 = new Cooler(24.5m, 4);
            ViewTestHeader("\nTest 2.\nTest av konstruktorn med 2 argument. (24,5 och 4)\n");
            Console.WriteLine(cooler1.ToString());
            
            Cooler cooler2 = new Cooler(19.5m, 4, true, false);
            ViewTestHeader("\nTest 3.\nTest av konstruktorn med 4 argument. (19,5, 4, True och False)\n");
            Console.WriteLine(cooler2.ToString());
         
            cooler = new Cooler(5.3m, 4, true, false);
            ViewTestHeader("\nTest 4.\nTest av metoden Tick()\n");
            Run(cooler, 10);
            
            cooler = new Cooler(5.3m, 4, false, false);
            ViewTestHeader("\nTest 5.\nTest av metoden Tick(), Avstängt med stängd dörr\n");
            Run(cooler, 10);
            
            cooler = new Cooler(10.2m, 4, true, true);
            ViewTestHeader("\nTest 6.\nTest av metoden Tick(), Påslaget med öppen dörr\n");
            Run(cooler, 10);
           
            cooler = new Cooler(19.7m, 4, false, true);
            ViewTestHeader("\nTest 7.\nTest av metoden Tick(), Avstängt med öppen dörr\n");
            Run(cooler, 10);
           
            cooler = new Cooler();
            ViewTestHeader("\nTest 8.\nTest av egenskaperna så att undantag kastas då innetemperaturen och måltemperaturen tilldelas felaktiga värden.\n");

            try
            {
                cooler.InsideTemperature = -1; 
            }
            catch (Exception)
            {
                ViewErrorMessage("Innetemperaturen är inte i intervallen 0-45°C");
            }
            try
            {
                cooler.InsideTemperature = 46;
            }
            catch (Exception)
            {
                ViewErrorMessage("Innetemperaturen är inte i intervallen 0-45°C");
            }
            try
            {
                cooler.TargetTemperature = -1;
            }
            catch (Exception)
            {
                ViewErrorMessage("Måltemperaturen är inte i intervallen 0-20°C");
            }
            try
            {
                cooler.TargetTemperature = 21;
            }
            catch (Exception)
            {
                ViewErrorMessage("Måltemperaturen är inte i intervallen 0-20°C");
            }
    
            ViewTestHeader("\nTest 9.\nTest av konstruktorerna så att undantag kastas då innetemperaturen och måltemperatur tilldelas felaktiga värden.\n");

            try
            {
                cooler = new Cooler(-1, 4); 
            }
            catch (Exception)
            {
                ViewErrorMessage("Innetemperaturen är inte i intervallen 0-45°C");
            }
            try
            {
                cooler = new Cooler(46, 4);
            }
            catch (Exception)
            {
                ViewErrorMessage("Innetemperaturen är inte i intervallen 0-45°C");
            }
            try
            {
                cooler = new Cooler(8, -1);
            }
            catch (Exception)
            {
                ViewErrorMessage("Måltemperaturen är inte i intervallen 0-20°C");
            }
            try
            {
                cooler = new Cooler(8, 21);
            }
            catch (Exception)
            {
                ViewErrorMessage("Måltemperaturen är inte i intervallen 0-20°C");
            }
          
            Console.WriteLine();
        }

        private static void Run(Cooler cooler, int minutes)
        {
         
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Utgångsvärdet.\n{0}\n", cooler.ToString());
            Console.ResetColor();

                for (int i = 0; i < minutes; i++)
                {
                    cooler.Tick();
                    Console.WriteLine(cooler.ToString());
                }
        }

        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private static void ViewTestHeader(string header)
        {
                for (int i = 0; i < 50; i++)
                {
                    Console.Write(HorizontalLine);
                }
            
            Console.WriteLine();
            Console.WriteLine(header);           
        }
    }
}
