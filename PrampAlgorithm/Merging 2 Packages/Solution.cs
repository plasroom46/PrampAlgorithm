using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Merging_2_Packages
{
    public class Solution
    {
        public int[] GetIndicesOfItemWeights(int[] arr, int limit)
        {
            // {weight : index}
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int remainWeight = limit - arr[i];
                if (map.ContainsKey(remainWeight))
                    return new int[] { i, map[remainWeight] };
                map[arr[i]] = i;
            }
            return new int[0];
        }

        public void Run()
        {
            var ans = GetIndicesOfItemWeights(new int[] { 4, 6, 10, 15, 16 }, 21);
            Console.WriteLine(string.Join(",", ans));
        }
    }
}
