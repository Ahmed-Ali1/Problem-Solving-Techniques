
using static Brute_Force.Utilites;
namespace Brute_Force
{
    public static class WordSearch
    {
        public static bool Exist(char[,] grid, string word)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    bool[,] visited = new bool[rows, cols];
                    if (Exist(grid, visited, word, 0, i, j))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool Exist(char[,] grid, bool[,] visited, string word, int index, int currentRow, int currentCol)
        {
            if (IsOutOfBounds(grid, currentRow, currentCol) ||
                IsVisited(visited, currentRow, currentCol) ||
                !IsIdentical(grid, word, index, currentRow, currentCol))
                return false;
            if (index == word.Length - 1)
            {
                SetVisited(visited, currentRow, currentCol, false);
                // show the grid
                WordSearchVisualizer.VisualHook(grid, visited, currentRow, currentCol, 100);
                
                return true;
            }
            SetVisited(visited, currentRow, currentCol, true);
            // show the grid
            WordSearchVisualizer.VisualHook(grid, visited, currentRow, currentCol, 100);
            // explore directions
            var result = TryDirections(grid, visited, word, index, currentRow, currentCol);

            SetVisited(visited, currentRow, currentCol, false);
            // show the grid
            WordSearchVisualizer.VisualHook(grid, visited, currentRow, currentCol, 100);
            return result;
        }

        private static bool IsOutOfBounds(char[,] grid, int row, int col)
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
        private static bool IsVisited(bool[,] visited, int row, int col)
        {
            if (IsOutOfBounds(visited, row, col)) return true;
            return visited[row, col];
        }
        private static bool IsIdentical(char[,] grid, string word, int index, int row, int col)
        {
            return grid[row, col] == word[index];
        }

        private static void SetVisited(bool[,] visited, int row, int col, bool state)
        {
            visited[row, col] = state;
        }

        private static readonly int[] dRow = { 1, 0, -1, 0 };
        private static readonly int[] dCol = { 0, 1, 0, -1 };
        private static bool TryDirections(char[,] grid, bool[,] visited, string word, int index, int currentRow, int currentCol)
        {
            for (int i = 0; i < 4; i++)
            {
                int nextRow = currentRow + dRow[i];
                int nextCol = currentCol + dCol[i];
                bool isValid =
                    !IsOutOfBounds(grid, nextRow, nextCol) &&
                    !IsVisited(visited, nextRow, nextCol) &&
                    IsIdentical(grid, word, index + 1, nextRow, nextCol);

                if (isValid)
                {
                    var success = Exist(grid, visited, word, index + 1, nextRow, nextCol);
                    if (success)
                        return true;
                }
            }
            return false;
        }

    }
}
