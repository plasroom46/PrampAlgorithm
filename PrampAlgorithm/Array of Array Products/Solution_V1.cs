using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Array_of_Array_Products
{
    public class Solution_V1
    {
        public int[] ArrayOfArrayProducts(int[] arr)
        {
            int n = arr.Length;
            if (n <= 1) return new int[0];
            int[] l = new int[n]; // l = prod(arr[0] ~ arr[i - 1])
            l[0] = 1;
            for (int i = 0; i < n - 1; i++)
              l[i + 1] = l[i] * arr[i];
            int[] r = new int[n]; // r = prod(arr[i + 1] ~ arr[n - 1])
            r[n - 1] = 1;
            for (int i = n - 1; i > 0; i--)
              r[i - 1] = r[i] * arr[i];
            int[] ans = new int[n];
            for (int i = 0; i < n; i++)
              ans[i] = l[i] * r[i];
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
