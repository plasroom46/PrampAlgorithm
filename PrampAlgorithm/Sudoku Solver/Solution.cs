using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Sudoku_Solver
{
    public class Solution
    {
        public bool SudokuSolve(char[,] board)
        {
            // your code goes here
            bool[,] rows = new bool[9, 9];
            bool[,] cols = new bool[9, 9];
            bool[,] subs = new bool[9, 9];
            for (int r = 0; r < 9; ++r)
            {
                for (int c = 0; c < 9; ++c)
                {
                    if (board[r, c] != '.')
                    {
                        var num = board[r, c] - '1';
                        rows[r, num] = true;
                        cols[c, num] = true;
                        int subIndex = r / 3 * 3 + c / 3;
                        subs[subIndex, num] = true;
                    }
                }
            }

            return SudokuSolve(board, rows, cols, subs, 0, 0);
        }

        private bool SudokuSolve(char[,] board, bool[,] rows, bool[,] cols, bool[,] subs, int r, int c)
        {
            if (r == 9) return true;
            else
            {
                int nc = c == 8 ? 0 : c + 1;
                int nr = c == 8 ? r + 1 : r;
                if (board[r, c] != '.') return SudokuSolve(board, rows, cols, subs, nr, nc);
                int subIndex = r / 3 * 3 + c / 3;
                for (int i = 0; i < 9; ++i)
                {
                    if (!rows[r, i] && !cols[c, i] && !subs[subIndex, i])
                    {
                        rows[r, i] = true;
                        cols[c, i] = true;
                        subs[subIndex, i] = true;
                        board[r, c] = (char)(i + '1');
                        if (SudokuSolve(board, rows, cols, subs, nr, nc)) return true;
                        board[r, c] = '.';
                        subs[subIndex, i] = false;
                        cols[c, i] = false;
                        rows[r, i] = false;
                    }
                }
                return false;
            }
        }

        public void Run()
        {
            char[,] board = new char[,]
            {
              {'.','.','.','7','.','.','3','.','1'},
              {'3','.','.','9','.','.','.','.','.'},
              {'.','4','.','3','1','.','2','.','.'},
              {'.','6','.','4','.','.','5','.','.'},
              {'.','.','.','.','.','.','.','.','.'},
              {'.','.','1','.','.','8','.','4','.'},
              {'.','.','6','.','2','1','.','5','.'},
              {'.','.','.','.','.','9','.','.','8'},
              {'8','.','5','.','.','4','.','.','.'}
            };
            Console.WriteLine(SudokuSolve(board));
        }
    }
}
