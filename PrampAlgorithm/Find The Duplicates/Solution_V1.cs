using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Find_The_Duplicates
{
    public class Solution_V1
    {
        // m ≈ n
        public int[] FindDuplicates(int[] arr1, int[] arr2)
        {
            List<int> ans = new List<int>();
            int i = 0;
            int j = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] == arr2[j])
                {
                    ans.Add(arr1[i]);
                    i++;
                    j++;
                }
                else if (arr1[i] > arr2[j])
                    j++;
                else i++;
            }
            return ans.ToArray();
        }

        public void Run()
        {
            Console.WriteLine(string.Join(", ", FindDuplicates(new int[] { 1, 2, 3, 5, 6, 7 }, new int[] { 3, 6, 7, 8, 20 })));
        }
    }
}
