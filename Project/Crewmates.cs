using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Crewmates
    {
        public Names Name 
        {
            get; set;
        }
        private bool sabo;
        public bool Sabo
        {
            get { return sabo; }
        }
        public Crewmates(Names name, bool isSaboteur)
        {
            Name = name;
            sabo = isSaboteur;
        }
        public static void Talk(Crewmates crew, Saboteur saboteur)
        {
            switch(crew.Name)
            {
                case Names.Aurelia:
                    if (crew.Name.ToString() == saboteur.Name && Fight.once) { Console.WriteLine(crew.Name + " nie może już rozmawiać."); Thread.Sleep(2000); break; }
                    Console.WriteLine(crew.Name + ": W pokoju z lewej strony zespsuł się zawór..."); ;
                    Console.Write(crew.Name + ": Chyba potrzeba "); Puzzles.Tips("klucza francuskiego"); Console.WriteLine(", żeby to naprawić...");
                    Console.WriteLine("Mam nadzieję, że dopłyniemy do portu, mimo że ster nie działa...");
                    Console.WriteLine("Kliknij enter, żeby kontynuować.");
                    Console.ReadLine();
                    break;
                case Names.Bob:
                    if (crew.Name.ToString() == saboteur.Name && Fight.once) { Console.WriteLine(crew.Name + " nie może już rozmawiać."); break; }
                    if (Puzzles.RatHappy) 
                    { 
                        Console.Write(crew.Name + ": Zaprzyjaźniłeś się z szczurem w magazynie? Dobrze, zwięrzątko pokładowe, może być przydatne.\n"); Puzzles.Tips(crew.Name+": Możesz mu dać trochę sera"); Console.WriteLine("");
                        if (!Menu.Inventory.List.Any(item => item.Name == "Ser")) { Menu.Inventory.AddItem(new Item { Name = "Ser", Description = "Pachnie znośnie" }); Console.WriteLine("Otrzymałeś ser!"); }
                        Console.WriteLine("Kliknij enter, żeby kontynuować.");
                    Console.ReadLine();
                        break;
                    }
                    Console.WriteLine(crew.Name + ": W magazynie tobą szczur przegryzł kable. Zająłem się tym, ale ");Puzzles.Tips("gryzoń dalej tam jest.");Console.WriteLine(" Przyjdź do mnie jak sobie z nim uporasz.");
                    Console.WriteLine("Kliknij enter, żeby kontynuować.");
                    Console.ReadLine();
                    break;
                case Names.Clobert:
                    if (crew.Name.ToString() == saboteur.Name && Fight.once) { Console.WriteLine(crew.Name + " nie może już rozmawiać."); break; }
                    if (Puzzles.Tip)
                    {
                        switch(Puzzles.Help)
                        {
                            case 0:
                                Console.WriteLine(crew.Name + ": Hmm... może chodzi o coś z liczbą samogłosek? I coś z rośnięciem...\nPamiętaj, że musisz wpisać numery przy wyrazach w kolejności, nie liczbę samogłosek.");
                                Console.WriteLine("Kliknij enter, żeby kontynuować.");
                                Console.ReadLine();
                                break;
                            case 1:
                                Console.WriteLine(crew.Name + ": Hmm... może chodzi o coś z długością? I coś maleje...\nPamiętaj, że musisz wpisać numery przy wyrazach w kolejności, nie liczbę spółgłosek.");
                                Console.WriteLine("Kliknij enter, żeby kontynuować.");
                                Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine(crew.Name + ": Hmm... może chodzi o coś z spółgłoskami?");
                                Console.WriteLine("Kliknij enter, żeby kontynuować.");
                                Console.ReadLine();
                                break;
                        }
                        break;
                    }
                    Console.WriteLine(crew.Name + ": W pokoju z prawej zablokował się właz, a nie pamiętam kodu. Otworzysz go, prawda?");
                    Console.Write(crew.Name + ": Zapisałem go na kartce i zostawiłem "); Puzzles.Tips("w małym pokoju z zaworem."); Console.WriteLine("");
                    Console.WriteLine("Kliknij enter, żeby kontynuować.");
                    Console.ReadLine();
                    break;
            }
        }
    }
}