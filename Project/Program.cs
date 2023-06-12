using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using Project;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship submarine = new Ship();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("ZDRADA NA ATOMOWYM OKRĘCIE PODWODNYM");
            Console.WriteLine("Jest rok 1942. Zostałeś wybrany na kapitana nowej łodzi podwodnej.\nTwoim zadaniem jest dopłynięcie do celu i powstrzymanie ataków sabotarzysty.");
            Console.WriteLine("Są 3 poziomy trudności (1 najłatwiejszy, 3 najtrudniejszy).\nRóżnią się czasem na wykonanie misji i poziomem agresji zdrajcy. Powodzenia.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            submarine.Dif = ErrorCatch.Error3("Wybierz cel misji kapitanie (poziom trudności - 1 jest najłatwiejszy):\n 1 - Włochy \n 2 - Niemcy \n 3 - Syberia");
            submarine.Place = submarine.Dif.ToString();
            Random rng = new Random();
            int random = rng.Next(3);
            bool a = false;
            bool b = false;
            bool c = false;
            switch (random)
            {
                case 0:
                    a = true;
                    break;
                case 1:
                    b = true;
                    break;
                case 2:
                    c = true;
                    break;
            }
            Crewmates aurelia = new Crewmates("Aurelia", a);
            Crewmates bob = new Crewmates("Bob", b);
            Crewmates clobert = new Crewmates("Clobert", c);
            string name = "";
            if (aurelia.Sabo) { name = "Aurelia"; }
            if (bob.Sabo) { name = "Bob"; }
            if (clobert.Sabo) { name = "Clobert"; }
            Saboteur saboteur = new Saboteur(name);
            Time.StartTimer(submarine.Dif);
            Console.WriteLine(submarine.Place+" to cel twojej misji. Musisz dopłynąć tam przed upłynięciem "+Time.N+" minut.");
            Ship.Drawing();
            Thread.Sleep(2000);
            Console.WriteLine();
            Menu.MainRoom(saboteur.Name,submarine.Dif,aurelia,bob,clobert);
        }
    }
}