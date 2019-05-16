using System;
using System.Text;

namespace KryptoKlasy
{
    public partial class Transakcja
    {
        public Transakcja(Uzytkownik nadawca, Uzytkownik odbiorca, Portfel.Waluta waluta, float kwota)
        {
            Stan = StanyTransakcji.Nowa;
            TimeStamp = DateTime.Now;
            Nadawca = nadawca;
            Odbiorca = odbiorca;
            Waluta = waluta;
            Kwota = kwota;
            Stan = StanyTransakcji.Uzupelniona;
        }

        public DateTime TimeStamp { get; private set; }
        public Uzytkownik Nadawca { get; private set; }
        public Uzytkownik Odbiorca { get; private set; }
        public Portfel.Waluta Waluta { get; private set; }
        public float Kwota { get; private set; }
        public StanyTransakcji Stan { get; private set; }
    }
}
