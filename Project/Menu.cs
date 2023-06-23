using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project
{
    class Menu
    {
        private static Inventory inventory = new Inventory();
        public static Inventory Inventory 
        { get { return inventory; } }
        public static void MainRoom(Crewmates crew1, Crewmates crew2, Crewmates crew3, DifficulityLevel difficulity, Saboteur saboteur)
        {
            while (true)
            {
                Console.Clear();
                int choice;
                Console.WriteLine("Jesteś w pomieszczeniu głównym. Widzisz twarze swoich towarzyszy.");
                Console.WriteLine(crew1.Name + " wygląda na zaniepokojoną, " + crew2.Name + " siedzi w stoickim spokoju, " + crew3.Name + " patrzy na ciebie zaciekawiony.");
                choice = ErrorCatch.Error4("Jaką decyzję podejmujesz?\n 1 - porozmawiaj z towarzyszem\n 2 - sprawdź ekwipunek\n 3 - pójdź do innego pokoju \n 4 - wyjdź");
                switch (choice)
                {
                    case 1:
                        switch(ErrorCatch.Error3("Z kim chcesz porozmawiać?\n 1 - "+crew1.Name + "\n 2 - "+crew2.Name + "\n 3 - " + crew3.Name))
                        {
                            case 1:
                                Crewmates.Talk(crew1, saboteur);
                                break;
                            case 2:
                                Crewmates.Talk(crew2, saboteur);
                                break;
                            case 3:
                                Crewmates.Talk(crew3, saboteur);
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Zawartość ekwipunku:");
                        Console.WriteLine(Inventory.ToString());
                        Console.WriteLine("Kliknij enter, żeby kontynuować.");
                        Console.ReadLine();
                        break;
                    case 3:
                        Ship.Rooms(ErrorCatch.Error4("Do którego pokoju chcesz wejść?\n 1 - pokój z lewej strony\n 2 - pokój z prawej strony\n 3 - magazyn\n 4 - pusty pokój"),difficulity, crew1, crew2, crew3, saboteur);
                        break;
                    case 4:
                        Ending1();
                        break;
                }
            }
        }
        public static void Ending1()
        {
            Console.WriteLine("Próbujesz wyjść z okrętu podwodnego przez śluzę. Do pomieszczenia wpływa woda, która spycha cię na podłogę.\nNikt nie zdążył uciec.");
            Console.Write("Zakończenie 1 - Topielec. "); Puzzles.Tips("Może wychodzenie z pomieszczenia głównego jest złym pomysłem.\n");
            Console.WriteLine();
            Console.WriteLine("_| |_______________");
            Console.WriteLine("  !");
            Console.WriteLine(@"~~!~~\0/~~~~~~~~~~~");
            Console.WriteLine("      |");
            Console.WriteLine(@"     / \");
            Console.WriteLine("___________________");
            Environment.Exit(0);
        }
        public static void Ending2()
        {
            Console.WriteLine("Wsadzasz głowę do rury z wylatującą parą wodną. Wysoka temperatura gazu topi ci skórę.\nZakończenie 2 - Pochodnia.");
            Puzzles.Tips("Naprawienie zaworu przed zajrzeniem do rury może być dobrym pomysłem.\n");
            Console.WriteLine();
            Puzzles.Tips(@" )  )( )( "+"\n");
            Puzzles.Tips(@" ( _(_(_)"+"\n");
            Console.WriteLine(@"  /     \");
            Console.WriteLine(" | o   o |");
            Console.WriteLine(" |   ^   | ");
            Console.WriteLine(@"  \ mmm /");
            Console.WriteLine(@"   \___/ ");
            Environment.Exit(0);
        }
        public static void Ending3()
        {
            Console.WriteLine("Czujesz przeszywający ból w plecach. Spoglądając na dół widzisz ostrze noża, które przebiło twój brzuch na wylot.\nUpadasz na podłogę i giniesz od swojej rany.");
            Console.Write("Zakończenie 3 - Nóż w plecy.");
            Puzzles.Tips("Zamykanie drzwi jest ważne, gdy nie możesz ufać swojej załodze.\n");
            Console.WriteLine();
            Puzzles.Tips("   ."+"\n");
            Puzzles.Tips(@"  / \"+"\n");
            Puzzles.Tips("  | |"+"\n");
            Console.WriteLine("  | | ");
            Console.WriteLine("  | |");
            Console.WriteLine(" -----");
            Console.WriteLine("  |'|");
            Console.WriteLine("   0");
            Environment.Exit(0);
        }
        public static void Ending4()
        {
            Console.WriteLine("Dopłynąłeś do portu z bombą na pokładzie. Bomba wysadziła cały port.");
            Console.WriteLine("Zakończenie 4 - Koniec czasu.");
            Console.WriteLine();
            Console.WriteLine(".____.");
            Console.WriteLine("|( .)|");
            Console.WriteLine("| )( |");
            Console.WriteLine("|(::)|");
            Console.WriteLine("!----!");
            Environment.Exit(0);
        }
        public static void Ending5()
        {
            Console.WriteLine("Nie mogłeś znaleźć dowodów, że osoba, którą pokonałeś była zdrajcą.");
            Console.WriteLine("Twoi towarzysze oskarżyli cię o zdradę i wystrzelili cię z wyrzutni torped.");
            Console.WriteLine("Zakończenie 5 - Ślepy strzał.");
            Puzzles.Tips("Upewnij się, że konfrontujesz zdrajcę.\n");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("~   ~    ~   ~   ~  ");
            Console.WriteLine("  ~    ~   ~   ~   ~");
            Console.WriteLine(" ~  ~   0 ~   ~   ~ ");
            Console.WriteLine(@"~  ~  ~/|\  ~   ~  ~");
            Console.WriteLine(@"  ~  ~ / \~   ~   ~  ");
            Console.WriteLine("~  ~   ~   ~    ~   ~");
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }
        public static void Ending6()
        {
            Console.WriteLine("Przegrałeś walkę. W czasie, w którym byłeś nieprzytomny, sabotażysta podłożył dowody wskazujące na twoją zdradę.");
            Console.WriteLine("Twoi towarzysze oskarżyli cię o zdradę i wystrzelili cię z wyrzutni torped.");
            Console.WriteLine("Zakończenie 6 - Knockout.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("~   ~    ~   ~   ~  ");
            Console.WriteLine("  ~    ~   ~   ~   ~");
            Console.WriteLine(" ~  ~   0 ~   ~   ~ ");
            Console.WriteLine(@"~  ~  ~/|\  ~   ~  ~");
            Console.WriteLine(@" ~   ~ / \~   ~   ~  ");
            Console.WriteLine("~  ~   ~   ~    ~   ~");
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }
        public static void Ending7()
        {
            Console.WriteLine("Wpisałeś zły kod do bomby. Okręt rozpadł się na milion kawałków.");
            Console.WriteLine("Zakończenie 7 - Saper myli się tylko raz.");
            Puzzles.Tips("Upewnij się, że wpisujesz dobry kod do bomby.\n");
            Console.WriteLine();
            Puzzles.Tips(@"       ,,_<>_,," + "\n");
            Puzzles.Tips(@"   (_(__ (  )__)_)_)" + "\n");
            Puzzles.Tips(@"(_(__(_(  .  )_)__)_) " + "\n");
            Puzzles.Tips(@" (_(__(_ . .  _)_)__)" + "\n");
            Puzzles.Tips(@"        \   /" + "\n");
            Puzzles.Tips(@"         | |" + "\n");
            Puzzles.Tips(@"        /   \" + "\n");
            Puzzles.Tips(@"_______/     \______" + "\n");
            Environment.Exit(0);
        }
        public static void Ending8()
        {
            Console.WriteLine("Gratulację, udało ci się rozbroić bombę przed dotarciem do celu!");
            Console.WriteLine("Dobra robota kapitanie!");
            Console.WriteLine("Zakończenie 8 - Zwycięstwo.");
            Console.WriteLine("");
            Console.WriteLine(@"                       \0/ \0/  \0/");
            Console.WriteLine(@"                        |   |    |");
            Console.WriteLine(@"               ________/_\_/_\__/_\___");
            Ship.Water(" ~  ~   ~   ~  "); Console.WriteLine(@"  ||     ||    ||    ||");
            Ship.Water("  ~   ~   ~   ~"); Console.WriteLine(@"  ||     ||    ||    ||");
            Environment.Exit(0);
        }
    }
}
