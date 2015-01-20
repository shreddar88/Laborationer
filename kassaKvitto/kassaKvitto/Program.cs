using System;

namespace kassaKvitto
{
    class Program
    {
        private const int femhundra = 500;
        private const int etthundra = 100;
        private const int femtio = 50;
        private const int tjugo = 20;
        private const int tio = 10;
        private const int fem = 5;
        private const int en = 1;

        static void Main(string[] args)
        {
            double totalSumma = 0;
            int erhalletBelopp = 0;
            int tillbaka = 0;
            int summa = 0;
            double avrund = 0;

            while (true)
                try
                {
                    Console.Write("Ange totalsumma     : ");
                    totalSumma = double.Parse(Console.ReadLine());

                    if (totalSumma <= 0.5)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Totalsumman är för liten. Köpet kunde itne genomföras!");
                        Console.ResetColor();
                        return;
                    }
                    break;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("FEL! Erhållet belopp felaktigt.");
                    Console.ResetColor();
                }

            while (true)
                try
                {
                    Console.Write("Ange erhållet belopp: ");
                    erhalletBelopp = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nFEL! Erhållet belopp felaktig.\n\n");
                    Console.ResetColor();
                }

            if (erhalletBelopp < totalSumma)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("FEL! Erhållet belopp är för litet. Köpet kunde inte genomföras. ");
                Console.ResetColor();
                return;
            }

            summa = (int)Math.Round(totalSumma);
            avrund = summa - totalSumma;
            tillbaka = erhalletBelopp - summa;

            Console.WriteLine("\n KVITTO");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Totalt          :{0, 13 :c}", totalSumma);
            Console.WriteLine("Öresavrundning  :{0, 13 :c}", avrund);
            Console.WriteLine("Att betala      :{0, 13 :c}", summa);
            Console.WriteLine("Kontant         :{0, 13 :c}", erhalletBelopp);
            Console.WriteLine("Tillbaka        :{0, 13 :c}", tillbaka);
            Console.WriteLine("------------------------------------------\n");

            int vaxel = 0;
            int femhundralapp = 0;
            int etthundralapp = 0;
            int femtiolapp = 0;
            int tjugolapp = 0;
            int tia = 0;
            int femkrona = 0;
            int enkrona = 0;

            vaxel = tillbaka;
            femhundralapp = vaxel / femhundra;
            vaxel = vaxel % femhundra;
            etthundralapp = vaxel / etthundra;
            vaxel = vaxel % etthundra;
            femtiolapp = vaxel / femtio;
            vaxel = vaxel % femtio;
            tjugolapp = vaxel / tjugo;
            vaxel = vaxel % tjugo;
            tia = vaxel / tio;
            vaxel = vaxel % tio;
            femkrona = vaxel / fem;
            vaxel = vaxel % fem;
            enkrona = vaxel / en;
            vaxel = vaxel % en;

            if (femhundralapp != 0)
            {
                Console.WriteLine("500-lappar      :{0,7}", femhundralapp);
            }
            if (etthundralapp != 0)
            {
                Console.WriteLine("100-lappar      :{0,7}", etthundralapp);
            }
            if (femtiolapp != 0)
            {
                Console.WriteLine("50-lappar       :{0,7}", femtiolapp);
            }
            if (tjugolapp != 0)
            {
                Console.WriteLine("20-lappar       :{0,7}", tjugolapp);
            }
            if (tia != 0)
            {
                Console.WriteLine("10-kronor       :{0,7}", tia);
            }
            if (femkrona != 0)
            {
                Console.WriteLine("5-kronor        :{0,7}", femkrona);
            }
            if (enkrona != 0)
            {
                Console.WriteLine("1-kronor        :{0,7}", enkrona);
            }
        }
    }
}




