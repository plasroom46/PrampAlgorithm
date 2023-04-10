using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Pancake_Sort
{
    public class Solution
    {
        public int[] PancakeSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                // find the larget number in the range
                int largeIndex = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (arr[largeIndex] < arr[j])
                        largeIndex = j;
                }
                Flip(arr, largeIndex + 1);
                Flip(arr, i + 1);
            }
            return arr;
        }

        private void Flip(int[] arr, int k)
        {
            int l = 0;
            int r = k - 1;
            while (l < r)
            {
                int temp = arr[l];
                arr[l] = arr[r];
                arr[r] = temp;
                l++;
                r--;
            }
            return;
        }

        public void Run()
        {
            Console.WriteLine(string.Join(",", PancakeSort(new int[] { 1, 5, 4, 3, 2 })));
        }
    }
}
