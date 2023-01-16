using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Shifted_Array_Search
{
    public class Solution
    {
        public int ShiftedArrSearch(int[] shiftArr, int num)
        {
            int l = 0;
            int r = shiftArr.Length - 1;

            while (l <= r)
            {
                int m = l + (r - l) / 2;
                if (shiftArr[m] == num) return m;
                // left part is maybe sorted array, right part is rotated sorted array
                else if (shiftArr[m] >= shiftArr[l]) 
                {
                    if (shiftArr[l] <= num && shiftArr[m] > num)  // check left part
                        r = m - 1;
                    else l = m + 1;
                }
                else // left part is rotated sorted array, right part is maybe sorted array
                {
                    if (shiftArr[m] < num && shiftArr[r] >= num) // check right part
                        l = m + 1;
                    else r = m - 1;
                }
            }
            return -1;         
        }

        public void Run()
        {
            Console.WriteLine(ShiftedArrSearch(new int[] { 9, 12, 17, 2, 4, 5 }, 2));
        }
    }
}
