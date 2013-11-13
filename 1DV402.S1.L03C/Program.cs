using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration1_3
{
    class Program
    {
        //Skriver ut meddelanden till användaren
        private static void ViewMessage(string prompt, ConsoleColor backgroundColor, ConsoleColor textColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = textColor;
            Console.WriteLine(prompt);
            Console.ResetColor();
        }

        //Kontrollerar om programmet ska fortsätta. Escape avslutar, annan knapp fortsätter
        private static bool IsContinuing()
        {
            ViewMessage("Tryck tangent för ny beräkning. ESC avslutar.", ConsoleColor.Blue, ConsoleColor.White);
            if (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Läser in enskilda löner
        private static int[] ReadSaleries(int count)
        {
            int[] saleries = new int[count];

            for (int i = 0; i < count; i++)
            {
                int salery = ReadInt("Ange lön " + (i + 1) + ": ");
                saleries[i] = salery;
            }
            return saleries;
        }

        //Skriver ut resultaten av beräkningarna
        private static void ViewResults(int[] saleries)
        {
            int median = 0;
            int average = 0;
            int spread = 0;
            int[] saleriesCopy = new int[saleries.Length];
            Array.Copy(saleries, saleriesCopy, saleries.Length);

            median = MyExtensions.Median(saleriesCopy);
            spread = MyExtensions.Dispertion(saleriesCopy);
            average = (int)saleriesCopy.Average();

            Console.WriteLine("-------------------------------\r\n" +
                                "Medianlön:\t{0:C0}\r\n" +
                                "Medellön:\t{1:C0}\r\n" +
                                "Spridning:\t{2:C0}\r\n" +
                                "-------------------------------\r\n", median, average, spread);

            for (int i = 0; i < saleries.Length; i++)
            {
                Console.Write("{0, 25}", saleries[i]);
                if (((i + 1) % 3) == 0)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        //Läser in ett tal och kontrollerar att det är i korrekt format
        private static int ReadInt(string prompt)
        {

            int number = 0;
            string userInput;
            bool success = false;

            while (!success)
            {
                try
                {
                    Console.Write(prompt);
                    userInput = Console.ReadLine();
                    number = int.Parse(userInput);
                    success = true;
                    break;
                }
                catch
                {
                    ViewMessage("Värdet kan inte tolkas som ett tal.", ConsoleColor.Red, ConsoleColor.White);
                }
            }
            return number;
        }

        static void Main(string[] args)
        {
            int numberOfSaleries = 0;
            int[] saleries;
            while (IsContinuing())
            {
                numberOfSaleries = ReadInt("Ange hur många löner du vill ha beräknade: ");
                if (numberOfSaleries <= 1)
                {
                    ViewMessage("Fler än 1 lön krävs för att göra en beräkning", ConsoleColor.Red, ConsoleColor.White);
                }
                else
                {
                    saleries = ReadSaleries(numberOfSaleries);
                    ViewResults(saleries);
                }
            }
        }
    }
}
