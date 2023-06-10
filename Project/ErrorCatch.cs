using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class ErrorCatch
    {
        public static string ErrorMenu(string s) 
        {
            int x = 1;
            string val = "0";
            while (x != 0)
            {
                Console.WriteLine(s);
                val = Console.ReadLine();
                if (val == "1" | val == "2" | val == "3" | val == "4") { x = 0; }
                else { Console.WriteLine("Nieprawidłowa wartość"); }
            }
            Console.Clear();
            return val;
        }
        public static int ErrorDif(string s) 
        {
            int x = 1;
            int value = 0;
            while (x != 0)
            {
                string val;
                Console.WriteLine(s);
                val = Console.ReadLine();
                switch (val) 
                {
                    case "1":
                        value = 1;
                        x = 0;
                        break;
                    case "2":
                        value = 2;
                        x = 0;
                        break;
                    case "3":
                        value = 3;
                        x = 0;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa wartość");
                        break;
                }
            }
            Console.Clear();
            return value;
        }
    }
}
