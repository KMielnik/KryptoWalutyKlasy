using System;

namespace KryptoKlasy
{
    public class Serwis
    {
        public bool ZarejestrujSie(string imie, string nazwisko, string email, string haslo, string nrKonta, DateTime dataUrodzenia) => true;
        public Uzytkownik ZalogujSie(string email, string haslo) => throw new NotImplementedException();
        public bool UstawNoweHaslo(Uzytkownik uzytkownik, string noweHaslo) => true;
        public bool PrzypomnijHaslo(string email) => true;
        public bool OdblokujHaslo(Uzytkownik uzytkownik) => true;
        public bool WylogujSie(Uzytkownik uzytkownik) => true;
        public bool UsunDane(Uzytkownik uzytkownik) => true;
        public bool AktualizujDaneFirmy(UzytkownikFirmowy uzytkownikFirmowy, string nowyAdres) => true;
        public string PobierzKopieDanych(Uzytkownik uzytkownik) => uzytkownik.Email + " i reszta danych";
        public bool UstawKolorTlaStrony(Uzytkownik uzytkownik, byte R, byte G, byte B) => true;
        public bool ZmienNazwisko(Uzytkownik uzytkownik, string noweNazwisko) => true;
    }
}
