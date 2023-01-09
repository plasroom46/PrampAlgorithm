using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Time_Planner
{
    public class Solution
    {
        public int[] MeetingPlanner(int[,] slotsA, int[,] slotsB, int dur)
        {
            int an = slotsA.GetLength(0); // # of slotsA
            int bn = slotsB.GetLength(0); // # of slotsB
            int ai = 0; // position of slotsA
            int bi = 0; // position of slotsB
            while (ai < an && bi < bn)
            {
                int start = Math.Max(slotsA[ai, 0], slotsB[bi, 0]);
                int end = Math.Min(slotsA[ai, 1], slotsB[bi, 1]);
                if (end - start >= dur) // check the interval is large or equal to dur
                    return new int[] { start, start + dur };
                else
                {
                    if (slotsA[ai, 1] > slotsB[bi, 1]) // move slotB position
                        bi++;
                    else
                        ai++; // move slotA position
                }
            }
            return new int[0];
        }

        public void Run()
        {
            int[,] slotsA = new int[,]
            {
               {10, 50},
               {60, 120},
               {140, 210}
            };
            int[,] slotsB = new int[,]
            {
                {0, 15},
                {60, 70},
            };
            var ans = MeetingPlanner(slotsA, slotsB, 8);
            if (ans.Length == 0)
            {
                Console.WriteLine("No match range");
            }
            else
            {
                Console.WriteLine($"start: {ans[0]}");
                Console.WriteLine($"End: {ans[1]}");
            }
        }
    }
}
