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
        public static char[,] GenerateGridWithWord(int rows, int cols, string word)
        {
            char[,] grid = new char[rows, cols];
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            word = word.Replace(" ", "").ToUpper();

            int[] dRow = { 1, 0, -1, 0 };
            int[] dCol = { 0, 1, 0, -1 };

            var possibilities = new List<(int r, int c, int dir)>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    for (int dir = 0; dir < 4; dir++)
                    {
                        possibilities.Add((r, c, dir));
                    }
                }
            }
            for (int i = possibilities.Count - 1; i > 0; i--)
            {
                int k = random.Next(i + 1);
                var temp = possibilities[i];
                possibilities[i] = possibilities[k];
                possibilities[k] = temp;
            }
            bool placed = false;
            foreach (var pos in possibilities)
            {
                int endRow = pos.r + dRow[pos.dir] * (word.Length - 1);
                int endCol = pos.c + dCol[pos.dir] * (word.Length - 1);

                if (endRow >= 0 && endRow < rows && endCol >= 0 && endCol < cols)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        int currRow = pos.r + dRow[pos.dir] * i;
                        int currCol = pos.c + dCol[pos.dir] * i;
                        grid[currRow, currCol] = word[i];
                    }
                    placed = true;
                    break;
                }
            }
            if (!placed)
            {
                throw new InvalidOperationException("Word is too long.");
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == '\0')
                    {
                        grid[i, j] = alphabet[random.Next(alphabet.Length)];
                    }
                }
            }
            return grid;
        }
    }
}
