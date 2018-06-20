using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_Euler
{
    class Program
    {
        /// <summary>
        /// Currently runs down the Project Euler problems sequentially.
        /// </summary>
        /// <param name="args">Currently nonfunctional default parameter.</param>
        static void Main(string[] args)
        {
            Euler e = new Euler();
            var problemMap = new Dictionary<string, Action>()
            {
                { ((int) ProblemMapping.PE0001).ToString(), () => e.PE0001(true) },
                { ((int) ProblemMapping.PE0002).ToString(), () => e.PE0002(true) },
                { ((int) ProblemMapping.PE0003).ToString(), () => e.PE0003(true) },
                { ((int) ProblemMapping.PE0004).ToString(), () => e.PE0004(true) },
                { ((int) ProblemMapping.PE0005).ToString(), () => e.PE0005(true) },
                { ((int) ProblemMapping.PE0006).ToString(), () => e.PE0006(true) },
                { ((int) ProblemMapping.PE0007).ToString(), () => e.PE0007(true) },
                { ((int) ProblemMapping.PE0008).ToString(), () => e.PE0008(true) },
                { ((int) ProblemMapping.PE0009).ToString(), () => e.PE0009(true) },
                { ((int) ProblemMapping.PE0010).ToString(), () => e.PE0010(true) },
            };
            string s;
            while (true)
            {
                Console.WriteLine("Type the number of the Project Euler problem that you want to execute, type \"all\" without the quotes to have them all execute sequentially, or type \"exit\" without the quotes to exit the program.");
                s = Console.ReadLine();
                if (s == "exit")
                {
                    return;
                }
                else if (s == "all")
                {
                    foreach(Action a in problemMap.Values) { a(); Console.WriteLine(); }
                }
                else if (!Regex.IsMatch(s, @"^\d+$"))
                {
                    Console.WriteLine("Unrecognized character string.");
                    continue;
                }
                else if (Enum.IsDefined(typeof(ProblemMapping), Convert.ToInt32(s)))
                {
                    Console.Write($"{ s }: ");
                    problemMap[s]();
                    Console.WriteLine();
                }
                else
                { //invalid number
                    Console.WriteLine("Unsupported problem number.");
                    continue;
                }
            }
        }
    }
}
