using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Getting_a_Different_Number
{
    public class Solution_V1
    {
        public int GetDifferentNumber(int[] arr)
        {
            HashSet<int> s = new HashSet<int>(arr);
            int i = 0;
            while (s.Contains(i))
              i++;
            return i;
        }

        public void Run()
        {
            Console.WriteLine(GetDifferentNumber(new int[] { 0, 1, 2, 3 }));
            Console.WriteLine(GetDifferentNumber(new int[] { 3, 2, 0, 1 }));
        }
    }
}
