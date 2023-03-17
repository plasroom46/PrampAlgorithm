using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Number_of_Paths
{
    public class Solution_BottomUp
    {
        public int NumOfPathsToDest(int n)
        {
            int[][] dp = new int[n + 1][];
            for (int i = 0; i <= n; i++)
                dp[i] = new int[n + 1];
            
            for (int c = 1; c <= n; c++)
            {
                for (int r = c; r <= n; r++)
                {
                    // initial state
                    if (r == 1 && c == 1)
                        dp[r][c] = 1;
                    else
                        dp[r][c] = dp[r - 1][c] + dp[r][c - 1];
                }
            }
            return dp[n][n];
        }
        

        public void Run()
        {
            // 5
            Console.WriteLine(NumOfPathsToDest(4));
        }
    }
}
