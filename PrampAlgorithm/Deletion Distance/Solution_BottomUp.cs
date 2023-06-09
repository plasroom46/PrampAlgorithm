using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Deletion_Distance
{
    public class Solution_BottomUp
    {
        public int DeletionDistance(string str1, string str2)
        {
            int n1 = str1.Length;
            int n2 = str2.Length;
            int[][] dp = new int[n1 + 1][];
            for (int i = 0; i <= n1; i++)
                dp[i] = new int[n2 + 1];
            for (int i = 0; i <= n1; i++)
            {
                for (int j = 0; j <= n2; j++)
                {
                    if (i == 0)
                        dp[i][j] = j;
                    else if (j == 0)
                        dp[i][j] = i;
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i][j] = dp[i - 1][j - 1];
                    else
                        dp[i][j] = Math.Min(dp[i - 1][j], dp[i][j - 1]) + 1;
                }
            }
            return dp[n1][n2];
        }

        public void Run()
        {
            Console.WriteLine(DeletionDistance("dog", "frog"));
            Console.WriteLine(DeletionDistance("some", "some"));
            Console.WriteLine(DeletionDistance("some", "thing"));
            Console.WriteLine(DeletionDistance("", ""));
        }
    }
}
