using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Find_The_Duplicates
{
    public class Solution_V2
    {
        // m >> n
        // put the longer array in the arr2 then use binary search to find the duplicated number
        public int[] FindDuplicates(int[] arr1, int[] arr2)
        {
            if (arr1.Length > arr2.Length) return FindDuplicates(arr2, arr1);

            List<int> ans = new List<int>();
            foreach (var num in arr1)
            {
                int l = 0;
                int r = arr2.Length;
                while (l < r)
                {
                    int m = l + (r - l) / 2;
                    if (arr2[m] == num)
                    {
                        ans.Add(num);
                        break;
                    }
                    else if (arr2[m] > num)
                        r = m;
                    else l = m + 1;
                }
            }
            return ans.ToArray();
        }

        public void Run()
        {
            Console.WriteLine(string.Join(", ", FindDuplicates(new int[] { 1, 2, 3, 5, 6, 7 }, new int[] { 3, 6, 7, 8, 20 })));
        }
    }
}
