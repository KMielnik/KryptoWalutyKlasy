using System;
using System.Collections.Generic;
using System.Text;

namespace KryptoKlasy
{
    static public class Czity
    {
        static DateTime date = DateTime.Today - TimeSpan.FromDays(30);

        public static DateTime GetPreviousDate()
        {
            date += TimeSpan.FromDays(1);
            return date;
        }

        public static void Loading(int time=300)
        {
            Console.Write("Loading");
            for(int i=0;i<5;i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(time);
            }
            Console.WriteLine();
        }
    }
}
