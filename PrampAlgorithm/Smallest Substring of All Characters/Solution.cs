using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Smallest_Substring_of_All_Characters
{
    public class Solution
    {
        public string GetShortestUniqueSubstring(char[] arr, string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var c in arr)
                dict[c] = 0;
            int l = 0;
            int count = arr.Length;
            int start = -1;
            int length = int.MaxValue;
            for (int r = 0; r < str.Length; r++)
            {
                if (dict.ContainsKey(str[r]))
                {
                    dict[str[r]]++;
                    if (dict[str[r]] == 1) count--;
                }
                while (count == 0)
                {
                    if (length > (r - l + 1))
                    {
                        start = l;
                        length = r - l + 1;
                    }
                    if (dict.ContainsKey(str[l]))
                    {
                        dict[str[l]]--;
                        if (dict[str[l]] == 0) count++;
                    }
                    l++;
                }
            }
            return start == -1 ? "" : str.Substring(start, length);
        }

        public void Run()
        {
            // output: "zyx"
            Console.WriteLine(GetShortestUniqueSubstring(new char[] { 'x', 'y', 'z' }, "xyyzyzyx"));
        }
    }
}
