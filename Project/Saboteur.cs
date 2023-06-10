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
        private int diff;
        public int Diff 
        {
            get { return diff; }
        }
        public Saboteur (string saboName, int saboDiff)
        {
            name = saboName;
            diff = saboDiff;
        }
    }
}
