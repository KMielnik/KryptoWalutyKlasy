using System;
using System.Collections.Generic;
using System.Linq;

namespace KryptoKlasy
{
    public class Serwis
    {
        public bool ZarejestrujSie(string imie, string nazwisko, string email, string haslo, string nrKonta, DateTime dataUrodzenia,bool firmowy=false,string adresFirmy="")
        {
            if (uzytkownicy.Where(x => x.Email == email).FirstOrDefault() != null)
                return false;
            if (haslo.Length < 5) return false;
            if(firmowy)
                uzytkownicy.Add(new UzytkownikFirmowy(imie, nazwisko, email, haslo, nrKonta, dataUrodzenia,adresFirmy));
            else
                uzytkownicy.Add(new Uzytkownik(imie, nazwisko, email, haslo, nrKonta, dataUrodzenia));
            return true;
        }
        public Uzytkownik ZalogujSie(string email, string haslo)
        {
            var uzytownik = uzytkownicy.Where(x => x.Email == email && x.Haslo == haslo).FirstOrDefault();
            if (uzytownik != null)
            {
                Console.BackgroundColor = uzytownik.TloStrony;
                Console.Clear();
            }
            return uzytownik;
        }
        public bool UstawNoweHaslo(Uzytkownik uzytkownik, string noweHaslo)
        {
            if (uzytkownik == null)
                return false;
            if (noweHaslo.Length < 5) return false;
            uzytkownik.Haslo = noweHaslo;
            return true;
        }
        public bool PrzypomnijHaslo(string email) => uzytkownicy.Where(x => x.Email == email).FirstOrDefault() != null;
        public bool OdblokujHaslo(Uzytkownik uzytkownik) => true;
        public Uzytkownik WylogujSie(Uzytkownik uzytkownik)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            return null;
        }
        public bool UsunDane(Uzytkownik uzytkownik) => uzytkownicy.Remove(uzytkownik);
        public bool AktualizujDaneFirmy(UzytkownikFirmowy uzytkownikFirmowy, string nowyAdres)
        {
            uzytkownikFirmowy.AdresFirmy = nowyAdres;
            return true;
        }
        public string PobierzKopieDanych(Uzytkownik uzytkownik) => $"Imie: {uzytkownik.Imie}\nNazwisko: {uzytkownik.Nazwisko}\nEmail: {uzytkownik.Email}\nHaslo: {uzytkownik.Haslo}";
        public bool UstawKolorTlaStrony(Uzytkownik uzytkownik, ConsoleColor consoleColor)
        {
            if (uzytkownik == null)
                return false;

            Console.WriteLine("UWAGA, TA OPERACJA WYCZYSCI EKRAN");
            Console.ReadKey(true);

            uzytkownik.TloStrony = consoleColor;
            Console.BackgroundColor = uzytkownik.TloStrony;
            Console.Clear();
            return true;
        }
        public bool ZmienNazwisko(Uzytkownik uzytkownik, string noweNazwisko)
        {
            if (uzytkownik == null)
                return false;
            uzytkownik.Nazwisko = noweNazwisko;
            return true;
        }

        private List<Uzytkownik> uzytkownicy;

        public Serwis()
        {
            uzytkownicy = new List<Uzytkownik>();
        }
    }
}
