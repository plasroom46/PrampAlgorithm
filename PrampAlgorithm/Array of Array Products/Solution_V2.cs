using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Array_of_Array_Products
{
    public class Solution_V2
    {
        public int[] ArrayOfArrayProducts(int[] arr)
        {
            int n = arr.Length;
            if (n <= 1) return new int[0];
            int[] ans = Enumerable.Repeat(1, n).ToArray();
            int l = 1; // l = prod(arr[0] ~ arr[i - 1])
            for (int i = 1; i < n; i++)
            {
                l *= arr[i - 1];
                ans[i] *= l;
            }
            int r = 1; // r = prod(arr[i + 1] ~ arr[n - 1])
            for (int i = n - 2; i >= 0; i--)
            {
                r *= arr[i + 1];
                ans[i] *= r;
            }

            return ans;
        }

        public void Run()
        {
            //var ans = ArrayOfArrayProducts(new int[] { 8, 10, 2 });
            //var ans = ArrayOfArrayProducts(new int[] { 2, 7, 3, 4 });
            //var ans = ArrayOfArrayProducts(new int[] {  });
            var ans = ArrayOfArrayProducts(new int[] { 1 });
            foreach (var num in ans)
                Console.WriteLine(num);
        }
    }
}
