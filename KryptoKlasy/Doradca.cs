using System;

namespace KryptoKlasy
{
    public class Doradca
    {
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public string Email { get; private set; }
        public string Haslo { get; private set; }
        public DateTime DataUrodzenia { get; private set; }

        public Doradca(string imie, string nazwisko, string email, string haslo, DateTime dataUrodzenia)
        {

        }
    }
}
