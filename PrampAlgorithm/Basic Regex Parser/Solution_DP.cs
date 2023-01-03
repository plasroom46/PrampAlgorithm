﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Basic_Regex_Parser
{
    public class Solution_DP
    {
        public bool IsMatch(string text, string pattern)
        {
            // 1, If pattern[j] == text[i] :  dp[i][j] = dp[i-1][j-1];
            // 2, If pattern[j] == '.' : dp[i][j] = dp[i-1][j-1];
            // 3, If pattern[j] == '*': 
            //    here are two sub conditions:
            //                1   if pattern[j - 1] != text[i] and pattern[j - 1] != '.':
            //                               dp[i][j] = dp[i][j-2]  //in this case, a* only counts as empty
            //                2   if pattern[j - 1] == text[i] or pattern[j - 1] == '.':
            //                               dp[i][j] = dp[i-1][j]   // in this case, a* counts as multiple a 
            //                            or dp[i][j] = dp[i][j-1]   // in this case, a* counts as single a
            //                            or dp[i][j] = dp[i][j-2]   // in this case, a* counts as empty

            int textLength = text.Length;
            int patternLength = pattern.Length;
            bool[][] dp = new bool[textLength + 1][];
            for (int i = 0; i <= textLength; i++)
            {
                dp[i] = new bool[patternLength + 1];
            }
            dp[0][0] = true;
            for (int j = 1; j < patternLength; j++)
            {
                if (pattern[j] == '*')
                    dp[0][j + 1] = dp[0][j - 1];
            }
            for (int i = 0; i < textLength; i++)
            {
                for (int j = 0; j < patternLength; j++)
                {
                    if (text[i] == pattern[j])
                        dp[i + 1][j + 1] = dp[i][j];
                    else if (pattern[j] == '.')
                        dp[i + 1][j + 1] = dp[i][j];
                    else if (pattern[j] == '*')
                    {
                        //in this case, a* only counts as empty
                        if (text[i] != pattern[j - 1] && pattern[j - 1] != '.')
                            dp[i + 1][j + 1] = dp[i + 1][j - 1];
                        else
                            dp[i + 1][j + 1] = dp[i][j + 1] // in this case, a* counts as multiple a 
                                            || dp[i + 1][j] // in this case, a* counts as single a
                                            || dp[i + 1][j - 1]; // in this case, a* counts as empty
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
