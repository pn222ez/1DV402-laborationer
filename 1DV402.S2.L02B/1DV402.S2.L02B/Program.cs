﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L02B
{
    class Program
    {
        //Låter ett AlarmClock-objekt gå i önskat antal minuter. Om TickTock returnerar true går larmet.
        private static void Run(AlarmClock alarmClock, int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                if (alarmClock.TickTock())
                {
                    Console.WriteLine(alarmClock.ToString() + " BEEEEP!!!");
                }
                else
                {
                    Console.WriteLine(alarmClock.ToString());
                }
            }
        }
        //Presenterar ett felmeddelande i rött med önskat meddelande.
        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        //Skriver ut rubrik och innehåll med ett sträck överst.
        private static void ViewTestHeader(string header, string body)
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(header);
            Console.WriteLine(body);
        }

        static void Main(string[] args)
        {
            //Test 1
            AlarmClock ac = new AlarmClock();
            ViewTestHeader("Test 1.", "Test av standardkonstruktorn.");
            Console.WriteLine(ac.ToString());

            //Test 2
            AlarmClock ac2 = new AlarmClock(9, 42);
            ViewTestHeader("Test 2.", "Test av konstruktorn med två parametrar. (9,42)");
            Console.WriteLine(ac2.ToString());
           
            //Test 3
            AlarmClock ac3 = new AlarmClock(13, 24, 7, 35);
            ViewTestHeader("Test 3.", "Test av konstruktorn med fyra parametrar. (13,24,7,35)");
            Console.WriteLine(ac3.ToString());
           
            //Test 4
            ac3.Hour = 23;
            ac3.Minute = 58;
            ViewTestHeader("Test 4.", "Ställer befintligt Alarm clock-objekt till 23:58 och låter den gå i 13 minuter.");
           
            Run(ac3, 13);
           
           
            //Test 5
            ac3.Hour = 6;
            ac3.Minute = 12;
            ac3.AlarmHour = 6;
            ac3.AlarmMinute = 15;
            ViewTestHeader("Test 5.", "Ställer befintligt Alarm clock-objekt till 6:12 och alarmtiden till 6:15 och låter den gå i 6 minuter.");
            Run(ac3, 6);
           
            //Test 6
            ViewTestHeader("Test 6.", "Testar egenskaperna så att undantagen kastas när tis och alarmtid ställs till felaktiga värden.");
            try
            {
                ac3.Hour = 25;
           
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }
           
            try
            {
                ac3.Minute = 89;
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }
           
            try
            {
                ac3.AlarmHour = 65;
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }
           
            try
            {
                ac3.AlarmMinute = -21;
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }
           
            //Test 7
            ViewTestHeader("Test 7.", "Testar konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.");
            try
            {
                AlarmClock ac4 = new AlarmClock(27,19);
            }
            catch(Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }
           
            try
            {
                AlarmClock ac4 = new AlarmClock(19, 64);
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }
           
            try
            {
                AlarmClock ac4 = new AlarmClock(23, 19, 55, 18);
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }
           
            try
            {
                AlarmClock ac4 = new AlarmClock(23, 19, 6, 81);
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }
        }
    }
}
