using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Basic_Regex_Parser
{
    public class Solution_Recursion
    {
        public bool IsMatch(string text, string pattern)
        {
            return IsMatch(text, pattern, 0, 0);
        }

        private bool IsMatch(string text, string pattern, int textIndex, int patternIndex)
        {
            int textLength = text.Length;
            int patternLength = pattern.Length;
            // base cases - one of the indexes reached the end of text or pattern
            if (textIndex >= textLength)
            {
                if (patternIndex >= patternLength)
                    return true;
                else if (patternIndex + 1 < patternLength && pattern[patternIndex + 1] == '*')
                    return IsMatch(text, pattern, textIndex, patternIndex + 2);
                else return false;
            }
            else if (patternIndex >= patternLength && textIndex < textLength)
                return false;
            // string matching for character followed by '*'
            else if (patternIndex + 1 < patternLength && pattern[patternIndex + 1] == '*')
            {
                if (pattern[patternIndex] == text[textIndex] || pattern[patternIndex] == '.')
                    // Match 0 character || Match multiple of character
                    return IsMatch(text, pattern, textIndex, patternIndex + 2) || IsMatch(text, pattern, textIndex + 1, patternIndex);
                else// Match 0 character 
                    return IsMatch(text, pattern, textIndex, patternIndex + 2);
            }
            else if (pattern[patternIndex] == text[textIndex] || pattern[patternIndex] == '.')
                return IsMatch(text, pattern, textIndex + 1, patternIndex + 1);
            else return false;

        }

        public void Run()
        {
            Console.WriteLine(IsMatch("aa", "a"));
            Console.WriteLine(IsMatch("aa", "aa"));
            Console.WriteLine(IsMatch("abc", "a.c"));
            Console.WriteLine(IsMatch("abbb", "ab*"));
            Console.WriteLine(IsMatch("acd", "ab*c."));
            Console.WriteLine(IsMatch("", "a*"));
            Console.WriteLine(IsMatch("abaa", "a.*a*"));
            Console.WriteLine(IsMatch("bbbbbbbb", ".*.*.*.*"));
        }
    }
}
