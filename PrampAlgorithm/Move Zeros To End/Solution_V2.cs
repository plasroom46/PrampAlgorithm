using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Move_Zeros_To_End
{
    public class Solution_V2
    {
        public int[] MoveZerosToEnd(int[] arr)
        {
            int n = arr.Length;
            int start = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] != 0)
                {
                    var temp = arr[i];
                    arr[i] = arr[start];
                    arr[start] = temp;
                    start++;
                }
            }

            return arr;
        }

        public void Run()
        {
            Console.WriteLine(string.Join(" ,", new int[] { 1, 10, 0, 2, 8, 3, 0, 0, 6, 4, 0, 5, 7, 0 }));
        }
    }
}
