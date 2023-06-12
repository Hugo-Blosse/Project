using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Crewmates
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        private bool sabo;
        public bool Sabo
        {
            get { return sabo; }
        }
        public Crewmates(string crewName, bool isSaboteur)
        {
            name = crewName;
            sabo = isSaboteur;
        }
        public static void Talk(Crewmates crew, int difficulity)
        {
            switch(crew.name)
            {
                case "Anna":
                    if (difficulity != 3)
                    {
                        Console.WriteLine(crew.name + ": W pokoju z lewej strony zespsuł się zawór...");
                        Console.Write(crew.Name + ": Chyba potrzeba "); Puzzles.Tips("klucza francuskiego"); Console.WriteLine(", żeby to naprawić...");
                        Console.WriteLine("Kliknij enter, żeby kontynuować.");
                        Console.ReadLine();
                        break;
                    }
                    Console.WriteLine("...");
                    break;
                case "Bob":
                    if (difficulity != 3)
                    {
                        Console.WriteLine(crew.Name + ": W pokoju przed tobą szczur przegryzł kable. Zająłem się tym, ale "); Puzzles.Tips("gryzoń dalej tam jest."); Console.WriteLine("");
                        Console.WriteLine("Kliknij enter, żeby kontynuować.");
                        Console.ReadLine();
                    }
                    Console.WriteLine("...");
                    break;
                case "Clobert":
                    if (difficulity != 3)
                    {
                        Console.WriteLine(crew.Name + ": W pokoju z prawej strony mamy przeciek, zatamujesz go prawda?");
                        Console.WriteLine("Kliknij enter, żeby kontynuować.");
                        Console.ReadLine();
                    }
                    Console.WriteLine("...");
                    break;
            }
        }
    }
}
