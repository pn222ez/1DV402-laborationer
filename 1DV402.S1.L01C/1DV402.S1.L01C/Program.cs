using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration1_1
{
    class Program
    {
        private static string[] notes = { "500-lappar:     ", "100-lappar:     ", "20-lappar:      ", "5-kronor:       ", "1-kronor:       " };

        //Skriver ut kvitto
        private static void ViewReceipt(double subtotal, double roundingOffAmount, double total, uint cash, uint change, string[] notes, uint[] denominations)
        {
            Console.WriteLine(Resource1.Receipt, subtotal, roundingOffAmount, total, cash, change);

            for (int i = 0; i < denominations.Length; i++)
            {
                if (denominations[i] > 0)
                {
                    Console.WriteLine("{0}{1}", notes[i], denominations[i]);
                }
            }
        }

        //Skriver ut meddelanden till användaren
        private static void ViewMessage(string message, bool isError = false)
        {
            if (isError)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine(message);
            Console.ResetColor();
        }

        //Läser in ett totalsumman och kontrollerar att den är korrekt angiven 
        private static double ReadPositiveDouble(string prompt)
        {
            bool success = false;
            string inputCost;
            double subtotal = 0;

            while (!success)
            {
                Console.Write(prompt);
                inputCost = Console.ReadLine();
                try
                {
                    subtotal = double.Parse(inputCost);
                    if (subtotal >=1)
                    {
                        success = true;
                        break;
                    }
                    else
                    {
                        ViewMessage(Resource1.To_small_amount, true);
                    }
                }
                catch
                {
                    ViewMessage(Resource1.Not_valid_number, true);

                }
            }

            return subtotal;
        }

        //Läser in vad kunden betalat och kontrollerar att det är korrekt angivet
        static uint ReadUint(double total, string inputMessage)
        {
            bool success = false;
            uint givenMoney = 0;
            string inputGiven;

            while (!success)
            {
                Console.Write(inputMessage);
                inputGiven = Console.ReadLine();
                try
                {
                    givenMoney = uint.Parse(inputGiven);
                    if (givenMoney >= total)
                    {
                        success = true;
                        break;
                    }
                    else
                    {
                        ViewMessage(Resource1.Given_money_smaller_than_cost, true);
                    }
                }
                catch
                {
                    ViewMessage(Resource1.Not_valid_whole_number, true);
                }
            }


            return givenMoney;
        }

        //Delar upp växeln i de valörer som skickas till metoden
        static uint[] SplitIntoDenominations(uint change, uint[] denominations)
        {
            uint remainingMoney = 0;

            uint[] changeContainer = new uint[denominations.Length];
            remainingMoney = change;

            for (int i = 0; i < denominations.Length; i++)
            {
                changeContainer[i] = remainingMoney / denominations[i];
                remainingMoney = remainingMoney % denominations[i];
            }
            return changeContainer;
        }

        static void Main(string[] args)
        {
            uint given = 0;
            uint change = 0;
            double total;
            uint[] splittedDenominations;
            double roundingOffAmount = 0;
            double subtotal = 0;
            uint[] denominations = new uint[5] {500, 100, 20, 5, 1 };

            do
            {
                subtotal = ReadPositiveDouble(Resource1.Cost_prompt);
                total = (int)Math.Round(subtotal);
                roundingOffAmount = total - subtotal;
                roundingOffAmount = Math.Round(roundingOffAmount, 2);
                given = ReadUint(subtotal, Resource1.Given_money_prompt);
                change = given - (uint)subtotal;
                splittedDenominations = SplitIntoDenominations(change, denominations);
                ViewReceipt(total, roundingOffAmount, subtotal, given, change, notes, splittedDenominations);
                ViewMessage(Resource1.Continue_prompt);

            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
}
