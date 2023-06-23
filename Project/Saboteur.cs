using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public static bool ComeIn(DifficulityLevel difficulity)
        {
            bool comein = false;
            Random rng = new Random();
            switch (difficulity)
            {
                case DifficulityLevel.Easy:
                    if (rng.Next(10) == 0) { comein = true; break; }
                    comein = false;
                    break;
                case DifficulityLevel.Medium:
                    if (rng.Next(2) == 1) { comein = true; break; }
                    comein = false;
                    break;
                case DifficulityLevel.Hard: 
                    comein = true;
                    break;
            }
            return comein;
        }
    }
}
