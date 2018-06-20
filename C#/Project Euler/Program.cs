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
            var problemMap = new Dictionary<string, Func<long>>()
            {
                { ((int) ProblemMapping.PE0001).ToString(), () => e.PE0001() },
                { ((int) ProblemMapping.PE0002).ToString(), () => e.PE0002() },
                { ((int) ProblemMapping.PE0003).ToString(), () => e.PE0003() },
                { ((int) ProblemMapping.PE0004).ToString(), () => e.PE0004() },
                { ((int) ProblemMapping.PE0005).ToString(), () => e.PE0005() },
                { ((int) ProblemMapping.PE0006).ToString(), () => e.PE0006() },
                { ((int) ProblemMapping.PE0007).ToString(), () => e.PE0007() },
                { ((int) ProblemMapping.PE0008).ToString(), () => e.PE0008() },
                { ((int) ProblemMapping.PE0009).ToString(), () => e.PE0009() },
                { ((int) ProblemMapping.PE0010).ToString(), () => e.PE0010() },
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
                    int i = 1;
                    foreach (Func<long> f in problemMap.Values) { Console.WriteLine($"{ i++ }: { f() }"); }
                }
                else if (!Regex.IsMatch(s, @"^\d+$"))
                {
                    Console.WriteLine("Unrecognized character string.");
                    continue;
                }
                else if (Enum.IsDefined(typeof(ProblemMapping), Convert.ToInt32(s)))
                {
                    Console.WriteLine($"{ s }: { problemMap[s]() }");
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
