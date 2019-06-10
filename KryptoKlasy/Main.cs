using System;
using System.Collections.Generic;
using System.Text;

namespace KryptoKlasy
{
    public static class KryptoKlasy
    {
        public static void Main()
        {
            ScenariuszGielda();
            //ScenariuszUzytkownicy();
            Console.ReadKey();
        }

        public static void ScenariuszGielda()
        {
            Console.WriteLine("Inicjalizacja giełdy");
            Gielda gielda = new Gielda();
            for (int i = 0; i < 10; i++)
                gielda.WygenerujIZapiszSnapshot();

            Console.WriteLine("Pobierz cała historie gieldy");
            foreach (var snapshot in gielda.PobierzHistorie())
                Console.WriteLine(snapshot);

            Console.WriteLine();
            Console.WriteLine("Pobierz historie ostatnich 5 dni.");
            Console.WriteLine(gielda.HistoriaOstatnie5Dni());
        }

        public static void ScenariuszUzytkownicy()
        {
            var serwis = new Serwis();

            Console.WriteLine("Rejestracja 3 uzytkownikow");
            Czity.Loading();
            serwis.ZarejestrujSie("Kamil", "Mielnik", "email@wp.pl", "haslo1", "739821739821", DateTime.Now);
            serwis.ZarejestrujSie("Kamil", "Spiewak", "email2@wp.pl", "haslo2", "11111111111", DateTime.Now.AddYears(-20));
            serwis.ZarejestrujSie("Roman", "Broman", "email3@wp.pl", "haslo3", "cxnzkcjnxzkcjz", DateTime.MinValue);

            Console.WriteLine("Zarejestrowano");
            Console.WriteLine();

            Console.WriteLine("Logowanie z błędnym haslem:");
            Czity.Loading();
            var uzytkownik = serwis.ZalogujSie("email@wp.pl", "bledneHaslo");
            Console.WriteLine($"Wynik: {uzytkownik}");
           
            Console.WriteLine("Logowanie z prawidlowym haslem:");
            uzytkownik = serwis.ZalogujSie("email@wp.pl", "haslo1");
            Console.WriteLine($"Wynik: {uzytkownik}");

            Console.WriteLine();

            Console.WriteLine("Wczytywanie ustawien uzytkownika:");
            Czity.Loading();
            serwis.UstawKolorTlaStrony(uzytkownik, ConsoleColor.DarkRed);


            Console.WriteLine("Pobieranie danych zalogowanego uzytkownika");
            Czity.Loading();
            Console.WriteLine($"{serwis.PobierzKopieDanych(uzytkownik)}");

            Console.WriteLine();
            Console.WriteLine("Zmiana hasla i nowe dane uzytkownika:");

            Czity.Loading();
            serwis.UstawNoweHaslo(uzytkownik, "noweHaslo");
            Console.WriteLine($"{serwis.PobierzKopieDanych(uzytkownik)}");

            Console.WriteLine("Wylogowywanie sie:");
            Czity.Loading(700);
            uzytkownik = serwis.WylogujSie(uzytkownik);

            Console.WriteLine("Proba wykonania zmiany hasla po wylogowaniu:");
            Czity.Loading();
            Console.WriteLine($"Efekt: {serwis.UstawNoweHaslo(uzytkownik, "noweHaslo")}");

            Console.WriteLine();

            Console.WriteLine("Logowanie z prawidlowym haslem:");
            uzytkownik = serwis.ZalogujSie("email@wp.pl", "noweHaslo");
            Console.WriteLine($"Wynik: {uzytkownik}");

        }
    }
}
