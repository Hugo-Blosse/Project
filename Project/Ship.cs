using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Ship
    {
        private int dif;
        public int Dif
        {
            get { return dif; }
            set { dif = value; }
        }
        private string place;
        public string Place
        {
            get { return place; }
            set
            {
                switch (value)
                {
                    case "1":
                        place = "Włochy";
                        break;
                    case "2":
                        place = "Niemcy";
                        break;
                    case "3":
                        place = "Syberia";
                        break;
                }
            }
        }
        public static void Drawing()
        {
            Console.WriteLine(@"     ~     ~     ~    ,-#-,  ~");
            Console.WriteLine(@"   ~     ~      ~     |    \ ~");
            Console.WriteLine(@"  ~     .,------------'     `----. ~   ~");
            Console.WriteLine(@" ~ ~~ +-                          \ ~");
            Console.WriteLine(@"~ ~~ +-                           / ~ ");
            Console.WriteLine(@" ~~ ~ +-.,_______________________/   ~");
        }
    }
}
