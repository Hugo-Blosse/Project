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
            Console.WriteLine("Jest rok 1955. Zostałeś wybrany na kapitana nowego okrętu podwodnego.");
            Console.WriteLine("Dowiedziałeś się, że jeden z twoich toważyszy jest zdrajcą i podłożył bombę na okręcie.");
            Console.WriteLine("Twoim zadaniem jest znalezienie sabotażysty, pokonanie go i uratowanie załogi.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Pamiętaj o zamykaniu drzwi.\nRozmowa z towarzyszami mogą udzielić wskazówek.");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Są 3 poziomy trudności (1 najłatwiejszy, 3 najtrudniejszy).");
            Console.WriteLine("Różnią się czasem na wykonanie misji i poziomem agresji zdrajcy. Powodzenia.");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            int Dif = ErrorCatch.Error3("Wybierz cel misji kapitanie:\n 1 - Włochy \n 2 - Niemcy \n 3 - Syberia");
            submarine.Place = Dif.ToString();
            Random rng = new Random();
            bool a = false;
            bool b = false;
            bool c = false;
            switch (rng.Next(3))
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
            Crewmates aurelia = new Crewmates(Names.Aurelia, a);
            Crewmates bob = new Crewmates(Names.Bob, b);
            Crewmates clobert = new Crewmates(Names.Clobert, c);
            string name = "";
            if (aurelia.Sabo) { name = Names.Aurelia.ToString(); }
            if (bob.Sabo) { name = Names.Bob.ToString(); }
            if (clobert.Sabo) { name = Names.Clobert.ToString(); }
            Saboteur saboteur = new Saboteur(name);
            Puzzles.Help = rng.Next(3);
            Console.WriteLine(submarine.Place+" to cel twojej misji. Dopłyniesz tam za "+12/Dif+" minut.\nZdrajca zdążył już podłożyć bombę i uniemożliwić zmianę drogi okrętu.\nZnajdź sabotażystę i uratuj załogę przed dopłynięciem do celu.");
            Ship.Drawing();
            Console.WriteLine("Kliknij enter, żeby kontynuować.");
            Console.ReadLine();
            Time.StartTimer(Dif);
            Ship.Code = rng.Next(1000, 10000).ToString();
            Puzzles.BombCode = rng.Next(1000, 10000).ToString();
            switch(Dif)
            {
                case 1:
                    Menu.MainRoom(aurelia, bob, clobert, DifficulityLevel.Easy, saboteur);
                    break;
                case 2:
                    Menu.MainRoom(aurelia, bob, clobert, DifficulityLevel.Medium, saboteur);
                    break;
                case 3:
                    Menu.MainRoom(aurelia, bob, clobert, DifficulityLevel.Hard, saboteur);
                    break;
            }
        }
    }
}