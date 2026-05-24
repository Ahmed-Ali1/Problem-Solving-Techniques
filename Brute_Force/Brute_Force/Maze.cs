using System;
using System.Collections.Generic;
using System.Text;
using static Brute_Force.Utilites;

namespace Brute_Force
{
    public static class Maze
    {
        public static bool SolveMaze(int[,] grid)
        {
            // fixed startRow , startCol
            int startRow = 1 ,startCol = 1;
            // fixed endRow , endCol
            int endRow = grid.GetLength(0) - 2, endCol = grid.GetLength(1) - 2;

            var visited = new bool[grid.GetLength(0), grid.GetLength(1)];
            var path = new bool[grid.GetLength(0), grid.GetLength(1)];

            return SolveMaze(grid, visited, path, startRow, startCol, endRow, endCol);
        }

        private static bool SolveMaze(int[,] grid, bool[,] visited, bool[,] path, int currentRow, int currentCol, int eRow, int eCol)
        {
            var outOfBounds = IsOutOfBounds(grid, currentRow, currentCol);
            var wall = IsWall(grid, currentRow, currentCol);
            var VISITED = IsVisited(visited, currentRow, currentCol);
            if (outOfBounds || wall || VISITED)
            {
                return false;
            }

            var destionation = IsDestination(currentRow, currentCol, eRow, eCol);
            if (destionation)
            {
                // show the grid
                ConsoleVisualizer.VisualHook(grid, visited, path, currentRow, currentCol, eRow, eCol);
                return true;
            }
            SetVisited(visited, currentRow, currentCol, true);
            SetVisited(path, currentRow, currentCol, true);


            // show the grid
            ConsoleVisualizer.VisualHook(grid, visited, path, currentRow, currentCol, eRow, eCol);

            if (TryDirections(grid, visited, path, currentRow, currentCol, eRow, eCol))
            {

                return true;
            }

            SetVisited(path, currentRow, currentCol, false);
            // show the grid
            ConsoleVisualizer.VisualHook(grid, visited, path, currentRow, currentCol, eRow, eCol);

            return false;
        }
        private static bool IsOutOfBounds(int[,] grid, int row, int col)
        {
            int rowsCount = grid.GetLength(0);
            int colsCount = grid.GetLength(1);

            return row < 0 || col < 0 || row >= rowsCount || col >= colsCount;
        }
        private static bool IsOutOfBounds(bool[,] grid, int row, int col)
        {
            int rowsCount = grid.GetLength(0);
            int colsCount = grid.GetLength(1);

            return row < 0 || col < 0 || row >= rowsCount || col >= colsCount;
        }

        private static bool IsWall(int[,] grid, int row, int col)
        {
            if (IsOutOfBounds(grid, row, col)) return true;

            return grid[row, col] == 1;
        }

        private static bool IsVisited(bool[,] visited, int row, int col)
        {
            if (IsOutOfBounds(visited, row, col)) return true;
            return visited[row, col];
        }
        private static bool IsDestination(int row, int col, int destRow, int destCol)
        {
            return row == destRow && col == destCol;
        }

        private static void SetVisited(bool[,] visited, int row, int col, bool state)
        {
            visited[row, col] = state;
        }
        private static readonly int[] dRow = { 1, 0, -1, 0 };
        private static readonly int[] dCol = { 0, 1, 0, -1 };
        private static bool TryDirections(int[,] grid, bool[,] visited, bool[,] path, int currentRow, int currentCol, int eRow, int eCol)
        {
            for (int i = 0; i < 4; i++)
            {
                int nextRow = currentRow + dRow[i];
                int nextCol = currentCol + dCol[i];

                if (SolveMaze(grid, visited, path, nextRow, nextCol, eRow, eCol))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
