﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EulerUtils;

namespace Project_Euler
{
    public class Euler
    {
        private void WriteToConsole(long l)
        {
            Console.Write(l);
        }

        private void WriteToConsole(int i)
        {
            Console.Write(i);
        }

        // Problem 1: Multiples of 3 and 5
        // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
        //
        // Find the sum of all the multiples of 3 or 5 below 1000.
        /// <summary>
        /// This implementation is a straightforward loop summing the multiples of 3 and 5 under the given limit.
        /// </summary>
        /// <param name="isDelegate">A bool used to tell if the answer should be written to the console.</param>
        /// <param name="limit">Specifies the upper limit to sum against, defaulted to 1000.</param>
        /// <returns>Returns the sum of all the multiples of 3 or 5 below the given limit.</returns>
        public int PE0001(bool isDelegate = false, int limit = 1000)
        { //we can have a running total that aggregates the numbers as we find them
            int sum = 0;
            for (int i = 1; i < limit; i++)
            {
                if ((i % 3 != 0) && (i % 5 != 0))
                { //continue the loop if not divisible by either 5 or 3
                    continue;
                }
                sum += i; //add the number to the running total
            }
            if (isDelegate) { WriteToConsole(sum); }
            return sum;
        }

        // Problem 2: Even Fibonacci numbers
        // Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
        //
        // 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        //
        // By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
        /// <summary>
        /// For this problem, we're summing all of the even Fibonacci numbers under a given limit.
        /// I'm using a recursive Fibonacci method.
        /// </summary>
        /// <param name="isDelegate">A bool used to tell if the answer should be written to the console.</param>
        /// <param name="limit">The ceiling that the Fibonacci sequence will be evaluated up to.</param>
        /// <returns>Returns the sum of all even Fibonacci numbers under the given limit.</returns>
        public int PE0002(bool isDelegate = false, int limit = 4000000)
        {
            int sum = 0, result = 0;
            uint i = 0;
            while ((result = NumberUtils.Fibonacci(i++)) < limit) //we're assigning result the next Fibonacci number in the sequence and keeping track of the sequence with i
            { //we're looping over the odd Fibonacci numbers
                if (result % 2 != 0) { continue; }
                sum += result; //add the even Fibonacci number to the running total
            }
            if (isDelegate) { WriteToConsole(sum); }
            return sum;
        }

        // Problem 3: Largest prime factor
        // The prime factors of 13195 are 5, 7, 13 and 29.
        //
        // What is the largest prime factor of the number 600851475143 ?
        /// <summary>
        /// For this problem, we're taking a given number and dividing it down to 1, starting with the smallest prime factors and working our way up.
        /// </summary>
        /// <param name="isDelegate">A bool used to tell if the answer should be written to the console.</param>
        /// <param name="n">The number from which we're deriving its prime factors.</param>
        /// <returns>Returns the largest prime factor froma given n.</returns>
        public long PE0003(bool isDelegate = false, long n = 600851475143)
        {
            var factor = NumberUtils.GetPrimeFactors(n).Max();
            if (isDelegate) { WriteToConsole(factor); }
            return factor;
        }

        // Problem 4: Largest palindrome product
        // A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
        //
        // Find the largest palindrome made from the product of two 3-digit numbers.
        /// <summary>
        /// For this problem, we're making a list of all palindromic numbers that can be gotten by multiplying two 3-digit numbers together, then returning the biggest one.
        /// </summary>
        /// <param name="isDelegate">A bool used to tell if the answer should be written to the console.</param>
        /// <returns>Returns the largest palindrome made from the product of two 3-digit numbers.</returns>
        public int PE0004(bool isDelegate = false)
        {
            List<int> PalindromeList = new List<int>();
            for (int i = 100; i < 1000; ++i)
            {
                for (int j = 100; j < 1000; ++j)
                {
                    if (NumberUtils.IsPalindromeProduct(i, j))
                    {
                        PalindromeList.Add(i * j);
                    }
                }
            }
            if (isDelegate) { WriteToConsole(PalindromeList.Max()); }
            return PalindromeList.Max();
        }

