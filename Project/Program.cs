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
            submarine.Dif = ErrorCatch.Error3("Wybierz cel misji kapitanie (poziom trudności - 1 jest najłatwiejszy):\n 1 - Włochy \n 2 - Niemcy \n 3 - Syberia");
            submarine.Place = submarine.Dif.ToString();
            Random rng = new Random();
            int random = rng.Next(2+2*submarine.Dif);
            bool a = false;
            bool b = false;
            bool c = false;
            Console.WriteLine(random-2);
            switch (random-2)
            {
                case <=0:
                    a = true;
                    break;
                case 1:
                    b = true;
                    break;
                case >=2:
                    c = true;
                    break;
            }
            Crewmates anna = new Crewmates("Anna", a);
            Crewmates bob = new Crewmates("Bob", b);
            Crewmates clobert = new Crewmates("Clobert", c);
            string name = "s";
            int diff = 1;
            if (anna.Sabo) { name = "Anna"; diff = 1; }
            if (bob.Sabo) { name = "Bob"; diff = 2; }
            if (clobert.Sabo) { name = "Clobert"; diff = 3; }
            Saboteur saboteur = new Saboteur(name, diff);
            Console.WriteLine(saboteur.Name + saboteur.Diff);
            Time.StartTimer(submarine.Dif);
            Console.WriteLine(submarine.Place+" to cel twojej misji. Musisz dopłynąć tam przed upłynięciem "+Time.N+" minut.");
            Thread.Sleep(2000);
            Console.WriteLine();
            Menu.MainRoom(anna.Name, bob.Name, clobert.Name);
        }
    }
}