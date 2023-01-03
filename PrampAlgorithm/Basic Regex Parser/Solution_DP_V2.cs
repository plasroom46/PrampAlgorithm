using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Basic_Regex_Parser
{
    public class Solution_DP_V2
    {
        public bool IsMatch(string text, string pattern)
        {
            int textLength = text.Length;
            int patternLength = pattern.Length;

            text = "#" + text;
            pattern = "#" + pattern;

            bool[][] dp = new bool[textLength + 1][];
            for (int i = 0; i <= textLength; i++)
            {
                dp[i] = new bool[patternLength + 1];
            }

            dp[0][0] = true;

            // It is guaranteed for each appearance of the character '*', there will be a previous valid character to match.
            for (int j = 2; j <= patternLength; j++)
            {
                dp[0][j] = pattern[j] == '*' && dp[0][j - 2];
            }

            for (int i = 1; i <= textLength; i++)
            {
                for (int j = 1; j <= patternLength; j++)
                {
                    if (text[i] == pattern[j] || pattern[j] == '.')
                        dp[i][j] = dp[i - 1][j - 1];
                    else if (pattern[j] == '*')
                    {
                        // Match 0 character
                        if (text[i] != pattern[j - 1] && pattern[j - 1] != '.')
                            dp[i][j] = dp[i][j - 2];
                        // Match 0 character || Match multiple of character
                        else
                            dp[i][j] = dp[i][j - 2] || dp[i - 1][j];
                    }
                }
            }
            return dp[textLength][patternLength];
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
