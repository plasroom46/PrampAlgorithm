using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Deletion_Distance
{
    public class Solution_TopDown
    {
        public int DeletionDistance(string str1, string str2)
        {
            int n1 = str1.Length;
            int n2 = str2.Length;
            int[][] memo = new int[n1][];
            for (int i = 0; i < n1; i++)
                memo[i] = Enumerable.Repeat(int.MaxValue, n2).ToArray();

            return DeletionDistance(str1, str2, 0, 0, memo);
        }

        private int DeletionDistance(string str1, string str2, int p1, int p2, int[][] memo)
        {
            int n1 = str1.Length;
            int n2 = str2.Length;
            if (p1 == n1)
                return n2 - p2;
            if (p2 == n2)
                return n1 - p1;
            if (memo[p1][p2] != int.MaxValue)
                return memo[p1][p2];
            if (str1[p1] == str2[p2])
                return memo[p1][p2] = DeletionDistance(str1, str2, p1 + 1, p2 + 1, memo);
            else
                return memo[p1][p2] = Math.Min(DeletionDistance(str1, str2, p1 + 1, p2, memo), DeletionDistance(str1, str2, p1, p2 + 1, memo)) + 1;
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
