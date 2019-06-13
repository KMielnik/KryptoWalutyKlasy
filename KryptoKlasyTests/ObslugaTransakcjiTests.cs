using System;
using NUnit.Framework;
using KryptoKlasy;
using System.Linq;

namespace KryptoKlasyTests
{
    [TestFixture]
    public class ObslugaTransakcjiTests
    {
        ObslugaTransakcji obslugaTransakcji;
        Serwis serwis;
        float oryginalneSaldo = 122.37f;

        [SetUp]
        public void ZainicjalizujObslugeTransakcji()
        {
            obslugaTransakcji = new ObslugaTransakcji();

            serwis = new Serwis();
            serwis.ZarejestrujSie("Kamil", "Mielnik", "email@wp.pl", "haslo1", "739821739821", DateTime.Now.AddYears(-22).AddMonths(-3));
            serwis.ZarejestrujSie("Kamil", "Spiewak", "email2@wp.pl", "haslo2", "11111111111", DateTime.Now.AddYears(-20));
            serwis.ZarejestrujSie("Roman", "Broman", "email3@wp.pl", "haslo3", "cxnzkcjnxzkcjz", DateTime.Now.AddYears(-19));

            var uzytkownik = serwis.ZalogujSie("email@wp.pl", "haslo1");
            uzytkownik.PortfelFIAT.Saldo = oryginalneSaldo;
            uzytkownik.PortfelBitcoin.Saldo = oryginalneSaldo;
            uzytkownik.PortfelDogecoin.Saldo = oryginalneSaldo;
        }

        [Test]
        public void Sprawdzone_saldo_jest_rowne_oryginalnemu()
        {
            var uzytkownik = serwis.ZalogujSie("email@wp.pl", "haslo1");
            Assert.AreEqual(oryginalneSaldo, obslugaTransakcji.SprawdzSaldo(uzytkownik, Portfel.Waluta.FIAT));
        }

        [Test]
        public void Uzytkownik_wplaca_wyplaca_fiat()
        {
            var uzytkownik = serwis.ZalogujSie("email@wp.pl", "haslo1");
            float kwota_wplaty = 6373.0f;
            float kwota_wyplaty = 121.19f;

            obslugaTransakcji.WplacFIATNaKonto(uzytkownik, kwota_wplaty);
            Assert.AreEqual(oryginalneSaldo + kwota_wplaty, obslugaTransakcji.SprawdzSaldo(uzytkownik, Portfel.Waluta.FIAT));

            obslugaTransakcji.WyplacFIATNaKonto(uzytkownik, kwota_wyplaty);
            Assert.AreEqual(oryginalneSaldo + kwota_wplaty - kwota_wyplaty, obslugaTransakcji.SprawdzSaldo(uzytkownik, Portfel.Waluta.FIAT));
        }

        [Test]
        public void Wykonaj_transakcje_uzytkownik_jest_odbiorca_lub_nadawca()
        {
            var uzytkownik1 = serwis.ZalogujSie("email@wp.pl", "haslo1");
            var uzytkownik2 = serwis.ZalogujSie("email2@wp.pl", "haslo2");

            //uzytkownik 1 bierze udzial
            var erlo = obslugaTransakcji.DokonajTransakcji(uzytkownik1, uzytkownik2,Portfel.Waluta.DogeCoin,23.0f);
            erlo=obslugaTransakcji.DokonajTransakcji(uzytkownik1, uzytkownik2,Portfel.Waluta.FIAT,11.0f);
            erlo=obslugaTransakcji.DokonajTransakcji(uzytkownik2, uzytkownik1,Portfel.Waluta.DogeCoin,17.13f);

            //uzytkownik 1 nie bierze udzialu
            obslugaTransakcji.DokonajTransakcji(uzytkownik2, uzytkownik2, Portfel.Waluta.Bitcoin,3.0f);

            var transakcjeUzytkownika = obslugaTransakcji.PobierzTransakcjeUzytkownika(uzytkownik1);

            Assert.AreEqual(3, transakcjeUzytkownika.Count);
        }
    }
}
