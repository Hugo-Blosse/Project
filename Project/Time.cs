﻿using System;
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
        public static void StartTimer(int difficulity)
        {
            timer1 = new System.Timers.Timer((720000/difficulity)+2000*((12/difficulity)));
            timer1.Elapsed += TimeEnd;
            timer1.AutoReset = false;
            timer1.Enabled = true;

            timer2 = new System.Timers.Timer(60000+2000);
            timer2.Elapsed += Reminder;
            timer2.AutoReset = true;
            timer2.Enabled = true;

            N = 12 / difficulity;
        }
        private static void TimeEnd(object source, ElapsedEventArgs e)
        {
            Console.Clear();
            Menu.Ending4();
        }
        private static void Reminder(object source, ElapsedEventArgs e)
        {
            N -= 1;
            if ( N > 0) Puzzles.Tips("\nPozostały czas: " + (N) + " min.");
            Console.WriteLine();
            Thread.Sleep(2000);
        }
    }
}
