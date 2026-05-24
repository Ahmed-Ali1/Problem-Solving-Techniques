using System;
using System.Collections.Generic;
using System.Text;

namespace Brute_Force
{
    public static class Generator
    {
        private static readonly Random _random = new Random();

        // fixed size maze for full size windows terminal
        // fixed start points , end points
        public static int[,] GenerateMaze(int rows=60, int cols=104, int sRow=1, int sCol =1)
        {
            int eRow = rows - 2;
            int eCol = cols - 2;
            int[,] grid = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (r == 0 || r == rows - 1 || c == 0 || c == cols - 1)
                    {
                        grid[r, c] = 1; 
                    }
                    else
                    {
                        grid[r, c] = (_random.Next(0, 100) < 35) ? 1 : 0;
                    }
                }
            }

            int currR = sRow;
            int currC = sCol;

            while (currR != eRow || currC != eCol)
            {
                grid[currR, currC] = 0; 

                bool canMoveRow = currR != eRow;
                bool canMoveCol = currC != eCol;

                if (canMoveRow && canMoveCol)
                {
                    if (_random.Next(0, 2) == 0)
                    {
                        currR += (eRow > currR) ? 1 : -1;
                    }
                    else
                    {
                        currC += (eCol > currC) ? 1 : -1;
                    }
                }
                else if (canMoveRow)
                {
                    currR += (eRow > currR) ? 1 : -1;
                }
                else if (canMoveCol)
                {
                    currC += (eCol > currC) ? 1 : -1;
                }
            }

            grid[sRow, sCol] = 0;
            grid[eRow, eCol] = 0;

            return grid;
        }

    }
}
