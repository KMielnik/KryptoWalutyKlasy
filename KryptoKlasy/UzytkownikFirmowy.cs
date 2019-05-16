using System;

namespace KryptoKlasy
{
    public class UzytkownikFirmowy : Uzytkownik
    {
        public string AdresFirmy { get; private set; }

        public UzytkownikFirmowy(string imie, string nazwisko, string email, string haslo, string nrKonta, DateTime dataUrodzenia, string adresFirmy) 
            : base( imie,  nazwisko,  email,  haslo,  nrKonta,  dataUrodzenia)
        {
            AdresFirmy = adresFirmy;
        }
    }
}
