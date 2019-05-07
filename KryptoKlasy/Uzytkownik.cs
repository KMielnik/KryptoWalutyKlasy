using System;
using System.Collections.Generic;
using System.Text;

namespace KryptoKlasy
{
    public class Uzytkownik
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public string Email { get; private set; }
        public string Haslo { get; private set; }
        public DateTime DataUrodzenia { get; private set; }

        public Portfel PortfelBitcoin { get; private set; }
        public Portfel PortfelDogecoin { get; private set; }
        public Portfel PortfelFIAT { get; private set; }


        Uzytkownik(string imie, string nazwisko, string email, string haslo, string nrKonta, DateTime dataUrodzenia)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            PortfelBitcoin = new Portfel(Portfel.Waluta.Bitcoin);
            PortfelDogecoin = new Portfel(Portfel.Waluta.DogeCoin);
            PortfelFIAT = new Portfel(Portfel.Waluta.FIAT);
        }
    }
}
