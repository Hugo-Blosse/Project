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
        public static void Talk(int name)
        {
            switch(name)
            {
                case 1:
                    Console.WriteLine("W pokoju z lewej strony zespsuł się zawór...\nWpisz cokolwiek, żeby kontynuować.");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("W pokoju przed tobą szczur przegryzł kable. Zająłbym się tym, ale zbyt wygodnie mi się siedzi.\nWpisz cokolwiek, żeby kontynuować.");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("W pokoju z prawej strony mamy przeciek, zatamujesz go prawda?\nWpisz cokolwiek, żeby kontynuować.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
