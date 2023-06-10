using Project;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship submarine = new Ship();
            Random rng = new Random();
            int random = rng.Next(2);
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
            Crewmates anna = new Crewmates("Anna", a);
            Crewmates bob = new Crewmates("Bob", b);
            Crewmates clobert = new Crewmates("Clobert", c);
            submarine.Dif = ErrorCatch.ErrorDif("Wybierz cel misji kapitanie (poziom trudności - 1 jest najłatwiejszy):\n 1 - Włochy \n 2 - Niemcy \n 3 - Syberia");
            submarine.Place = submarine.Dif.ToString();
            Time.StartTimer(submarine.Dif);
            Console.WriteLine(submarine.Place+" to cel twojej misji. Musisz dopłynąć tam przed upłynięciem "+Time.N+" minut.");
            Console.ReadLine();
            Dictionary<string,int> inventory = Inventory.Create();
            inventory.Add("klucz",1123);
            foreach (var item in inventory)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}