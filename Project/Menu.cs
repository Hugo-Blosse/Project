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
        public static void MainRoom(string name, int difficulity,Crewmates crew1, Crewmates crew2, Crewmates crew3)
        {
            int x = 1;
            while (x != 0)
            {
                Console.Clear();
                string choice;
                Console.WriteLine("Jesteś w pomieszczeniu głównym. Widzisz twarze swoich towarzyszy.");
                Console.WriteLine(crew1.Name + " wygląda na zaniepokojoną, "+crew2.Name+" siedzi w stoickim spokoju, "+crew3.Name+" patrzy na ciebie zaciekawiony.");
                Console.WriteLine("Jaką decyzję podejmujesz?");
                choice = ErrorCatch.ErrorMenu("1 - porozmawiaj z towarzyszem\n2 - sprawdź ekwipunek\n3 - pójdź do innego pokoju \n4 - wyjdź");
                switch (choice)
                {
                    case "1":
                        switch(ErrorCatch.Error3("Z kim chcesz porozmawiać?\n 1 - "+crew1.Name+"\n 2 - "+crew2.Name+"\n 3 - "+crew3.Name))
                        {
                            case 1:
                                Crewmates.Talk(crew1);
                                break;
                            case 2:
                                Crewmates.Talk(crew2);
                                break;
                            case 3:
                                Crewmates.Talk(crew3);
                                break;
                        }
                        break;
                    case "2":
                        Console.WriteLine("Zawartość ekwipunku:");
                        Console.WriteLine(Inventory.ToString());
                        Console.WriteLine("Kliknij enter, żeby kontynuować.");
                        Console.ReadLine();
                        break;
                    case "3":
                        Puzzles.Puzzle(ErrorCatch.Error3("Do którego pokoju chcesz wejść?\n 1 - pokój z lewej strony\n 2 - pokój z prawej strony\n 3 - pokój na wprost"),difficulity);
                        break;
                    case "4":
                        Console.WriteLine("Próbujesz wyjść z okrętu podwodnego przez śluzę. Do pomieszczenia wpływa woda, która spycha cię na podłogę.\nNikt nie zdążył uciec.");
                        Console.Write("Zakończenie 1 - Topielec. "); Puzzles.Tips("Może wychodzenie z pomieszczenia głównego jest złym pomysłem.");
                        Ending1();
                        break;
                }
            }
        }
        public static void Ending1()
        {
            Console.WriteLine("\n");
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
            Puzzles.Tips("Zamykanie drzwi jest ważne, gdy nie możesz ufać swojej załodze.");
            Console.WriteLine();
            Puzzles.Tips("   ."+"\n");
            Puzzles.Tips(@"  /i\"+"\n");
            Puzzles.Tips("  |i|"+"\n");
            Console.WriteLine("  |i| ");
            Console.WriteLine("  |i|");
            Console.WriteLine(" -----");
            Console.WriteLine("  | |");
            Console.WriteLine("   0");
            Environment.Exit(0);
        }
    }
}