        // Problem 5: Smallest multiple
        // 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        //
        // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        /// <summary>
        /// For this problem, we're counting by 20s until we find a number that's evenly divisible by numbers 11 through 19, then we return that number.
        /// </summary>
        /// <param name="isDelegate">A bool used to tell if the answer should be written to the console.</param>
        /// <returns>Returns the smallest positive number that is evenly divisible by all of the numbers from 1 to 20.</returns>
        public long PE0005(bool isDelegate = false)
        {
            for (long l = 20; l < long.MaxValue; l += 20)
            { //we can omit checking for the smaller numbers... e.g. any number with 18 as a factor will also have 9 as a factor
                if (l % 19 == 0 && l % 18 == 0 && l % 17 == 0 && l % 16 == 0 && l % 15 == 0 &&
                    l % 14 == 0 && l % 13 == 0 && l % 12 == 0 && l % 11 == 0)
                {
                    if (isDelegate) { WriteToConsole(l); }
                    return l;
                }
            }
            return -1;
        }

        // Problem 6: Sum square difference
        // The sum of the squares of the first ten natural numbers is,
        //
        // 1^2 + 2^2 + ... + 10^2 = 385
        // The square of the sum of the first ten natural numbers is,
        //
        // (1 + 2 + ... + 10)^2 = 552 = 3025
        // Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
        //
        // Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
        /// <summary>
        /// For this problem, we're making a list of the natural numbers up through a given limit, then we're finding the difference between sum of the squares of the natural numbers up through the given limit and the square of the sum of those same numbers.
        /// </summary>
        /// <param name="isDelegate">A bool used to tell if the answer should be written to the console.</param>
        /// <param name="limit">The limit through which we're summing the natural numbers, defaults to 100.</param>
        /// <returns>Returns the difference between the sum of the squares of the first natural numbers starting with 1 going through the given limit and the square of the sum of those same numbers.</returns>
        public int PE0006(bool isDelegate = false, int limit = 100)
        {
            List<int> NaturalNumberList = new List<int>();
            for (int i = 1; i <= limit; ++i)
            { //we're just making a list from 1 through the limit of all the natural numbers
                NaturalNumberList.Add(i);
            }
            var difference = Convert.ToInt32((Math.Pow(NaturalNumberList.Sum(), 2)) - (NaturalNumberList.Select(n => Math.Pow(n, 2)).Sum()));
            if (isDelegate) { WriteToConsole(difference); }
            return difference;
        }

        // Problem 7: 10001st prime
        // By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
        //
        // What is the 10 001st prime number?
        /// <summary>
        /// For this, we're just generating through all of the prime numbers and evaluating them as their cardinal values, returning the value at the cardinal position given by the parameter.
        /// </summary>
        /// <param name="isDelegate">A bool used to tell if the answer should be written to the console.</param>
        /// <param name="x">The cardinal value of the prime to return, defaults to 10001.</param>
        /// <returns>Returns the cardinal x-valued prime number.</returns>
        public long PE0007(bool isDelegate = false, int x = 10001)
        {
            var prime = NumberUtils.GetCardinalPrimeNumber(x);
            if (isDelegate) { WriteToConsole(prime); }
            return prime;
        }

        // Problem 8: Largest product in a series
        // The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
        //
        // --Data in Data/Problem8.txt
        //
        // Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
        /// <summary>
        /// For this problem, I think it makes the most sense to treat the number as a string and do indiviual operations on the characters in that string.
        /// I opted for a LINQ-based approach. I'm familiar with transforming data using LINQ methods, and wanted to exercise that here.
        /// </summary>
        /// <param name="isDelegate">A bool used to tell if the answer should be written to the console.</param>
        /// <param name="s">The path for the file where the number (string) is located, defaulted to {ProjectPath}\Data\Problem8.txt.</param>
        /// <param name="numOfChar">The number of characters to evaluate as a substring, defaulted to 13.</param>
        /// <returns>Returns the maximum-value integer received when multiplying all possible 13-length substrings of the given input (data from s).</returns>
        public long PE0008(bool isDelegate = false, string s = "..\\..\\Data\\Problem8.txt", int numOfChar = 13)
        { //load the 1000-digit number from the problem into memory
            s = System.IO.File.ReadAllText(s); //this line of code should never make it into a produiction environment, but here it's a nice shortcut to reuse variables
            var max = (from i in Enumerable.Range(0, s.Length)
                       from j in Enumerable.Range(0, s.Length - i + 1)
                       where j == numOfChar
                       select s.Substring(i, j)) //this portion is iterating over all possible substrings having numOfChar length and returning them all as IEumerable<string>
                        .Select(s1 => s1 //we're going to be doing something specific to each string
                            .Select(c => (long)Char.GetNumericValue(c)) //we're going to convert each character in the string to its numeric value
                                .Aggregate((long)1, (x, y) => x * y)) //we're multiplying them all together
                                    .Max(); //from all of the 13-digit substrings, we're returning the greatest when multiplying the individual characters
            if (isDelegate) { WriteToConsole(max); }
            return max;
        }

