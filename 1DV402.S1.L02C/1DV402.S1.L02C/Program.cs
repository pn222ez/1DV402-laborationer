using laboration1_2_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace laboration1_2
{
    class Program
    {
        private const byte max = 79;

        //Kontrollerar om användaren tryckt på Escape, isåfall avslutas programmet, annars försätter programmet med en ny inmatning
        private static bool IsContinuing()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Resource2.Continue_prompt);
            Console.ResetColor();
            Console.WriteLine();
            if (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Läser in ett tal och kontrollerar att det är udda och mellan 1 och maxvärdet
        private static byte ReadOddByte(string prompt = null, byte maxValue = max)
        {

            byte cols = 0;
            bool success = false;
            while (!success)
            {
                Console.Write(prompt);
                string userInput = Console.ReadLine();
                try
                {
                    cols = byte.Parse(userInput);
                    if (cols % 2 != 0 && cols <= maxValue)
                    {
                        success = true;
                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(Resource2.Error_message, maxValue);
                        Console.ResetColor();
                    }
                }
                catch
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(Resource2.Error_message, maxValue);
                    Console.ResetColor();
                }
            }
            return cols;
        }

        //Skriver ut diamanten utifrån antal rader
        private static void RenderDiamond(byte maxCount)
        {
            int asteriskCount = 1;
            int spaceCount = maxCount/2;
            bool condition = false;
            while (asteriskCount != 0)
            {
                for (int i = 0; i < maxCount; i++)
                {
                    RenderRow(spaceCount, asteriskCount);

                    if (condition == false)
                    {
                        asteriskCount = asteriskCount + 2;
                        spaceCount = spaceCount - 1;
                        if (asteriskCount == (maxCount + 2))
                        {
                            condition = true;
                            asteriskCount = asteriskCount - 2;
                            spaceCount = spaceCount + 1;
                        }

                    }
                    if (condition == true)
                    {
                        if (asteriskCount != 1)
                        {
                            asteriskCount = asteriskCount - 2;
                        }
                        else
                        {
                            asteriskCount = asteriskCount - 1;
                            break;
                        }
                        spaceCount = spaceCount + 1;
                    }
                }
            }
        }

        //Skriver ut enskilda rader
        private static void RenderRow(int maxCount, int asteriskCount)
        {
            for (int i = 0; i < maxCount; i++)
            {
                Console.Write(" ");
            }
            for (int j = 0; j < asteriskCount; j++)
            {
                Console.Write("*");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {

            byte cols = 0;
            do
            {
                cols = ReadOddByte(Resource2.Console_message + max + ": ", max);
                RenderDiamond(cols);
            } while (IsContinuing());

        }
    }
}

