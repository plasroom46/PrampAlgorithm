using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Pairs_with_Specific_Difference
{
    public class Solution
    {
        public int[,] FindPairsWithGivenDifference(int[] arr, int k)
        {
            // your code goes here
            HashSet<int> s = new HashSet<int>(arr);
            List<int[]> l = new List<int[]>();
            foreach (var y in arr)
            {
                int x = y + k;
                if (s.Contains(x))
                    l.Add(new int[] { x, y });
            }
            int n = l.Count;
            if (n == 0)
                return new int[0, 0];
            else
            {
                int[,] ans = new int[n, 2];
                for (int i = 0; i < n; ++i)
                {
                    ans[i, 0] = l[i][0];
                    ans[i, 1] = l[i][1];
                }
                return ans;
            }
        }

        public void Run()
        {
            int[,] output = FindPairsWithGivenDifference(new int[] { 0, -1, -2, 2, 1 }, 1);
            Console.WriteLine(output.Length);
            Console.WriteLine(output.GetLength(0));
            Console.WriteLine(output.GetLength(1));
            for (int i = 0; i < output.GetLength(0); i++)
            {
                Console.WriteLine($"{output[i, 0]},{output[i, 1]}");
            }
        }
    }
}
