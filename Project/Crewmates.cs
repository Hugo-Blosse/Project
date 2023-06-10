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

    }
}
