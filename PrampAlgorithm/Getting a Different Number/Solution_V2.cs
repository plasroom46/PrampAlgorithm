using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Getting_a_Different_Number
{
    public class Solution_V2
    {
        public int GetDifferentNumber(int[] arr)
        {
            int n = arr.Length;
            // put each number in its corresponding index, kicking out
            // the original number, until the target index is out of range.
            for (int i = 0; i < n; i++)
            {
                while (arr[i] < n && arr[i] != i)
                {
                    var temp = arr[arr[i]]; 
                    arr[arr[i]] = arr[i];
                    arr[i] = temp;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (arr[i] != i)
                    return i;
            }
            return n;
        }

        public void Run()
        {
            Console.WriteLine(GetDifferentNumber(new int[] { 0, 1, 2, 3 }));
            Console.WriteLine(GetDifferentNumber(new int[] { 3, 2, 0, 1 }));
        }
    }
}
