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
            }
            return str;
        }

        public Inventory() { list = new List<Item>(); }  //foreach(Item it in inventory.List) item.ToString()
    }
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return "Nazwa: " + Name + " Opis: " + Description;
        }

        public override bool Equals(object? obj)                        //override = upewnij sie, ze to jest przeladowanie metody, 
        {                                                               //przeladowanie => nadpisanie poprzedniej metody., chyba ze base.EQUALS(OBJ)
            if (obj == null || !GetType().Equals(obj.GetType())) 
            {
                return false;
            }
            else 
            {
                Item item = (Item)obj;
                return Name.Equals(item.Name) && Description.Equals(item.Description);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name.GetHashCode(), Description.GetHashCode());
        }

        public Item() 
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
