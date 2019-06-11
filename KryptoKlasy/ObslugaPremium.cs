using System;
using System.Collections.Generic;

namespace KryptoKlasy
{
    public class ObslugaPremium
    {
        public List<Doradca> PobierzDostepnychDoradcow() => throw new NotImplementedException();
        public bool WykupPomocDoradcy(Uzytkownik uzytkownik, Doradca doradca) => true;
        private List<Chat> historiaRozmow;
        private List<(Uzytkownik, string)> forum;
        private Dictionary<Uzytkownik, List<Doradca>> wykupieniDoradcy;
        public List<Doradca> WykupieniDoradcyDanegoUzytkownika(Uzytkownik uzytkownik) => throw new NotImplementedException();
        public Chat PobierzHistorieRozmow(Uzytkownik uzytkownik, Doradca doradca) => throw new NotImplementedException();
        public bool WyslijWiadomoscDoDoradcy(Uzytkownik uzytkownik, Doradca doradca, string Wiadomosc) => true;
        public bool RozliczPrzychod(UzytkownikFirmowy uzytkownikFirmowy) => true;
        public bool DodajPost(Uzytkownik uzytkownik, string wiadomosc) => true;
        public List<string> PobierzZawartoscForum() => throw new NotImplementedException();
        public List<Transakcja> PodejrzyjTransakcjeUzytkownika(Uzytkownik uzytkownikSprawdzajacy, Uzytkownik uzytkownikPodgladany) =>
            throw new NotImplementedException();
    }
}
