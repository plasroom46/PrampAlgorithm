using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Array_Index_And_Element_Equality
{
    public class Solution
    {
        public int IndexEqualsValueSearch(int[] arr)
        {
            int n = arr.Length;
            int l = 0;
            int r = n; 
            while (l < r)
            {
                int m = l + (r - l) / 2; 
                if (arr[m] >= m) 
                    r = m; 
                else
                    l = m + 1; 
            }
            // check the index is not out of range and the index == arr[index]
            if (l != n && arr[l] == l)
                return l;
            else return -1;
        }

        public void Run()
        {
            // expected output: 2
            Console.WriteLine(IndexEqualsValueSearch(new int[] { -8, 0, 2, 5 }));
            // expected output: -1
            Console.WriteLine(IndexEqualsValueSearch(new int[] { -1, 0, 3, 6 }));
        }
    }
}
