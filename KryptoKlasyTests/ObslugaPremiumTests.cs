using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using KryptoKlasy;
using System.Linq;

namespace KryptoKlasyTests
{
    [TestFixture]
    public class ObslugaPremiumTests
    {
        ObslugaPremium obslugaPremium;
        Serwis serwis;
        [SetUp]
        public void Zaincjalizuj_obslugePremium()
        {
            obslugaPremium = new ObslugaPremium();
            ZaincjalizujSerwis();
        }

        private void ZaincjalizujSerwis()
        {
            serwis = new Serwis();
            serwis.ZarejestrujSie("Kamil", "Mielnik", "email@wp.pl", "haslo1", "739821739821", DateTime.Now.AddYears(-22).AddMonths(-3));
            serwis.ZarejestrujSie("Kamil", "Spiewak", "email2@wp.pl", "haslo2", "11111111111", DateTime.Now.AddYears(-20));
            serwis.ZarejestrujSie("Roman", "Broman", "email3@wp.pl", "haslo3", "cxnzkcjnxzkcjz", DateTime.Now.AddYears(-19));
        }

        [Test]
        public void Uzytkownik_wykupuje_premium_na_miesiac()
        {
            var uzytkownik = serwis.ZalogujSie("email@wp.pl", "haslo1");
            Assert.IsNotNull(uzytkownik);

            Assert.IsFalse(uzytkownik.UzytkownikPremium);
            obslugaPremium.WykupPremiumNaMiesiac(uzytkownik);
            Assert.IsTrue(uzytkownik.UzytkownikPremium);
        }

        [Test]
        public void Lista_pobranych_doradcow_nie_pusta()
        {
            var lista_doradcow = obslugaPremium.PobierzDostepnychDoradcow();
            Assert.IsNotNull(lista_doradcow);
            Assert.Greater(lista_doradcow.Count, 0);
        }

        [Test]
        public void Wykupiony_doradca_w_liscie_wykupionych_uzytkownika()
        {
            var uzytkownik = serwis.ZalogujSie("email@wp.pl", "haslo1");
            Assert.IsNotNull(uzytkownik);

            var lista_doradcow = obslugaPremium.PobierzDostepnychDoradcow();
            Assert.Greater(lista_doradcow.Count, 0);

            obslugaPremium.WykupPomocDoradcy(uzytkownik, lista_doradcow[0]);

            var wykupieni_doradcy_danego_uzytkownika = obslugaPremium.WykupieniDoradcyDanegoUzytkownika(uzytkownik);
            Assert.Contains(lista_doradcow[0], wykupieni_doradcy_danego_uzytkownika);
        }

        [Test]
        public void Wyslij_wiadomosc_i_pobierz_historie_rozmow_zwraca_chat_z_wiadomoscia()
        {
            var uzytkownik = serwis.ZalogujSie("email@wp.pl", "haslo1");
            Assert.IsNotNull(uzytkownik);

            var lista_doradcow = obslugaPremium.PobierzDostepnychDoradcow();

            string naszaWiadomosc = "Hej, potrzebuje pomocy w staniu sie niesamowicie bogatym";
            obslugaPremium.WyslijWiadomoscDoDoradcy(uzytkownik, lista_doradcow[0], naszaWiadomosc);

            var chat = obslugaPremium.PobierzHistorieRozmow(uzytkownik, lista_doradcow[0]);

            Assert.Contains(naszaWiadomosc, chat.HistoriaRozmow);
        }

        [Test]
        public void Dodaj_post_na_forum_post_zostanie_umieszczony()
        {
            var uzytkownik = serwis.ZalogujSie("email@wp.pl", "haslo1");
            Assert.IsNotNull(uzytkownik);

            string naszaWiadomosc = "Hej, oto moj 1 post prosze byc dla mnie milym!!";
            obslugaPremium.DodajPost(uzytkownik, naszaWiadomosc);

            var forum = obslugaPremium.PobierzZawartoscForum();

            var ilosc_wiadomosci_o_naszej_tresci = forum.Where(x => x.Contains(naszaWiadomosc))
                                                        .Count();
            Assert.Greater(ilosc_wiadomosci_o_naszej_tresci, 0);
        }

        [Test]
        public void Podgladanie_histori_transakcji_innego_uzytkownika()
        {
            var uzytkownik1 = serwis.ZalogujSie("email@wp.pl", "haslo1");
            Uzytkownik_wykupuje_premium_na_miesiac();
            Assert.IsNotNull(uzytkownik1);
            

            var uzytkownik2 = serwis.ZalogujSie("email2@wp.pl", "haslo2");
            Assert.IsNotNull(uzytkownik2);

            //uzytkownik1 jest premium, 2 nie
            var transakcje = obslugaPremium.PodejrzyjTransakcjeUzytkownika(uzytkownik1, uzytkownik2);
            Assert.IsNotNull(transakcje);

            //nie powinien miec dostepu
            transakcje = obslugaPremium.PodejrzyjTransakcjeUzytkownika(uzytkownik2, uzytkownik1);
            Assert.IsNull(transakcje);
        }
    }
}
