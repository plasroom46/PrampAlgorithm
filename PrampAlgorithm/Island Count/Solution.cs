using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Island_Count
{
    public class Solution
    {
        public int GetNumberOfIslands(int[,] binaryMatrix)
        {
            int row = binaryMatrix.GetLength(0);
            int col = binaryMatrix.GetLength(1);
            int ans = 0;
            // check every cell
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    if (binaryMatrix[r, c] == 1)
                    {
                        ans++;
                        DFS(binaryMatrix, r, c);
                    }
                }
            }
            return ans;
        }

        private void DFS(int[,] binaryMatrix, int r, int c)
        {
            int row = binaryMatrix.GetLength(0);
            int col = binaryMatrix.GetLength(1);
            // check the boundry or it is a land
            if (r < 0 || r >= row || c < 0 || c >= col || binaryMatrix[r, c] == 0)
                return;
            // change the cell to 0 to avoid visiting again 
            binaryMatrix[r, c] = 0;
            // check its neighbor(up, down, left, right)
            int[] dirs = new int[] { 0, 1, 0, -1, 0 };
            for (int d = 0; d < 4; d++)
                DFS(binaryMatrix, r + dirs[d], c + dirs[d + 1]);
        }

        public void Run()
        {
            int[,] binaryMatrix = new int[,]
            {
                {0,    1,    0,    1,    0},
                {0,    0,    1,    1,    1},
                {1,    0,    0,    1,    0},
                {0,    1,    1,    0,    0},
                {1,    0,    1,    0,    1}
            };
            Console.WriteLine(GetNumberOfIslands(binaryMatrix));
        }
    }
}
