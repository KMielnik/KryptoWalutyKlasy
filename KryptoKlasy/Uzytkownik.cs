using System;
using System.Collections.Generic;
using System.Text;

namespace KryptoKlasy
{
    public class Uzytkownik
    {
        public bool UzytkownikPremium { get => KoniecPremium > DateTime.Now; }
        public DateTime KoniecPremium { get; set; }
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public string Email { get; private set; }
        public string Haslo { get; private set; }
        public DateTime DataUrodzenia { get; private set; }

        public Portfel PortfelBitcoin { get; private set; }
        public Portfel PortfelDogecoin { get; private set; }
        public Portfel PortfelFIAT { get; private set; }


        public Uzytkownik(string imie, string nazwisko, string email, string haslo, string nrKonta, DateTime dataUrodzenia)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Email = email;
            Haslo = haslo;
            DataUrodzenia = dataUrodzenia;
            PortfelBitcoin = new Portfel(Portfel.Waluta.Bitcoin);
            PortfelDogecoin = new Portfel(Portfel.Waluta.DogeCoin);
            PortfelFIAT = new Portfel(Portfel.Waluta.FIAT, nrKonta);
            KoniecPremium = DateTime.MinValue;
        }
    }
}
