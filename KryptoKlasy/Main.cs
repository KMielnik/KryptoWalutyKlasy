using System;
using System.Collections.Generic;
using System.Text;

namespace KryptoKlasy
{
    public static class KryptoKlasy
    {
        public static void Main()
        {
            Gielda gielda = new Gielda();
            for(int i=0;i<10;i++)
                gielda.WygenerujIZapiszSnapshot();

            foreach (var snapshot in gielda.PobierzHistorie())
                Console.WriteLine(snapshot);

            Console.ReadKey();
        }
    }
}
