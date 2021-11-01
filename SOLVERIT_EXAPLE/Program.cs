using CollatzConj;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOLVERIT_EXAPLE
{
    class Program
    {
        static void Main(string[] args)
        {
            //Size set for entering the console
            int bufSize = 1000;
            Stream inStream = Console.OpenStandardInput(bufSize);
            Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));

            CollatzConjecture collatzConjecture = new CollatzConjecture();
            ConsoleKey response;
            do
            {
                Console.WriteLine("Write the number for the calculation collatz Conjecture sequence:");
                string input = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("The calculation is in progress . . .");
                Console.ResetColor();

                ValNum valNum = collatzConjecture.GetCalculationConjectureAsync(input).Result;

                if (valNum.InputNumbers.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please insert an decimal system number");
                    Console.ResetColor();
                    response = ConsoleKey.Enter;
                }
                else
                {
                    PrintValNum(valNum);

                    Console.Write("Press [y/n] to exit the application");
                    response = Console.ReadKey(false).Key;
                    if (response != ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                    }
                }
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);
        }


        /// <summary>
        /// Prints the calculation values
        /// </summary>
        /// <param name="valNum"></param>
        static void PrintValNum(ValNum valNum)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("n: {0}", valNum.InputNumbers[0]);
            Console.Write("(the sequence : ");

            for (int i = 0; i < valNum.InputNumbers.Count; i++)
            {
                if (i == valNum.InputNumbers.Count - 1)
                {
                    Console.Write("{0} ", valNum.InputNumbers[i]);
                }

                else
                {
                    Console.Write("{0}, ", valNum.InputNumbers[i]);
                }
            }

            Console.Write(")");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Number of 3k+1 operations: {0}", valNum.LNumbers.Count);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Number of 2k operations: {0}", valNum.SNumbers.Count);

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Maximum member: {0}", valNum.MaxNumbers);

            Console.WriteLine(Environment.NewLine);
            Console.ResetColor();
        }
    }
}
