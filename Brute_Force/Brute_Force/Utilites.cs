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


    public static void PrintListOfArr(List<int[]> list)
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

    public static void PrintArr(int[] arr)
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
    public static class ConsoleVisualizer
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

        public static void VisualHook(int[,] grid, bool[,] visited, bool[,] path, int currentRow, int currentCol, int eRow, int eCol)
        {
            
            string[,] canvas = RenderGrid(grid, visited,path, currentRow, currentCol, eRow, eCol);

            
            DrawStep(canvas);

            
            System.Threading.Thread.Sleep(50);
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

}
