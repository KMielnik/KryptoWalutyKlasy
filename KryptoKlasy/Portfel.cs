using System;
using System.Collections.Generic;
using System.Text;

namespace KryptoKlasy
{
    public partial class Portfel
    {
        public Waluta TypPortfela { get; private set; }
        public float Saldo { get ; private set ; }
        public string KluczPrywatny { get ; private set; }
        public string KluczPubliczny { get; private set; }

        public Portfel(Waluta typ)
        {
            TypPortfela = typ;
            Saldo = 0;
            KluczPrywatny = "Elo";
            KluczPubliczny = "444";
        }
    }
}
