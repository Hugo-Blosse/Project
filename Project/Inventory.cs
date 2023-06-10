using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Inventory
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Inventory(string name, string description) 
        {
            Name = name;
            Description = description;
        }
        public void Info() 
        {
            Console.WriteLine(Name + Description);
        }
    }
}
