using System;
using System.Collections.Generic;
using System.Linq;

namespace KryptoKlasy
{
    public class ObslugaPremium
    {
        public List<Doradca> PobierzDostepnychDoradcow() => doradcy;
        public bool WykupPomocDoradcy(Uzytkownik uzytkownik, Doradca doradca)
        {
            if (uzytkownik == null || doradca == null)
                return false;

            if (wykupieniDoradcy.ContainsKey(uzytkownik) == false)
                wykupieniDoradcy.Add(uzytkownik, new List<Doradca>());

            if (wykupieniDoradcy[uzytkownik].Contains(doradca))
                return true;

            wykupieniDoradcy[uzytkownik].Add(doradca);
            return true;
        }
        private List<Doradca> doradcy;
        private List<Chat> historiaRozmow;
        private List<(Uzytkownik,string)> forum;
        private Dictionary<Uzytkownik, List<Doradca>> wykupieniDoradcy;
        public List<Doradca> WykupieniDoradcyDanegoUzytkownika(Uzytkownik uzytkownik) => wykupieniDoradcy[uzytkownik];
        public Chat PobierzHistorieRozmow(Uzytkownik uzytkownik, Doradca doradca) => historiaRozmow.Where(x => x.Uzytkownik == uzytkownik)
                                                                                                   .Where(x => x.Doradca == doradca)
                                                                                                   .FirstOrDefault();
        public bool WyslijWiadomoscDoDoradcy(Uzytkownik uzytkownik, Doradca doradca, string Wiadomosc)
        {
            var chat = PobierzHistorieRozmow(uzytkownik, doradca);
            if(chat==null)
            {
                chat = new Chat(uzytkownik, doradca);
                historiaRozmow.Add(chat);
            }
            if (chat == null)
                return false;
            chat.HistoriaRozmow.Add(Wiadomosc);
            return true;
        }
        public bool RozliczPrzychod(UzytkownikFirmowy uzytkownikFirmowy) => true;
        public bool DodajPost(Uzytkownik uzytkownik, string wiadomosc)
        {
            if (uzytkownik == null) return false;

            forum.Add((uzytkownik, wiadomosc));
            return true;
        }
        public List<string> PobierzZawartoscForum() => forum.Select(x => $"{x.Item1} napisal: {x.Item2}").ToList();
        public List<Transakcja> PodejrzyjTransakcjeUzytkownika(Uzytkownik uzytkownikSprawdzajacy, Uzytkownik uzytkownikPodgladany)
        {
            if (uzytkownikSprawdzajacy == null || uzytkownikPodgladany == null)
                return null;
            if (uzytkownikSprawdzajacy.UzytkownikPremium == false)
                return null;
            return (new ObslugaTransakcji()).PobierzTransakcjeUzytkownika(uzytkownikPodgladany);
        }
            

        public bool WykupPremiumNaMiesiac(Uzytkownik uzytkownik)
        {
            if(uzytkownik==null)
                return false;

            if (uzytkownik.KoniecPremium <= DateTime.Now)
                uzytkownik.KoniecPremium = DateTime.Now.AddMonths(1);
            else
                uzytkownik.KoniecPremium += TimeSpan.FromDays(31);
            return true;
        }

        public ObslugaPremium()
        {
            doradcy = new List<Doradca>()
            {
                new Doradca("Karol","Doradczy","email@wp.pl","haslo1",DateTime.Now),
                new Doradca("Karol2","Doradczy2","email2@wp.pl","haslo2",DateTime.Now),
                new Doradca("Karol3","Doradczy3","email3@wp.pl","haslo3",DateTime.Now)
            };
            historiaRozmow = new List<Chat>();
            forum = new List<(Uzytkownik, string)>();
            wykupieniDoradcy = new Dictionary<Uzytkownik, List<Doradca>>();
        }
    }
}
