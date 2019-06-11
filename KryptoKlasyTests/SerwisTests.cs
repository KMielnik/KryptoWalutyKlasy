using System;
using KryptoKlasy;
using NUnit.Framework;

namespace KryptoKlasyTests
{
    [TestFixture]
    public class SerwisTests
    {
        Serwis serwis;

        [SetUp]
        public void ZaincjalizujSerwis()
        {
            serwis = new Serwis();
            serwis.ZarejestrujSie("Kamil", "Mielnik", "email@wp.pl", "haslo1", "739821739821", DateTime.Now.AddYears(-22).AddMonths(-3));
            serwis.ZarejestrujSie("Kamil", "Spiewak", "email2@wp.pl", "haslo2", "11111111111", DateTime.Now.AddYears(-20));
            serwis.ZarejestrujSie("Roman", "Broman", "email3@wp.pl", "haslo3", "cxnzkcjnxzkcjz", DateTime.Now.AddYears(-19));
        }

        [Test]
        public void Rejestracja_uzytkownika_nowy_powinien_sie_zalogowac()
        {
            string email = "testowy@wp.pl";
            string haslo = "tajneHaslo123";

            var result = serwis.ZarejestrujSie("Nowy", "Kolo", email, haslo, "abcdefg", DateTime.Now.AddYears(-27).AddDays(-13));

            Assert.IsTrue(result);

            var uzytkownik = serwis.ZalogujSie(email, haslo);

            Assert.IsNotNull(uzytkownik);
        }

        [Test]
        public void Rejestracja_uzytkownika_o_zbyt_krotkim_hasle()
        {
            string email = "testowy@wp.pl";
            string haslo = "tajneHaslo123";

            var result = serwis.ZarejestrujSie("Nowy", "Kolo", email, haslo, "abcdefg", DateTime.Now.AddYears(-27).AddDays(-13));

            Assert.IsTrue(result);

            var uzytkownik = serwis.ZalogujSie(email, haslo);

            Assert.IsNotNull(uzytkownik);
        }

        [Test]
        public void Proba_zalogowania_z_blednym_haslem()
        {
            var uzytkownik = serwis.ZalogujSie("email@wp.pl", "Bledne haslo");

            Assert.IsNull(uzytkownik);
        }

        [Test]
        public void Zmiana_hasla_i_proba_logowania()
        {
            string email = "email@wp.pl";
            string stareHaslo = "haslo1";

            var uzytkownik = serwis.ZalogujSie(email, stareHaslo);
            Assert.IsNotNull(uzytkownik);

            string noweHaslo = "NoweHaslo123";
            serwis.UstawNoweHaslo(uzytkownik, noweHaslo);

            uzytkownik = serwis.ZalogujSie(email, stareHaslo);
            Assert.IsNull(uzytkownik);

            uzytkownik = serwis.ZalogujSie(email, noweHaslo);
            Assert.IsNotNull(uzytkownik);
        }

        [Test]
        public void Opcja_przypomnij_haslo_znajduje_uzytkownika()
        {
            string email_niezarejestrowanego_uzytkownika = "jakisTamMAil@wp.pl";
            string email_zarejestrowanego_uzytkownika = "email3@wp.pl";

            Assert.IsFalse(serwis.PrzypomnijHaslo(email_niezarejestrowanego_uzytkownika));
            Assert.IsTrue(serwis.PrzypomnijHaslo(email_zarejestrowanego_uzytkownika));
        }

        [Test]
        public void Po_usunieciu_danych_uzytkownik_nie_moze_zalogowac()
        {
            string email = "email@wp.pl";
            string haslo = "haslo1";

            var uzytkownik = serwis.ZalogujSie(email, haslo);
            Assert.IsNotNull(uzytkownik);

            serwis.UsunDane(ref uzytkownik);

            uzytkownik = serwis.ZalogujSie(email, haslo);
            Assert.IsNull(uzytkownik);
        }

        [Test]
        public void Pobieranie_danych_uzytkownika_zawiera_jego_dane()
        {
            string email = "email@wp.pl";
            string haslo = "haslo1";

            var uzytkownik = serwis.ZalogujSie(email, haslo);
            Assert.IsNotNull(uzytkownik);

            var dane = serwis.PobierzKopieDanych(uzytkownik);

            Assert.IsTrue(dane.Contains(uzytkownik.Email));
        }

        [Test]
        public void Zmiana_koloru_tla_strony_jest_zachowana_po_przelogowaniu()
        {
            string email = "email@wp.pl";
            string haslo = "haslo1";

            var uzytkownik = serwis.ZalogujSie(email, haslo);
            Assert.IsNotNull(uzytkownik);

            var nowe_tlo = ConsoleColor.DarkMagenta;

            serwis.UstawKolorTlaStrony(uzytkownik, nowe_tlo);

            Assert.AreEqual(uzytkownik.TloStrony, nowe_tlo);

            serwis.WylogujSie(ref uzytkownik);
            Assert.IsNull(uzytkownik);

            uzytkownik = serwis.ZalogujSie(email, haslo);
            Assert.AreEqual(uzytkownik.TloStrony, nowe_tlo);
        }
    }
}
