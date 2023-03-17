using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Number_of_Paths
{
    public class Solution_TopDown
    {
        public int NumOfPathsToDest(int n)
        {
            int[][] memo = new int[n][];
            for (int i = 0; i < n; i++)
                memo[i] = Enumerable.Repeat(-1, n).ToArray();
            return NumOfPathsToDest(n, 0, 0, memo);
        }
        private int NumOfPathsToDest(int n, int r, int c, int[][] memo)
        {
            // destination 
            if (r == n - 1 && c == n - 1)
                return 1;
            else if (r < c) // condition i >= j
                return 0;
            else if (r >= n || c >= n) // out of boundry
                return 0;
            else if (memo[r][c] != -1) // calculate before
                return memo[r][c];
            else
                return memo[r][c] = NumOfPathsToDest(n, r + 1, c, memo) + NumOfPathsToDest(n, r, c + 1, memo);
        }

        public void Run()
        {
            // 5
            Console.WriteLine(NumOfPathsToDest(4));
        }
    }
}
