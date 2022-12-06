using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Array_Quadruplet
{
    public class Solution
    {
        public int[] FindArrayQuadruplet(int[] arr, int s)
        {
            // your code goes here
            int n = arr.Length;
            if (n < 4)
                return new int[0];
            Array.Sort(arr); // sort array

            for (int i = 0; i < n; ++i)
            {
                if (i == 0 || arr[i] != arr[i - 1])
                {
                    for (int j = i + 1; j < n; ++j)
                    {
                        if (j == i + 1 || arr[j] != arr[j - 1])
                        {
                            int l = j + 1;
                            int r = n - 1;
                            while (l < r)
                            {
                                int sum = arr[i] + arr[j] + arr[l] + arr[r];
                                if (sum == s) return new int[] { arr[i], arr[j], arr[l], arr[r] };
                                else if (sum > s)
                                    --r;
                                else ++l;
                            }
                        }
                    }
                }
            }
            return new int[0];
        }

        public void Run()
        {
            var ans = FindArrayQuadruplet(new int[] { 2, 7, 4, 0, 9, 5, 1, 3 }, 20);
            foreach (var num in ans)
                Console.WriteLine(num);
        }
    }
}
