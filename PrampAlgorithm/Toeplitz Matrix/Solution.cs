using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Toeplitz_Matrix
{
    public class Solution
    {
        public bool IsToeplitz(int[,] arr)
        {
            if (arr == null && arr.GetLength(0) == 0)
                return false;
            for (int r = 1; r < arr.GetLength(0); r++)
                for (int c = 1; c < arr.GetLength(1); c++)
                    if (arr[r, c] != arr[r - 1, c - 1])
                        return false;
            return true;
        }

        public void Run()
        {
            //// true
            //int[,] input = new int[,]
            //{
            //    {1,2,3,4},
            //    {5,1,2,3},
            //    {6,5,1,2}
            //};

            // false
            int[,] input = new int[,]
            {
                {1,2,3,4},
                {5,1,9,3},
                {6,5,1,2}
            };
            Console.WriteLine(IsToeplitz(input));
        }
    }
}
