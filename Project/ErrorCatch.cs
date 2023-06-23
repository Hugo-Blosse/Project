﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class ErrorCatch
    {
        public static int Error4(string s) 
        {
            int x = 1;
            int value = 0;
            while (x != 0)
            {
                Console.WriteLine(s);
                string val = Console.ReadLine() + "";
                switch (val)
                {
                    case "1":
                        x = 0;
                        value = 1;
                        break;
                    case "2":
                        x = 0;
                        value = 2;
                        break;
                    case "3":
                        x = 0;
                        value = 3;
                        break;
                    case "4":
                        x = 0;
                        value = 4;
                        break;
                    default: 
                        Console.WriteLine("Nieprawidłowa wartość");
                        break;
                }
            }
            Console.Clear();
            return value;
        }
        public static int Error3(string s) 
        {
            int x = 1;
            int value = 0;
            while (x != 0)
            {
                Console.WriteLine(s);
                string val = Console.ReadLine() + "";
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
        public static int Error2(string s) 
        {
            int x = 1;
            int val = 0;
            while (x != 0)
            {
                Console.WriteLine(s);
                string value = Console.ReadLine() + "";
                switch(value)
                {
                    case "1":
                        val = 1;
                        x = 0;
                        break;
                    case "2":
                        val = 2;
                        x = 0;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa wartość");
                        break;
                }
            }
            Console.Clear();
            return val;
        }
    }
}
