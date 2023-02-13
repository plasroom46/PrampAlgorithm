using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Root_of_Number
{
    public class Solution
    {
        public double Root(double x, int n)
        {
            double l = 0;
            double r = x + 1;
            while (l < r) // log(x)
            {
                double m = l + (r - l) / 2;
                double y = 1;
                for (int i = 0; i < n; i++) // n
                    y *= m;
                if (Math.Abs(y - x) < 0.001)
                    return Math.Round(m, 3);
                else if (y - x > 0.001)
                    r = m;
                else l = m;
            }
            return Math.Round(l, 3);
        }

        public void Run()
        {
            Console.WriteLine(Root(7, 3));
            Console.WriteLine(Root(9, 2));
        }
    }
}
