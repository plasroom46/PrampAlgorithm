using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.K_Messed_Array_Sort
{
    public class Solution_V2
    {
        public int[] SortKMessedArray(int[] arr, int k)
        {
            // min-heap
            SortedSet<Tuple<int, int>> pq = new SortedSet<Tuple<int, int>>();

            int i = 0;
            for (; i < arr.Length; i++)
            {
                pq.Add(new Tuple<int, int>(arr[i], i));
                if (pq.Count > k)
                {
                    arr[i - k] = pq.Min.Item1;
                    pq.Remove(pq.Min);
                }
            }
            while (pq.Count > 0)
            {
                arr[i - k] = pq.Min.Item1;
                pq.Remove(pq.Min);
                i++;
            }
            return arr;
        }
    }
}
