using System.Collections.Generic;

namespace KryptoKlasy
{
    public class Chat
    {
        public Uzytkownik Uzytkownik;
        public Doradca Doradca;
        public List<string> HistoriaRozmow;

        public Chat(Uzytkownik uzytkownik, Doradca doradca)
        {
            Uzytkownik = uzytkownik;
            Doradca = doradca;
            HistoriaRozmow = new List<string>();
        }
    }
}
