using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Inventory
    {
        private List<Item> list;

        public List<Item> List
        {
            get { return list; }
        }

        public void AddItem(Item item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
            }
        }

        public override string ToString()
        {
            string str = string.Empty;

            int num = 1;  
            foreach(Item i in list)
            {
                
                str += "" + num + ": " + i.ToString() +"\n";
                num++;
            }
            return str;
        }

        public Inventory() { list = new List<Item>(); }
    }
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return "Nazwa: " + Name + " Opis: " + Description;
        }
    }
}
