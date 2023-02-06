using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.K_Messed_Array_Sort
{
    public class Solution_V1
    {
        public int[] SortKMessedArray(int[] arr, int k)
        {
            // min-heap
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            int i = 0;
            for (; i < arr.Length; i++)
            {
                pq.Enqueue(arr[i], arr[i]);
                if (pq.Count > k)
                    arr[i - k] = pq.Dequeue();
            }
            while (pq.Count > 0)
            {
                arr[i - k] = pq.Dequeue();
                i++;
            }
            return arr;
        }

        public void Run()
        {
            var ans = SortKMessedArray(new int[] { 1, 4, 5, 2, 3, 7, 8, 6, 10, 9 }, 2);
            Console.WriteLine(string.Join(", ", ans));
        }
    }
}
