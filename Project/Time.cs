using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Project
{
    class Time
    {
        private static System.Timers.Timer timer1;
        private static System.Timers.Timer timer2;
        private static int n = 0;
        public static int N
        {
            get { return n; }
            set { n = value; }
        }
        private static int m = 2000;
        public static void StartTimer(int difficulity)
        {
            timer1 = new System.Timers.Timer((1200000/difficulity)+m*((20/difficulity)));
            timer1.Elapsed += TimeEnd;
            timer1.AutoReset = false;
            timer1.Enabled = true;

            timer2 = new System.Timers.Timer(60000+m);
            timer2.Elapsed += Reminder;
            timer2.AutoReset = true;
            timer2.Enabled = true;

            N = 20 / difficulity;
        }
        private static void TimeEnd(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Czas dobiegł końca. Nie udało ci się dotrzeć do celu.");
            Environment.Exit(0);
        }
        private static void Reminder(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("\nPozostały czas: " + (N) + " min.");
            N -= 1;
            Thread.Sleep(2000);
        }
    }
}
