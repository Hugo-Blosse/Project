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
        private static bool rathappy;
        public static bool Rathappy
        {
            get { return rathappy; }
            set { rathappy = value; }
        }
        public static string Code;
        public static void Tips(string words)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(words);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Puzzle(int room, int diff) 
        {
            switch (room)
            {
                case 1:
                    Puzzle1(diff);
                    break;
                case 2:
                    Puzzle2(diff);
                    break;
                case 3:
                    Puzzle3(diff);
                    break;
            }
        }
        public static void Puzzle1(int difficulity) 
        {
            int y = 1;
            bool doorlocked = false;
            bool piperepaired = false;
            Random rng = new Random();
            while (y != 0) 
            {
                Console.WriteLine("Znajdujesz się w małym pokoju. Przed sobą widzisz zepsuty zawór.");
                if (!piperepaired) Console.Write("Para wodna wylatuje z uszkodzonej rury na parwo od ciebie.");
                switch (ErrorCatch.ErrorMenu("Co chcesz zrobić?\n 1 - zamknąć/otworzyć drzwi\n 2 - naprawić zawór\n 3 - zajrzeć do rury\n 4 - wyjść"))
                {
                    case "1":
                        if (doorlocked) { Console.WriteLine("Drzwi są otwarte."); doorlocked = false; break; }
                        doorlocked = true;
                        Console.WriteLine("Drzwi zostały zamknięte.");
                        break;
                    case "2":
                        if (Saboteur.ComeIn(difficulity) & !doorlocked)
                        {
                            Menu.Ending3();
                        }
                        if (Menu.Inventory.List.Any(name => name.Name == "Klucz Francuski")) { piperepaired = true; Console.Clear(); Console.WriteLine("Używasz klucza francuskiego do naprawienia zaworu. Para wodna przestała leciec z rury."); break; }
                        Console.Clear();
                        Console.WriteLine("Nie masz narzędzi, żeby naprawić rurę");
                        break;
                    case "3":
                        if (Saboteur.ComeIn(difficulity) & !doorlocked)
                        {
                            Menu.Ending3();
                        }
                        if (piperepaired & !Menu.Inventory.List.Any(name => name.Name == "Kartka z kodem")) { Code = rng.Next(1000, 10000).ToString(); Menu.Inventory.AddItem(new Item { Name = "Kartka z kodem", Description = Code }); Console.WriteLine("Znalazłeś kartkę z 4-cyfrowym kodem."); break; }
                        if (!piperepaired) { Console.WriteLine("Wsadzasz głowę do rury z wylatującą parą wodną. Wysoka temperatura gazu topi ci skórę.\nZakończenie 2 - Pochodnia."); Tips("Naprawienie zaworu przed zajrzeniem do rury może być dobrym pomysłem.\n"); Menu.Ending2(); }
                        Console.WriteLine("Nie znalazłeś nic nowego.");
                        break;
                    case "4":
                        if (!doorlocked) { y = 0; }
                        Console.WriteLine("Drzwi są zamknięte, nie możesz wyjść.");
                        break;
                }
            }
        }
        public static void Puzzle2(int difficulity)
        {
            int y = 1;
            bool doorlocked = false;
            while (y != 0)
            {
                Console.WriteLine("Znajdujesz się w niewielkim pomieszczeniu. Przed tobą są metalowe drzwi i panel z cyframi.");
                switch (ErrorCatch.Error3("Co chcesz zrobić?\n 1 - zamknąć/otworzyć drzwi\n 2 - wpisać kod do drzwi i wejść\n 3 - wyjść"))
                {
                    case 1:
                        if (doorlocked) { Console.WriteLine("Drzwi są otwarte."); doorlocked = false; break; }
                        doorlocked = true;
                        Console.WriteLine("Drzwi zostały zamknięte.");
                        break;
                    case 2:
                        if (Saboteur.ComeIn(difficulity) & !doorlocked)
                        {
                            Menu.Ending3();
                        }
                        Console.WriteLine("Wpisz kod do drzwi.");
                        string code = Console.ReadLine()+"";
                        if (code == Code)
                        {
                            switch (ErrorCatch.Error2("Czy chcesz wejść do środka?\n 1 - tak\n 2 - nie"))
                            {
                                case 1:
                                    DoorPuzzle();
                                    break;
                                case 2:
                                    break;
                            }
                        }
                        break;
                    case 3:
                        if (!doorlocked) { y = 0; }
                        Console.WriteLine("Drzwi są zamknięte, nie możesz wyjść.");
                        break;
                }
            }

        }
        public static void Puzzle3(int difficulity)
        {
            int y = 1;
            bool doorlocked = false;
            while (y != 0)
            {
                Console.WriteLine("Znajdujesz się w magazynie. Przed tobą jest dużo przedmiotów poukładanych na półkach."); if (!Rathappy) Console.WriteLine("Ogromny szczur blokuje ci drogę do nich.");
                switch (ErrorCatch.ErrorMenu("Co chcesz zrobić?\n 1 - zamknąć/otworzyć drzwi\n 2 - poszukać przydatnych narzędzi\n 3 - porozmawiać z szczurem\n 4 - wyjść"))
                {
                    case "1":
                        if (doorlocked) { Console.WriteLine("Drzwi są otwarte."); doorlocked = false; break; }
                        doorlocked = true;
                        Console.WriteLine("Drzwi zostały zamknięte.");
                        break;
                    case "2":
                        if (Saboteur.ComeIn(difficulity) & !doorlocked)
                        {
                            Menu.Ending3();
                        }
                        if (!Rathappy)
                        {
                            Console.Write("Szczur: Hej, nie tak prędko, "); Tips("bez odpowiedzi na moją zagadkę nie pozwolę ci grzebać w moich skarbach!\n");
                        }
                        if (Menu.Inventory.List.Any(name => name.Name == "Klucz Francuski")) { Console.WriteLine("Nie znalazłeś nic nowego."); break; }
                        Menu.Inventory.AddItem(new Item { Name = "Klucz Francuski", Description = "Może się przydać do naprawy." });
                        Console.WriteLine("Znalazłeś klucz francuski.");
                        break;
                    case "3":
                        if (Saboteur.ComeIn(difficulity) & !doorlocked)
                        {
                            Menu.Ending3();
                        }
                        if (!Rathappy) { RatPuzzle(); break; }
                        Console.WriteLine("Szczur Franek: Jestem z ciebie dumny!");
                        break;
                    case "4":
                        if (!doorlocked) { y = 0; }
                        Console.WriteLine("Drzwi są zamknięte, nie możesz wyjść.");
                        break;
                }
            }
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
                    if (answear == "trumna" | answear == "Trumna" | answear == "trumną" | answear == "Trumną") { Console.WriteLine("Szczur: To prawidłowa odpowiedź! Szczur Franek jest z ciebie dumny!"); Rathappy = true; break; }
                    Console.WriteLine("Szczur: Niestety, ale prawidłowa odpowiedź to trumna. Nie mogę cię przepuścić.");
                    break;
                case 1:
                    Console.WriteLine("Szczur: Może być najlepszym przyjacielem człowieka,\nSzczur: Gdy mocniej tupniesz - do klatki ucieka.\nSzczur: Jego krewni mieszkają w piwnicy,\nSzczur: Niejedna dziewczyna na jego widok krzyczy.\nSzczur: Czym jestem?");
                    answear = Console.ReadLine() + "";
                    if (answear == "szczur" | answear == "Szczur" | answear == "szczurem" | answear == "Szczurem") { Console.WriteLine("Szczur: To prawidłowa odpowiedź! Szczur Franek jest z ciebie dumny!"); Rathappy = true; break; }
                    Console.WriteLine("Szczur: Niestety to jest niepoprawna odpowiedź. Prawidłowa odpowiedź to szczur! Odpowiedź była przed tobą cały czas!");
                    break;
                case 2:
                    Console.WriteLine("Szczur: Wyprzedzasz drugą osobę w wyścigu.\nSzczur: Które miejsce zajmujesz?");
                    answear = Console.ReadLine() + "";
                    if (answear == "2" | answear == "dwa" | answear == "Dwa" | answear == "drugie" | answear == "Drugie") { Console.WriteLine("Szczur: To prawidłowa odpowiedź! Szczur Franek jest z ciebie dumny!"); Rathappy = true; break; }
                    Console.WriteLine("Szczur: Niestety, ale prawidłowa odpowiedź to drugie. Nie przepuszczę cię.");
                    break;
                case 3:
                    Console.WriteLine("Szczur: Jestem tak delikatny, że wypowiedzenie mojego imienia mnie łamie.\nSzczur: Czym jestem?");
                    answear = Console.ReadLine() + "";
                    if (answear == "" | answear == "cisza" | answear == "ciszą" | answear == "Cisza" | answear == "Ciszą") { Console.WriteLine("Szczur: To prawidłowa odpowiedź! Szczur Franek jest z ciebie dumny!"); Rathappy = true; break; }
                    Console.WriteLine("Szczur: Niestety, ale prawidłowa odpowiedź to cisza. Jeżeli odpowiesz poprawnię to pozwolę ci przejść.");
                    break;
                case 4:
                    Console.WriteLine("Szczur: Jak się nazywa wielki, soczysty pierd?");
                    answear = Console.ReadLine() + "";
                    if (answear == "Bzdziorek" | answear == "bzdziorek") { Console.WriteLine("Szczur: To prawidłowa odpowiedź! Szczur Franek jest z ciebie dumny!"); Rathappy = true; break; }
                    Console.WriteLine("Szczur: Niestety, ale prawidłowa odpowiedź to bzdziorek. Odpowiedz poprawnie a cię przepuszczę.");
                    break;
            }
        }
        public static void DoorPuzzle()
        {
            Console.WriteLine("XD");
        }
    }
}
