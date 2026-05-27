using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Brute_Force
{
    public static class NQueens
    {


        public static bool IsSafe(char[,] grid, int x, int y)
        {
            int[] dx = { -1, -1, -1 };
            int[] dy = { 0, -1, 1 };
            int n = grid.GetLength(0);
            for (int dir = 0; dir < 3; dir++)
            {
                int nx = x + dx[dir];
                int ny = y + dy[dir];
                while (nx >= 0 && ny >= 0 && ny < n)
                {
                    if (grid[nx, ny] == 'Q')
                        return false;
                    nx += dx[dir];
                    ny += dy[dir];
                }
            }

            return true;
        }

        public static List<char[,]> NQueen(char[,] chessBoard, int n,Action<int,int,string>? onStepChecked = null)
        {
            var result = new List<char[,]>();
            NQueen(chessBoard, n, 0, result,onStepChecked);
            return result;

        }
        public static void NQueen(char[,] grid, int n, int row, List<char[,]> result, Action<int, int, string>? onStepChecked)
        {

            if (row == n)
            {
                result.Add((char[,])grid.Clone());
                onStepChecked?.Invoke(-1, -1, "✨ FOUND FULL VALID SOLUTION! ✨");
                return;
            }
            for (int col = 0; col < n; col++)
            {
                onStepChecked?.Invoke(row, col, $"Checking Row {row}, Col {col}...");
                if (IsSafe(grid, row, col))
                {
                    grid[row, col] = 'Q';
                    onStepChecked?.Invoke(row, col, $"➔ SAFE: Queen placed at Row {row}, Col {col}. Moving deeper...");

                    NQueen(grid, n, row + 1, result, onStepChecked);

                    grid[row, col] = '#';
                    onStepChecked?.Invoke(row, col, $"↩ BACKTRACK: Removing Queen from Row {row}, Col {col}.");
                }
                else
                {
                    onStepChecked?.Invoke(row, col, $"❌ CONFLICT: Position Row {row}, Col {col} is under attack!");
                }
            }
        }
    }

}

