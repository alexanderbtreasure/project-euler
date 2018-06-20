using System;
using System.Collections.Generic;
using System.Linq;

namespace EulerUtils
{
    /// <summary>
    /// A static library for string manipulation.
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Checks if a given string is a character-specific (does not ignore whitespace and punctuation) palindrome.
        /// </summary>
        /// <param name="s">The string to be checked.</param>
        /// <returns>Returns if the string is a character-specific (does not ignore whitespace and punctuation) palindrome.</returns>
        public static bool IsCharacterSpecificPalindrome(String s)
        {
            return s.SequenceEqual(s.Reverse());
        }
    }
}
