using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Ship
    {
        private string place = "";
        public string Place
        {
            get { return place; }
            set
            {
                switch (value)
                {
                    case "1":
                        place = "Włochy";
                        break;
                    case "2":
                        place = "Niemcy";
                        break;
                    case "3":
                        place = "Syberia";
                        break;
                }
            }
        }
        public static bool piperepaired = false;

        public static string Code="";

        public static void Rooms(int room, DifficulityLevel diff, Crewmates crew1, Crewmates crew2, Crewmates crew3, Saboteur saboteur)
        {
            switch (room)
            {
                case 1:
                    Room1(diff);
                    break;
                case 2:
                    Room2(diff, saboteur);
                    break;
                case 3:
                    Room3(diff);
                    break;
                case 4:
                    Room4(diff, crew1, crew2, crew3, saboteur);
                    break;
            }
        }

        public static void Room1(DifficulityLevel difficulity)
        {
            int y = 1;
            bool doorlocked = false;
            Random rng = new Random();
            while (y != 0)
            {
                Console.Write("Znajdujesz się w małym pokoju. ");
                if (!piperepaired)
                {
                    Console.WriteLine("Przed sobą widzisz zepsuty zawór."); Console.Write("Para wodna wylatuje z uszkodzonej rury na parwo od ciebie.");
                }
                switch (ErrorCatch.Error4("Co chcesz zrobić?\n 1 - zamknąć/otworzyć drzwi wejściowe\n 2 - naprawić zawór\n 3 - zajrzeć do rury\n 4 - wyjść"))
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
                        if (Menu.Inventory.List.Any(name => name.Name == "Klucz francuski")) { piperepaired = true; Console.Clear(); Console.WriteLine("Używasz klucza francuskiego do naprawienia zaworu. Para wodna przestała leciec z rury."); break; }
                        Console.Clear();
                        Console.WriteLine("Nie masz narzędzi, żeby naprawić rurę");
                        break;
                    case 3:
                        if (Saboteur.ComeIn(difficulity) & !doorlocked)
                        {
                            Menu.Ending3();
                        }
                        if (piperepaired & !Menu.Inventory.List.Any(item => item.Name == "Kartka z 4-cyfrowym kodem")) { Menu.Inventory.AddItem(new Item { Name = "Kartka z 4-cyfrowym kodem", Description = Code }); Puzzles.Search("Zaglądasz do rury.","kartkę z 4-cyfrowym kodem."); break; }
                        if (!piperepaired) { Menu.Ending2(); }
                        Console.WriteLine("Nie znalazłeś nic nowego.");
                        break;
                    case 4:
                        if (!doorlocked) { y = 0; }
                        Console.WriteLine("Drzwi są zamknięte, nie możesz wyjść.");
                        break;
                }
            }
        }
        public static void Room2(DifficulityLevel difficulity, Saboteur saboteur)
        {
            int y = 1;
            bool doorlocked = false;
            while (y != 0)
            {
                Console.WriteLine("Znajdujesz się w niewielkim pomieszczeniu. Pod tobą jest właz i panel z cyframi.");
                switch (ErrorCatch.Error3("Co chcesz zrobić?\n 1 - zamknąć/otworzyć drzwi wejściowe\n 2 - wpisać kod do włazu i wejść\n 3 - wyjść"))
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
                        Console.WriteLine("Wpisz kod do włazu.");
                        string code = Console.ReadLine() + "";
                        if (code == Code)
                        {
                            switch (ErrorCatch.Error2("Czy chcesz wejść do środka?\n 1 - tak\n 2 - nie"))
                            {
                                case 1:
                                    Puzzles.HatchPuzzle(saboteur);
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
        public static void Room3(DifficulityLevel difficulity)
        {
            int y = 1;
            bool doorlocked = false;
            while (y != 0)
            {
                Console.WriteLine("Znajdujesz się w magazynie. Przed tobą jest dużo przedmiotów poukładanych na półkach."); if (!Puzzles.RatHappy) Console.WriteLine("Ogromny szczur blokuje ci drogę do nich.");
                switch (ErrorCatch.Error4("Co chcesz zrobić?\n 1 - zamknąć/otworzyć drzwi wejściowe\n 2 - poszukać przydatnych narzędzi\n 3 - porozmawiać z szczurem\n 4 - wyjść"))
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
                        if (!Puzzles.RatHappy)
                        {
                            Console.Write("Szczur: Hej, nie tak prędko, "); Puzzles.Tips("bez odpowiedzi na moją zagadkę nie pozwolę ci grzebać w moich skarbach!\n"); break;
                        }
                        if (Menu.Inventory.List.Any(item => item.Name == "Klucz francuski")) { Console.WriteLine("Nie znalazłeś nic nowego."); break; }
                        Menu.Inventory.AddItem(new Item { Name = "Klucz francuski", Description = "Może się przydać do naprawy." });
                        Menu.Inventory.AddItem(new Item { Name = "Kastety", Description = "Mogą się przydać w walce." });
                        Puzzles.Search("Przeszukujesz magazyn.","klucz francuski i kastety!");
                        break;
                    case 3:
                        if (Saboteur.ComeIn(difficulity) & !doorlocked)
                        {
                            Menu.Ending3();
                        }
                        if (!Puzzles.RatHappy) { Puzzles.RatPuzzle(); break; }
                        if (Menu.Inventory.List.Any(name => name.Name == "Ser" & !Fight.Rat)) { Fight.Rat = true; Menu.Inventory.List.RemoveAll(x => x.Name == "Ser"); Console.WriteLine("Oddajesz ser Frankowi."); }
                        if (Fight.Rat) { Console.WriteLine("Szczur Franek: Dziękuję! Jeżeli będziesz czegoś potrzebować przyjdę z pomocą."); break; }
                        Console.WriteLine("Szczur Franek: Jestem z ciebie dumny!");
                        break;
                    case 4:
                        if (!doorlocked) { y = 0; }
                        Console.WriteLine("Drzwi są zamknięte, nie możesz wyjść.");
                        break;
                }
            }
        }
        public static void Room4(DifficulityLevel difficulity, Crewmates crew1, Crewmates crew2, Crewmates crew3, Saboteur saboteur)
        {
            int y = 1;
            bool doorlocked = false;
            while (y != 0)
            {
                Console.WriteLine("Znajdujesz się w pustym pokoju. Jest to dobre miejsce na skonfrontowanie zdrajcy.");
                Puzzles.Tips("Za oskarżenie niewinnego towarzysza możesz ponieść konsekwencje. ");
                switch (ErrorCatch.Error4("Co chcesz zrobić?\n 1 - przywołaj towarzysza, którego podejrzewasz o zdradę\n 2 - wyjść"))
                {
                    case 1:
                        {
                            if (Fight.once) { Console.WriteLine("Już pokonałeś zdrajcę."); Puzzles.Tips("Może na okręcie jest inne zagrożenie."); Console.WriteLine(""); Console.WriteLine("Klikniej enter, żeby kontynuować."); Console.ReadLine(); break; }
                            if (!Fight.once)
                            {
                                switch (ErrorCatch.Error4("Kto jest zdrajcą?\n 1 - " + crew1.Name + "\n 2 - " + crew2.Name + "\n 3 - " + crew3.Name + "\n 4 - nie konfrontuj nikogo"))
                                {
                                    case 1:
                                        Fight.FightMoves(difficulity, crew1, saboteur);
                                        break;
                                    case 2:
                                        Fight.FightMoves(difficulity, crew2, saboteur);
                                        break;
                                    case 3:
                                        Fight.FightMoves(difficulity, crew3, saboteur);
                                        break;
                                    case 4:
                                        break;
                                }
                            }
                            break;
                        }
                    case 2:
                        if (!doorlocked) { y = 0; }
                        Console.WriteLine("Drzwi są zamknięte, nie możesz wyjść.");
                        break;
                }
            }
        }
        public static void Drawing()
        {
            Water(" ~   ~     ~     ~    "); Submarine(",-#-,"); Water("  ~     ~   "); Console.WriteLine();
            Water("   ~     ~      ~     "); Submarine(@"|    \"); Water("    ~     ~ "); Console.WriteLine();
            Water("  ~     "); Submarine(".,------------'     `----."); Water(" ~    "); Console.WriteLine();
            Water(" ~ ~~ "); Submarine(@"+-                          \"); Water(" ~   "); Console.WriteLine();
            Water("~ ~~ "); Submarine("+-                           /"); Water("    ~"); Console.WriteLine();
            Water(" ~~ ~ "); Submarine("+-.,_______________________/"); Water("   ~  "); Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Water(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write(s);
        }
        public static void Submarine(string s)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(s);
        }
    }
}
