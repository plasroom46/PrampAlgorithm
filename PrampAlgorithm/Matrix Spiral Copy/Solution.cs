using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Matrix_Spiral_Copy
{
    public class Solution
    {
        public int[] SpiralCopy(int[,] inputMatrix)
        {
            int row = inputMatrix.GetLength(0);
            int col = inputMatrix.GetLength(1);
            int rowLow = 0;
            int rowHigh = row - 1;
            int colLow = 0;
            int colHigh = col - 1;
            int[] ans = new int[row * col];
            int index = 0;
            while (index < row * col)
            {
                for (int c = colLow; c <= colHigh && index < row * col; c++)
                    ans[index++] = inputMatrix[rowLow, c]; // 1 ~ 5
                rowLow++;
                for (int r = rowLow; r <= rowHigh && index < row * col; r++)
                    ans[index++] = inputMatrix[r, colHigh]; // 10, 15, 20
                colHigh--;
                for (int c = colHigh; c >= colLow && index < row * col; c--)
                    ans[index++] = inputMatrix[rowHigh, c]; // 19 ~ 16
                rowHigh--;
                for (int r = rowHigh; r >= rowLow && index < row * col; r--)
                    ans[index++] = inputMatrix[r, colLow]; // 11, 6
                colLow++;
            }
            return ans;
        }

        public void Run()
        {
            int[,] input = new int[,]
            {
                {1,    2,   3,  4,    5},
                {6,    7,   8,  9,   10},
                {11,  12,  13,  14,  15},
                {16,  17,  18,  19,  20}
            };
            var output = SpiralCopy(input);
            Console.WriteLine(string.Join(", ", output));
        }
    }
}
