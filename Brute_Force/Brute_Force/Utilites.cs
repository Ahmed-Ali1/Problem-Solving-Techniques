using System;
using System.Collections.Generic;
using System.Text;

namespace Brute_Force;

public static class Utilites
{
    // Console rendering utility functions
    public static void P<T>(T t) => Console.Write($"{t}");
    public static void P() => Console.Write("");
    public static void PL<T>(T t) => Console.WriteLine($"{t}");
    public static void PL() => Console.WriteLine("");


    public static void PrintListOfArray(List<int[]> list)
    {
        foreach (var arr in list)
        {
            P("[");
            int end = arr.Length;
            int count = 0;

            foreach (var item in arr)
            {
                P(item);
                count++;
                if (count == end) continue;
                P(", ");
            }
            P("]");
            PL();

        }
    }

    public static void PrintArray(int[] arr)
    {
        P("[");
        int end = arr.Length;
        int count = 0;

        foreach (var item in arr)
        {
            P(item);
            count++;
            if (count == end) continue;
            P(", ");
        }
        P("]");
        PL();
    }
    public static void PrintList<T>(List<T> list)
    {
        P("[");
        int end = list.Count;
        int count = 0;

        foreach (var item in list)
        {
            P(item);
            count++;
            if (count == end) continue;
            P(", ");
        }
        P("]");
        PL();
    }
    public static void PrintBinaryMasks(int[] arr)
    {
        int len = arr.Length;
        int total = 1 << len;
        for (int mask = 0; mask < total; mask++)
        {
            PL(Convert.ToString(mask, 2).PadLeft(len, '0'));
        }
    }
    public static void PrintGeneratedGrid(int[,] grid, int sRow, int sCol, int eRow, int eCol)
    {
        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (r == sRow && c == sCol)
                {
                    Console.Write("S ");
                }
                else if (r == eRow && c == eCol)
                {
                    Console.Write("E ");
                }
                else if (grid[r, c] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("▓▓");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
        }
    }
    public static class MazeVisualizer
    {
        public static string[,] RenderGrid(int[,] grid, bool[,] visited, bool[,] path, int currentRow, int currentCol, int eRow, int eCol)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            string[,] renderedCanvas = new string[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (r == currentRow && c == currentCol)
                    {
                        renderedCanvas[r, c] = "🚀";
                    }
                    else if (r == eRow && c == eCol)
                    {
                        renderedCanvas[r, c] = "🏁";
                    }
                    
                    else if (path[r, c])
                    {
                        renderedCanvas[r, c] = "🟢";
                    }
                    else if (visited[r, c])
                    {
                        renderedCanvas[r, c] = "🟡";
                    }

                    else if (grid[r, c] == 1)
                    {
                        renderedCanvas[r, c] = "▓▓";
                    }
                    else
                    {
                        renderedCanvas[r, c] = "  ";
                    }
                }
            }

            return renderedCanvas;
        }
        public static void DrawStep(string[,] renderedCanvas)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            int rows = renderedCanvas.GetLength(0);
            int cols = renderedCanvas.GetLength(1);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(renderedCanvas[r, c]);
                }
                Console.WriteLine(); 
            }
        }

        public static void VisualHook(int[,] grid, bool[,] visited, bool[,] path, int currentRow, int currentCol, int eRow, int eCol,int delayMs = 100)
        {
            
            string[,] canvas = RenderGrid(grid, visited,path, currentRow, currentCol, eRow, eCol);

            
            DrawStep(canvas);

            System.Threading.Thread.Sleep(delayMs);

        }

    }

    public static class WordSearchVisualizer
    {
        public static void RenderGrid(char[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void DrawStep(char[,] grid, bool[,] visited, int currentRow, int currentCol)
        {
            Console.CursorVisible = false;

            Console.SetCursorPosition(0, 0);

            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == currentRow && j == currentCol)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(grid[i, j] + " ");
                    }
                    else if (visited[i, j])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(grid[i, j] + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(grid[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public static void VisualHook(char[,] grid, bool[,] visited, int currentRow, int currentCol, int delayMs = 100)
        {
            DrawStep(grid, visited, currentRow, currentCol);
            System.Threading.Thread.Sleep(delayMs);
        }
    }
    
    public static class BruteForceVisualizer
    {
        public static void Render(int[] arr)
        {
            Console.Write("[ ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + (i < arr.Length - 1 ? ", " : " "));
            }
            Console.WriteLine("]");
        }

        public static void DrawStep(int[] arr, int currentIndex, int secondaryIndex = -1, string resultMessage = "")
        {
            Console.SetCursorPosition(0, 0);

            Console.Write("[ ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == currentIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(arr[i]);
                }
                else if (i == secondaryIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan; 
                    Console.Write(arr[i]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray; 
                    Console.Write(arr[i]);
                }

                Console.ResetColor();
                if (i < arr.Length - 1) Console.Write(", ");
            }
            Console.WriteLine(" ]\n");

            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 1);
            if (!string.IsNullOrEmpty(resultMessage))
            {
                Console.ForegroundColor = ConsoleColor.Green; 
                Console.WriteLine(resultMessage);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(); 
            }

        }
        public static void VisualHook(int[] arr, int currentIndex, int secondaryIndex = -1, int delayMs = 300)
        {
            DrawStep(arr, currentIndex, secondaryIndex,"");
            System.Threading.Thread.Sleep(delayMs);
        }
    }
}
