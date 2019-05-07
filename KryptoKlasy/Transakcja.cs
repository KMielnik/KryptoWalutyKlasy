using System;
using System.Text;

namespace KryptoKlasy
{
    public class Transakcja
    {
        public DateTime TimeStamp { get; private set; }
        public Uzytkownik Nadawca { get; private set; }
        public Uzytkownik Odbiorca { get; private set; }
        public Portfel.Waluta Waluta { get; private set; }
        public float Kwota { get; private set; }
    }
}
