using System;

namespace KryptoKlasy
{
    public class GieldaSnapshot
    {
        public readonly float wartoscBitcoin;
        public readonly float wartoscDogecoin;
        public readonly DateTime timeStamp;
    }

    public class Serwis
    {
        public bool ZarejestrujSie(string imie, string nazwisko, string email, string haslo, string nrKonta, DateTime dataUrodzenia) => true;
        public Uzytkownik ZalogujSie(string login, string haslo) => throw new NotImplementedException();
        public bool PrzypomnijHaslo(string email) => true;
        public bool WylogujSie(Uzytkownik uzytkownik) => true;
        public bool UsunDane(Uzytkownik uzytkownik) => true;
        public bool WykupPremiumMiesiac(Uzytkownik uzytkownik) => true;
    }
}
