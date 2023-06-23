using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Puzzles
    {
        private static bool ratHappy;
        public static bool RatHappy
        {
            get { return ratHappy; }
            set { ratHappy = value; }
        }
        public static string BombCode = "";
        public static int Help;
        public static bool Tip = false;
        public static void Tips(string words)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(words);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Search(string words, string item)
        {
            Console.Write(words);
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                Console.Write(".");
            }
            Console.WriteLine(" Znalazłeś "+item);
            Thread.Sleep(1000);
        }
        public static void RatPuzzle()
        {
            Console.WriteLine("Szczur: Zadam ci zagadkę, jeżeli na nią odpowiesz, dopuszczę cię do półek.");
            Random rng = new Random();
            string answear;
            switch (rng.Next(5))
            {
                case 0:
                    Console.WriteLine("Szczur: Mój stwórca mnie sprzedał, mój kupiec mnie nie potrzebuje, a mój użytkownik mnie nie widzi.\nSzczur: Czym jestem?");
                    answear = Console.ReadLine() + "";
                    if (answear == "trumna" | answear == "Trumna" | answear == "trumną" | answear == "Trumną") { Console.WriteLine("Szczur: To prawidłowa odpowiedź! Szczur Franek jest z ciebie dumny!"); RatHappy = true; break; }
                    Console.WriteLine("Szczur: Niestety, ale prawidłowa odpowiedź to trumna. Nie mogę cię przepuścić.");
                    break;
                case 1:
                    Console.WriteLine("Szczur: Może być najlepszym przyjacielem człowieka,\nSzczur: Gdy mocniej tupniesz - do klatki ucieka.\nSzczur: Jego krewni mieszkają w piwnicy,\nSzczur: Niejedna dziewczyna na jego widok krzyczy.\nSzczur: Czym jestem?");
                    answear = Console.ReadLine() + "";
                    if (answear == "szczur" | answear == "Szczur" | answear == "szczurem" | answear == "Szczurem" | answear == "mysz" | answear == "Mysz" | answear == "Myszą" | answear == "myszą") { Console.WriteLine("Szczur: To prawidłowa odpowiedź! Szczur Franek jest z ciebie dumny!"); RatHappy = true; break; }
                    Console.WriteLine("Szczur: Niestety to jest niepoprawna odpowiedź. Prawidłowa odpowiedź to szczur lub mysz! Odpowiedź była przed tobą cały czas!");
                    break;
                case 2:
                    Console.WriteLine("Szczur: Wyprzedzasz drugą osobę w wyścigu.\nSzczur: Które miejsce zajmujesz?");
                    answear = Console.ReadLine() + "";
                    if (answear == "2" | answear == "dwa" | answear == "Dwa" | answear == "drugie" | answear == "Drugie") { Console.WriteLine("Szczur: To prawidłowa odpowiedź! Szczur Franek jest z ciebie dumny!"); RatHappy = true; break; }
                    Console.WriteLine("Szczur: Niestety, ale prawidłowa odpowiedź to drugie. Nie przepuszczę cię.");
                    break;
                case 3:
                    Console.WriteLine("Szczur: Jestem tak delikatny, że wypowiedzenie mojego imienia mnie łamie.\nSzczur: Czym jestem?");
                    answear = Console.ReadLine() + "";
                    if (answear == "" | answear == "cisza" | answear == "ciszą" | answear == "Cisza" | answear == "Ciszą") { Console.WriteLine("Szczur: To prawidłowa odpowiedź! Szczur Franek jest z ciebie dumny!"); RatHappy = true; break; }
                    Console.WriteLine("Szczur: Niestety, ale prawidłowa odpowiedź to cisza. Jeżeli odpowiesz poprawnię to pozwolę ci przejść.");
                    break;
                case 4:
                    Console.WriteLine("Szczur: Jak się nazywa wielki, soczysty pierd?");
                    answear = Console.ReadLine() + "";
                    if (answear == "Bzdziorek" | answear == "bzdziorek") { Console.WriteLine("Szczur: To prawidłowa odpowiedź! Szczur Franek jest z ciebie dumny!"); RatHappy = true; break; }
                    Console.WriteLine("Szczur: Niestety, ale prawidłowa odpowiedź to bzdziorek. Odpowiedz poprawnie a cię przepuszczę.");
                    break;
            }
        }
        public static void HatchPuzzle(Saboteur saboteur)
        {
            int answear = 0;
            if (!Menu.Inventory.List.Any(item => item.Name == "Dowód zdrady"))
            {
                Tip = true;
                Console.Write("W środku znajduje się skrzynka, zniszczona kartka z niewyraźnym napisem i duży przedmiot z odliczającym zegarem.");
                Tips("\nTo jest bomba.\n");
                Console.Write("Na kartce jest napisane: Kod do skrzyni = ");
                switch (Help)
                {
                    case 0:
                        Console.WriteLine("Numery wyrazów z naj_i__sz_ li__b_ s__o_ł_se_ w wy_az_e, kol__n__ć _os_ą__");
                        answear = 1243;
                        break;
                    case 1:
                        Console.WriteLine("Numer_ naj_ł_żs__c_ _yr_zó_, kol__n__ć ma__j_c_");
                        answear = 3412;
                        break;
                    case 2:
                        Console.WriteLine("Liczb_ __ół_ł__ek we _szy__ki_h wyr_z__h");
                        answear = 16;
                        break;
                }
                Console.WriteLine("Panel zamykający skrzynkę wyświetla 4 wyrazy:\n1 - deszcz\n2 - pająk\n3 - biurowce\n4 - lampion");
                Console.Write("Wpisz kod do skrzynki: ");
                string choice = Console.ReadLine() + "";
                if (choice == answear.ToString())
                { Search("Przeszukujesz skrzynkę", "dowód zdrady!"); Menu.Inventory.AddItem(new Item { Name = "Dowód zdrady", Description = saboteur.Name + " jest zdrajcą" }); }
                else
                {
                    Tips("\nMoże "+Names.Clobert+" coś o tym wie.\n");
                    Console.WriteLine("Kliknij enter, żeby kontynuować.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Czy chcesz wpisać kod do bomby?");
                Tips("Wpisanie złego kodu zpowoduje wybuch bomby.\n");
                if (ErrorCatch.Error2(" 1 - tak\n 2 - nie")==1)
                {
                    Console.Write("Wpisz kod: ");
                    string code = Console.ReadLine()+"";
                    if (code == BombCode)
                    {
                        Menu.Ending8();
                    }
                    Menu.Ending7();
                }
            }

        }
    }
}