        // Problem 9: Special Pythagorean triplet
        // A Pythagorean triplet is a set of three natural numbers, a < b < c, for which
        //
        // a^2 + b^2 = c^2
        // For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
        //
        // There exists exactly one Pythagorean triplet for which a + b + c = 1000.
        // Find the product abc.
        /// <summary>
        /// I opted for a very straightforward algorithm. We're just iterating a, b, and c from 1 up through the given limit and performing the proper checks.
        /// This is inefficient, even for a brute force algorithm, and is not recommended for large values of limit.
        /// </summary>
        /// <param name="isDelegate">A bool used to tell if the answer should be written to the console.</param>
        /// <param name="limit">The right side of the equation a + b + c = limit.</param>
        /// <returns>Returns the product of the three natural numbers that both are in a Pythagorean triplet and add together to the given limit.</returns>
        public int PE0009(bool isDelegate = false, int limit = 1000)
        { //all things considered, this isn't efficient, but with a small limit, it doesn't pose a problem
            for (int a = 1; a < limit; ++a)
            {
                for (int b = 1; b < limit; ++b)
                {
                    for (int c = 1; c < limit; ++c)
                    {
                        if (a + b + c != limit)
                        {
                            continue;
                        }
                        if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
                        { //since we're looking for the exact answer for the above check, we're done when this is true
                            if (isDelegate) { WriteToConsole(a * b * c); }
                            return a * b * c;
                        }
                    }
                }
            }
            return -1; //for syntax purposes; also potentially if something goes wrong
        }

        // Problem 10: Summation of primes
        // The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
        //
        // Find the sum of all the primes below two million.
        /// <summary>
        /// For this problem, I utilize a Sieve of Eratosthenes to find all primes under a given limit and then sum them.
        /// </summary>
        /// <param name="isDelegate">A bool used to tell if the answer should be written to the console.</param>
        /// <param name="limit">The upper limit to find primes through.</param>
        /// <returns>Returns </returns>
        public long PE0010(bool isDelegate = false, int limit = 2000000)
        { //we're calling this method, which returns a full list of primes under a given limit, and summing it
            var sum = NumberUtils.ListPrimes(limit).Sum();
            if (isDelegate) { WriteToConsole(sum); }
            return sum;
        }
    }
    
    //A new enum should be added for each new Euler problem.
    /// <summary>
    /// An enum to map the Euler problem number to the method name, with the description as the title of the problem.
    /// </summary>
    public enum ProblemMapping
    { //we're beginning all of these with P because some of them 
        [Description("Multiples Of 3 And 5")]
        PE0001 = 1,
        [Description("Even Fibonacci Numbers")]
        PE0002 = 2,
        [Description("Largest Prime Factor")]
        PE0003 = 3,
        [Description("Largest Palindrome Product")]
        PE0004 = 4,
        [Description("Smallest Multiple")]
        PE0005 = 5,
        [Description("Sum Square Difference")]
        PE0006 = 6,
        [Description("10001st Prime")]
        PE0007 = 7,
        [Description("Largest Product In A Series")]
        PE0008 = 8,
        [Description("Special Pythgorean Triplet")]
        PE0009 = 9,
        [Description("Summation Of Primes")]
        PE0010 = 10,
    }
}