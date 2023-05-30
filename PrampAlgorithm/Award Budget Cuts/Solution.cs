using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Award_Budget_Cuts
{
    public class Solution
    {
        /// <summary>
        /// Finds the grants cap.
        /// https://gist.github.com/jianminchen/455db84e6b4eef14f0e4a8f854cc302f
        /// https://leetcode.com/discuss/interview-question/351313/Google-or-Phone-Screen-or-Salary-Adjustment
        /// </summary>
        /// <param name="grantsArray">The grants array.</param>
        /// <param name="newBudget">The new budget.</param>
        /// <returns></returns>
        public double FindGrantsCap(double[] grantsArray, double newBudget)
        {
            int n = grantsArray.Length;

            if (n == 0 || newBudget <= 0) return 0;

            Array.Sort(grantsArray);
            double prefixSum = 0;
            int i = 0;
            for (; i < n; i++)
            {
                var current = grantsArray[i];
                var available = newBudget - prefixSum;
                var remain = n - i;
                if (current * remain >= available)
                    return available / remain;
                prefixSum += current;
            }

            return grantsArray[n - 1];
        }

        public void Run()
        {
            Console.WriteLine(FindGrantsCap(new double[] { 2, 100, 50, 120, 1000 }, 190));
            Console.WriteLine(FindGrantsCap(new double[] { 2, 100, 50, 120, 167 }, 400));
        }
    }
}
