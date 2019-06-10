using System;
using System.Collections.Generic;
using System.Linq;

namespace KryptoKlasy
{
    public class ObslugaTransakcji
    {
        private List<Transakcja> historiaTransakcji;
        public bool DokonajTransakcji(Uzytkownik nadawca, Uzytkownik odbiorca, Portfel.Waluta waluta, float kwota)
        {
            if (kwota <= 0) return false;
            var transakcja = new Transakcja(nadawca, odbiorca, waluta, kwota);
            switch(waluta)
            {
                case Portfel.Waluta.Bitcoin:
                    nadawca.PortfelBitcoin.Saldo -= kwota;
                    odbiorca.PortfelBitcoin.Saldo += kwota;
                break;
                case Portfel.Waluta.DogeCoin:
                    nadawca.PortfelDogecoin.Saldo -= kwota;
                    odbiorca.PortfelDogecoin.Saldo += kwota;
                break;
                case Portfel.Waluta.LiteCoin:
                    throw new Exception("Brak obslugi kont LiteCoin.");
            }
            historiaTransakcji.Add(transakcja);
            return true;
        }
        public List<Transakcja> PobierzTransakcjeUzytkownika(Uzytkownik uzytkownik) =>
            historiaTransakcji.Where(x => x.Nadawca == uzytkownik || x.Odbiorca == uzytkownik)
                              .ToList();
        public List<Transakcja> PobierzTransakcjeZOkresu(DateTime start, DateTime koniec)
            => historiaTransakcji
                .Where(x => x.TimeStamp > start)
                .Where(x => x.TimeStamp < koniec)
                .ToList();
        public float SprawdzSaldo(Uzytkownik uzytkownik, Portfel.Waluta waluta)
        {
            switch (waluta)
            {
                case Portfel.Waluta.Bitcoin:
                    return uzytkownik.PortfelBitcoin.Saldo;

                case Portfel.Waluta.LiteCoin:
                    throw new Exception("Brak obslugi kont LiteCoin.");

                case Portfel.Waluta.DogeCoin:
                    return uzytkownik.PortfelDogecoin.Saldo;

                case Portfel.Waluta.FIAT:
                    return uzytkownik.PortfelFIAT.Saldo;
            }
            throw new Exception("Bledna waluta");
        }
        public bool WplacFIATNaKonto(Uzytkownik uzytkownik, float kwota)
        {
            if (kwota <= 0) return false;
            uzytkownik.PortfelFIAT.Saldo += kwota;
            return true;
        }
        public bool WyplacFIATNaKonto(Uzytkownik uzytkownik, float kwota)
        {
            if (kwota <= 0) return false;
            uzytkownik.PortfelFIAT.Saldo -= kwota;
            return true;
        }
        public bool PrzelejKryptoNaSwojeKonto(Uzytkownik uzytkownik, string KluczPublicznyOdbiorcy, Portfel.Waluta waluta, float kwota)
        {
            if (kwota <= 0) return false;
            switch(waluta)
            {
                case Portfel.Waluta.Bitcoin:
                    uzytkownik.PortfelBitcoin.Saldo -= kwota;
                    break;
                case Portfel.Waluta.DogeCoin:
                    uzytkownik.PortfelDogecoin.Saldo -= kwota;
                    break;
                case Portfel.Waluta.LiteCoin:
                    throw new Exception("Brak obslugi kont LiteCoin.");
            }
            return true;
        }
    }
}
