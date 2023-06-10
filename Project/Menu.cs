using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project
{
    class Menu
    {
        public static void MainRoom(string a, string b, string c)
        {
            List<Inventory> inventory = Menu.Create();
            int x = 1;
            while (x != 0)
            {
                Console.Clear();
                string choice;
                Console.WriteLine("Jesteś w pomieszczeniu głównym. Widzisz twarze swoich towarzyszy.");
                Console.WriteLine(a + " wygląda na zaniepokojoną, " + b + " siedzi w stoickim spokoju, " + c + " patrzy się na ciebie zaciekawiony.");
                Console.WriteLine("Jaką decyzję podejmujesz?");
                choice = ErrorCatch.ErrorMenu("1 - porozmawiaj z towarzyszem\n2 - sprawdź ekwipunek\n3 - pójdź do innego pokoju \n4 - wyjdź");
                switch (choice)
                {
                    case "1":
                        Crewmates.Talk(ErrorCatch.Error3("Z kim chcesz porozmawiać?\n 1 - Anna\n 2 - Bob\n 3 - Clobert"));
                        break;
                    case "2":
                        break;
                    case "3":
                        Puzzles.Puzzle(ErrorCatch.Error3("Do którego pokoju chcesz wejść?\n 1 - pokój z lewej strony\n 2 - pokój z prawej strony\n 3 - pokój na wprost"));
                        break;
                    case "4":
                        x = 0;
                        Console.WriteLine("Wychodzisz z okrętu podwodnego przez śluzę. Do pomieszczenia wpływa woda, która spycha cię na podłogę.\nNikt nie zdążył uciec.");
                        break;
                }
            }
        }
        public static List<Inventory> Create()
        {
            List<Inventory> inventory = new List<Inventory>();
            new Inventory("Inventory", "221");
            return inventory;
        }
    }
}
