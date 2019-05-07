using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

    public class ObslugaTransakcji
    {
        private List<Transakcja> historiaTransakcji;
        public bool DokonajTransakcji(Uzytkownik nadawca,Uzytkownik odbiorca,Portfel.Waluta waluta,float kwota) => true;
        public List<Transakcja> PobierzTransakcjeUzytkownika(Uzytkownik uzytkownik) =>
            historiaTransakcji.Where(x => x.Nadawca == uzytkownik || x.Odbiorca == uzytkownik)
                              .ToList();
        public List<Transakcja> PobierzTransakcjeZOkresu(DateTime start, DateTime koniec) => new List<Transakcja>();
    }
}
