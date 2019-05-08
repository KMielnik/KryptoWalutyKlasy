using System;
using System.Collections.Generic;
using System.Linq;

namespace KryptoKlasy
{
    public class ObslugaTransakcji
    {
        private List<Transakcja> historiaTransakcji;
        public bool DokonajTransakcji(Uzytkownik nadawca, Uzytkownik odbiorca, Portfel.Waluta waluta, float kwota) => true;
        public List<Transakcja> PobierzTransakcjeUzytkownika(Uzytkownik uzytkownik) =>
            historiaTransakcji.Where(x => x.Nadawca == uzytkownik || x.Odbiorca == uzytkownik)
                              .ToList();
        public List<Transakcja> PobierzTransakcjeZOkresu(DateTime start, DateTime koniec) => new List<Transakcja>();
        public float SprawdzSaldo(Uzytkownik uzytkownik, Portfel.Waluta waluta) => throw new NotImplementedException();
        public bool WplacFIATNaKonto(Uzytkownik uzytkownik, float kwota) => true;
        public bool WyplacFIATNaKonto(Uzytkownik uzytkownik, float kwota) => true;
        public bool PrzelejKryptoNaSwojeKonto(Uzytkownik uzytkownik, string KluczPublicznyOdbiorcy, Portfel.Waluta waluta, float kwota) => true;
    }
}
