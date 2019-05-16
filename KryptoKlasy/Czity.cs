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
    }
}
