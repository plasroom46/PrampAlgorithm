using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Shortest_Cell_Path
{
    public class Solution
    {
        public int ShortestCellPath(int[][] grid, int sr, int sc, int tr, int tc)
        {
            if (grid == null || grid.Length == 0) return -1;
            int row = grid.Length;
            int col = grid[0].Length;
            Queue<int[]> q = new Queue<int[]>();
            q.Enqueue(new int[] { sr, sc });

            int step = 0;
            int[] dirs = new int[] { 0, 1, 0, -1, 0 };

            while (q.Count > 0)
            {
                int count = q.Count;
                while (count-- > 0)
                {
                    var p = q.Dequeue();

                    for (int d = 0; d < 4; ++d)
                    {
                        int nr = p[0] + dirs[d];
                        int nc = p[1] + dirs[d + 1];
                        if (nr < 0 || nr >= row || nc < 0 || nc >= col || grid[nr][nc] == 0) continue;
                        if (nr == tr && nc == tc) return step + 1;
                        grid[nr][nc] = 0;
                        q.Enqueue(new int[] { nr, nc });
                    }
                }
                ++step;
            }
            return -1;
        }

        public void Run()
        {
            int[][] grid = new int[][]
            {
                new int[]{ 1, 1, 1, 1 },
                new int[]{ 0, 0, 0, 1 },
                new int[]{ 1, 1, 1, 1 },
            };
            Console.WriteLine(ShortestCellPath(grid, 0, 0, 2, 0));
        }
    }
}
