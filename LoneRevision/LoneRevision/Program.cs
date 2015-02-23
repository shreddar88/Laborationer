using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoneRevision
{
    class Program
    {
        static void Main(string[] args)
        {
            int antalLoner = 0;

            do
            {
                antalLoner = ReadInt("Ange antal löner att mata in: ");

                if (antalLoner <= 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDu måste mata in minst två löner för att kunna göra en beräkning!");
                    Console.ResetColor();
                }

                else
                {
                    ProcessSalaries(antalLoner);
                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\nTryck ner valfri tangent för ny beräkning - ESC avslutar");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }


        static int ReadInt(string prompt)
        {
            string nummer = string.Empty;
            int tal = 0;

            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    nummer = Console.ReadLine();
                    tal = int.Parse(nummer);


                    if (tal <= 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("FEL! '{0}' kan inte tolkas som ett positivt heltal!", nummer);
                        Console.ResetColor();
                        
                    }
                    return tal;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! '{0}' kan inte tolkas som ett heltal!", nummer);
                    Console.ResetColor();
                }
            }
        }
            

        static void ProcessSalaries(int antalLoner)
        {
            int[] loner = new int[antalLoner];
            Console.WriteLine();

            for (int i = 0; i < antalLoner; i++) // Loopar antalet löner och sparar värden i en array
            {            
                    string prompt = string.Format("Ange lön nummer {0}: ", i + 1);            
                        loner[i] = ReadInt(prompt);
               
            }                


            int[] sortLoner = new int[antalLoner];

            Array.Copy(loner, sortLoner, antalLoner); // Kopierar nuvarande array till ny array och sorterar den
            Array.Sort(sortLoner);

            decimal medianLon = 0;
            double medelLon = sortLoner.Average();
            int loneSpridning = sortLoner.Max() - sortLoner.Min();

            if (sortLoner.Length % 2 == 1) // Räknar ut medianlön vid udda
            {
                medianLon = sortLoner[sortLoner.Length / 2];
            }

            else // Räknar ut medianlön vid jämna
            {
                int median1 = sortLoner[sortLoner.Length / 2];
                int median2 = sortLoner[sortLoner.Length / 2 - 1];
                medianLon = (median1 + median2) / 2.0m;
            }
            Console.WriteLine();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("\n{0}     : {1,9 :C0}", "Medianlön", medianLon);
            Console.WriteLine("{0}      : {1,9 :C0}", "Medellön", medelLon);
            Console.WriteLine("{0} : {1,9 :C0}\n", "Lönespridning", loneSpridning);
            Console.WriteLine("------------------------------------------");

            int raknare = 0;

            foreach (int loop in loner)//Loopar första arrayen och presenterar löner högerjusterade tre per rad i den ordning de matats in.
            {
                if (raknare % 3 == 0)
                {
                    Console.Write("\n{0,8}", loop);
                    raknare++;
                }
                else
                {
                    Console.Write("{0,8}", loop);
                    raknare++;
                }
            }
            Console.WriteLine();
        }
    }
}