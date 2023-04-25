using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Busiest_Time_in_The_Mall
{
    public class Solution
    {
        public int FindBusiestPeriod(int[,] data)
        {
            if (data == null || data.GetLength(0) == 0) 
                    return -1;

            int n = data.GetLength(0);

            int count = 0;
            int maxCount = 0;
            int maxPeriodTime = 0;

            for (int i = 0; i < n; ++i)
            {
                // update count
                if (data[i, 2] == 0) // visitors existed the mall
                    count -= data[i, 1];
                else // visitors entered the mall 
                    count += data[i, 1];

                // check for other data points with the same timestamp
                if (i < n - 1 && data[i, 0] == data[i + 1, 0])
                    continue;

                // update maximum
                if (count > maxCount)
                {
                    maxCount = count;
                    maxPeriodTime = data[i, 0];
                }
            }
            return maxPeriodTime;
        }

        public void Run()
        {
            /*
            int[,] data = new int[,]
            {
              {1487799425, 14, 1}, 
              {1487799425, 4,  0},
              {1487799425, 2,  0},
              {1487800378, 10, 1},
              {1487801478, 18, 0},
              {1487801478, 18, 1},
              {1487901013, 1,  0},
              {1487901211, 7,  1},
              {1487901211, 7,  0}
            };
            */

            int[,] data = new int[,]
            {
              {1487799425,14,1},
              {1487799425,4,0},
              {1487799425,2,0},
              {1487800378,10,1},
              {1487801478,18,0},
              {1487801478,19,1},
              {1487801478,1,0},
              {1487801478,1,1},
              {1487901013,1,0},
              {1487901211,7,1},
              {1487901211,8,0}
            };

            Console.WriteLine(FindBusiestPeriod(data));
        }
    }
}
