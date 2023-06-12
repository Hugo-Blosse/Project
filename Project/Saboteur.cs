using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Saboteur
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        public Saboteur (string saboName)
        {
            name = saboName;
        }
        public static bool ComeIn(int difficulity)
        {
            bool comein;
            Random rng = new Random();
            switch (difficulity)
            {
                case 1:
                    if (rng.Next(10) == 0) { comein = true; break; }
                    comein = false;
                    break;
                case 2:
                    if (rng.Next(2) == 1) { comein = true; break; }
                    comein = false;
                    break;
                default: 
                    comein = true;
                    break;
            }
            return comein;
        }
    }
}
