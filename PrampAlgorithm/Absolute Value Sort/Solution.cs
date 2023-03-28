using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Absolute_Value_Sort
{
    public class Solution
    {
        public int[] AbsoluteValueSort(int[] arr)
        {
            Array.Sort(arr, (a, b) => {
                if (Math.Abs(a) == Math.Abs(b))
                    return a.CompareTo(b);
                else return Math.Abs(a).CompareTo(Math.Abs(b));
            });

            return arr;
        }

        public void Run()
        {
            Console.WriteLine(string.Join(", ", AbsoluteValueSort(new int[] { 2, -7, -2, -2, 0 })));
        }
    }
}
