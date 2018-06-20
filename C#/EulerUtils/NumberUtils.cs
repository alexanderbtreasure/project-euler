using System;
using System.Collections.Generic;
using System.Linq;

namespace EulerUtils
{
    /// <summary>
    /// A static library for numeric manipulation.
    /// </summary>
    public static class NumberUtils
    {
        /// <summary>
        /// A recursive Fibonacci method. Given a cardinal parameter, returns the number in the Fibonacci sequence at that cardinal position.
        /// The cardinality is defined as skipping 0, without repeats. (e.g. 1 is 1st, 2 is 2nd, 3 is 3rd, 5 is 4th, 8 is 5th, etc.)
        /// </summary>
        /// <param name="cardinal">The cardinal position of the Fibonacci number.</param>
        /// <returns>Returns the Fibonacci number at the given cardinal position.</returns>
        public static int Fibonacci(uint cardinal)
        {
            if (cardinal == 0) { return 0; }
            if (cardinal == 1) { return 1; }
            return Fibonacci(cardinal - 1) + Fibonacci(cardinal - 2);
        }

        /// <summary>
        /// A method to find all of the prime factors of a given long.
        /// </summary>
        /// <param name="l">The long from which its prime factors will be derived.</param>
        /// <returns>Returns an IEnumerable of type long of all of the prime factors of the given long.</returns>
        public static IEnumerable<long> GetPrimeFactors(long l)
        {
            List<long> PrimeList = new List<long>();
            for (long m = 1; l != 1; m++)
            {
                if (IsEven(m) && m > 2) { continue; } //no even number besides two can be prime, so let's just skip over these numbers - they can't be prime factors
                while (l % m == 0 && m > 1)
                {
                    l = (l / m);
                    PrimeList.Add(m);
                }
            }
            return PrimeList;
        }

        /// <summary>
        /// A method to determine if the product of two numbers, when evaluated as a string, is a palindrome.
        /// </summary>
        /// <param name="i">The multiplicand of the product to be evaluated.</param>
        /// <param name="j">The multiplier of the product to be evaluated.</param>
        /// <returns>Returns true if the product is a palindrome; returns false if it is not.</returns>
        public static bool IsPalindromeProduct(int i, int j)
        {
            return StringUtils.IsCharacterSpecificPalindrome((i * j).ToString());
        }

        /// <summary>
        /// A method to find a prime number at a given cardinal position (e.g. 2 is 1st, 3 is 2nd, 5 is 3rd, etc.).
        /// </summary>
        /// <param name="cardinal">The cardinal position of the prime number.</param>
        /// <returns>Returns the prime number at the given cardinal position.</returns>
        public static long GetCardinalPrimeNumber(int cardinal)
        {
            int count = 0;
            for (long l = 2; l < long.MaxValue; ++l)
            {
                if (IsEven(l) && l > 2) { continue; }
                if (IsPrime(l, PrimeEvaluationAlgorithms.Linear)) { count++; }
                if (count == cardinal) { return l; }
            }
            return -1;
        }

        /// <summary>
        /// Returns a list of primes up to a given limit using the Sieve of Eratosthenes algorithm.
        /// </summary>
        /// <param name="limit">The limit for high how to find primes through.</param>
        /// <returns>Returns a collection of prime numbers.</returns>
        public static IEnumerable<long> ListPrimes(long limit)
        { //we're going to have a list 
            List<(long, bool)> list = new List<(long, bool)>();
            if (limit <= 1) { return null; }
            for (long l = 2; l < limit; ++l)
            {
                list.Add((l, true));
            }
            for (long l = 2; l < Math.Floor(Math.Sqrt(limit)); ++l)
            { //if the item's already crossed out, everything it's a factor of will also be crossed out, so we can skip this
                if (list[Convert.ToInt32(l - 2)].Item2 == false) { continue; }
                else
                {
                    for(long m = l + l; m < limit; m += l)
                    {
                        list[Convert.ToInt32(m - 2)] = (m, false);
                    }
                }
            } //now we're returning all 
            return list.Where(l => l.Item2 == true).Select(l => l.Item1);
        }

        /// <summary>
        /// A method to determine the primality of a number.
        /// </summary>
        /// <param name="l">The long to be evaluated.</param>
        /// <param name="pea">The primality test to be used.</param>
        /// <returns>Returns whether or not the given long is prime.</returns>
        public static bool IsPrime(long l, PrimeEvaluationAlgorithms pea)
        {
            switch (pea)
            {
                case PrimeEvaluationAlgorithms.Linear:
                    return IsPrimeLinear(l);
                case PrimeEvaluationAlgorithms.Optimized:
                    return IsPrimeOptimized(l);
                default:
                    return IsPrimeLinear(l);
            }
        }

        private static bool IsPrimeLinear(long l)
        {
            if (l <= 1) { return false; } //negative numbers, 0, or 1
            if (l <= 3) { return true; } //2 or 3
            for (long m = 2; m < l; ++m)
            {
                if (IsEven(l)){ return false; } //no point in evaluating even numbers past 2
                if (l % m == 0){ return false; }
            }
            return true; //return true if no false condition is satisfied
        }

        private static bool IsPrimeOptimized(long l)
        {
            if (l <= 1) { return false; } //negative numbers, 0, or 1
            else if (l <= 3) { return true; } //2 or 3
            else if (l % 2 == 0 || l % 3 == 0) {  return false; } //rule out divisibility by 2 or 3
            for (int i = 5; Math.Pow(i, 2) < l; i += 6)
            { //all primes are of the form 6k±1, so we can evaluate by that
                if (l % i == 0 || l % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsEven(long l)
        {
            return (l % 2 == 0);
        }

        private static bool IsEven(int i)
        {
            return (i % 2 == 0);
        }

        private static bool IsOdd(long l)
        {
            return !IsEven(l);
        }

        private static bool IsOdd(int i)
        {
            return !IsEven(i);
        }
    }

    public enum PrimeEvaluationAlgorithms
    {
        Linear = 0,
        Optimized = 1,
    }
}