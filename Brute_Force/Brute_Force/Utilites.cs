using System;
using System.Collections.Generic;
using System.Text;


namespace Brute_Force;

public static class Utilites
{
    // Console rendering utility functions

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

        public static void VisualHook(int[,] grid, bool[,] visited, bool[,] path, int currentRow, int currentCol, int eRow, int eCol, int delayMs = 100)
        {

            string[,] canvas = RenderGrid(grid, visited, path, currentRow, currentCol, eRow, eCol);


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
                    Console.ForegroundColor = ConsoleColor.Blue;
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
            Console.SetCursorPosition(0, 1);

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
            DrawStep(arr, currentIndex, secondaryIndex, "");
            System.Threading.Thread.Sleep(delayMs);
        }

        public static class Simulation
        {
            public static void LinearSearch(int[] arr, int target, int delayMs = 1000)
            {
                Console.Clear();
                int resultIndex = BruteForce.LinearSearch(arr, target, (i, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, i, -1, statusMessage);

                    System.Threading.Thread.Sleep(delayMs);
                });
                Console.Clear();
                if (resultIndex != -1)
                {
                    BruteForceVisualizer.DrawStep(arr, -1, -1, $"Result: Found at index {resultIndex}");
                }
                else
                {
                    BruteForceVisualizer.DrawStep(arr, -1, -1, $"Result: Not Found (-1)");
                }

            }
            public static void Contains(int[] arr, int target, int delayMs = 1000)
            {
                Console.Clear();
                bool resultIndex = BruteForce.Contains(arr, target, (i, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, i, -1, statusMessage);

                    System.Threading.Thread.Sleep(delayMs);
                });
                Console.Clear();
                if (resultIndex != false)
                {
                    BruteForceVisualizer.DrawStep(arr, -1, -1, $"Result: True ({target} is found inside the array.)");
                }
                else
                {
                    BruteForceVisualizer.DrawStep(arr, -1, -1, $"Result: False ({target} is not found inside the array.)");
                }
            }
            public static void AppearanceCount(int[] arr, int target, int delayMs = 1000)
            {
                Console.Clear();
                int finalCount = BruteForce.AppearanceCount(arr, target, (i, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, i, -1, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });
                Console.Clear();
                BruteForceVisualizer.DrawStep(arr, -1, -1, $"Result: Number {target} Appeared {finalCount} times");
            }
            public static void Min(int[] arr, int delayMs = 1000)
            {
                Console.Clear();
                int min = BruteForce.Min(arr, (i, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, i, -1, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });
                Console.Clear();
                BruteForceVisualizer.DrawStep(arr, -1, -1, $"Result: Min number is {min}");
            }
            public static void Max(int[] arr, int delayMs = 1000)
            {
                Console.Clear();
                int max = BruteForce.Max(arr, (i, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, i, -1, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });
                Console.Clear();
                BruteForceVisualizer.DrawStep(arr, -1, -1, $"Result: Max number is {max}");
            }
            public static void HasDuplicates(int[] arr, int delayMs = 1000)
            {
                Console.Clear();
                BruteForce.HasDuplicates(arr, (i, j, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, i, j, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });

            }

            public static void RemoveDuplicates(int[] arr, int delayMs = 1000)
            {
                Console.Clear();
                List<int> finalResult = BruteForce.RemoveDuplicates(arr, (i, j, listState) =>
                {
                    BruteForceVisualizer.DrawStep(arr, i, j, listState);
                    System.Threading.Thread.Sleep(delayMs);
                });
                string finalMessage = $"Final Result (No Duplicates): [{string.Join(", ", finalResult)}]";
                BruteForceVisualizer.DrawStep(arr, -1, -1, finalMessage);

            }
            public static void TwoSum(int[] arr, int target, int delayMs = 1000)
            {
                Console.Clear();
                int[] finalResult = BruteForce.TwoSum(arr, target, (i, j, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, i, j, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });
                if (finalResult is not [-1, -1])
                {
                    BruteForceVisualizer.DrawStep(arr, -1, -1, $"Result: Two Sum of {target} at indexes {finalResult[0]}, {finalResult[1]}.");
                }
                else
                {
                    BruteForceVisualizer.DrawStep(arr, -1, -1, $"Result: There's no Two Sum for {target}).");
                }
            }
            public static void GetUniquePairs(int[] arr, int delayMs = 1000)
            {
                Console.Clear();
                List<int[]> finalPairs = BruteForce.GetUniquePairs(arr, (i, j, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, i, j, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });
                Console.Clear();
                var pairsText = string.Join(", ", finalPairs.Select
                    (p => $"[{p[0]},{p[1]}]"));
                string finalMessage = $"Result: Generated {finalPairs.Count} pairs.\nPairs: {pairsText}";

                BruteForceVisualizer.DrawStep(arr, -1, -1, finalMessage);

            }

            public static void GetPairs(int[] arr, int delayMs = 1000)
            {
                Console.Clear();
                List<int[]> finalPairs = BruteForce.GetPairs(arr, (i, j, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, i, j, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });
                Console.Clear();
                var pairsText = string.Join(", ", finalPairs.Select
                    (p => $"[{p[0]},{p[1]}]"));
                string finalMessage = $"Result: Generated {finalPairs.Count} pairs.\nPairs: {pairsText}";

                BruteForceVisualizer.DrawStep(arr, -1, -1, finalMessage);

            }

            public static void SubArrays(int[] arr, int delayMs = 1000)
            {
                Console.Clear();

                List<int[]> finalSubArrays = BruteForce.SubArrays(arr, (start, end, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, start, end, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });

                Console.Clear();

                string finalMessage = $"Result: Generated {finalSubArrays.Count} Subarrays successfully.";

                BruteForceVisualizer.DrawStep(arr, -1, -1, finalMessage);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                foreach (var sub in finalSubArrays)
                {
                    Console.Write($"[{string.Join(",", sub)}] ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }

            public static void Subsets_BitMask(int[] arr, int delayMs = 1000)
            {
                Console.Clear();

                List<int[]> finalSubsets = BruteForce.Subsets_BitMask(arr, (activeIdx, skipIdx, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, activeIdx, skipIdx, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });

                Console.Clear();

                string finalMessage = $"Result: Generated {finalSubsets.Count} Subsets (Power Set) successfully.";
                BruteForceVisualizer.DrawStep(arr, -1, -1, finalMessage);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nGenerated Subsets:");
                foreach (var subset in finalSubsets)
                {
                    Console.WriteLine($"  [{string.Join(", ", subset)}]");
                }
                Console.ResetColor();
            }

            public static void Subsets_Recursive(int[] arr, int delayMs = 1000)
            {
                Console.Clear();

                List<int[]> finalSubsets = BruteForce.Subsets_Recursive(arr, (takeIdx, skipIdx, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, takeIdx, skipIdx, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });

                Console.Clear();

                string finalMessage = $"Result: Generated {finalSubsets.Count} Subsets via Recursion Tree.";
                BruteForceVisualizer.DrawStep(arr, -1, -1, finalMessage);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nAll Generated Subsets:");
                foreach (var subset in finalSubsets)
                {
                    Console.WriteLine($"  [{string.Join(", ", subset)}]");
                }
                Console.ResetColor();
            }
            public static void PermutationsUnique_Recursive(int[] arr, int delayMs = 1000)
            {
                Console.Clear();

                List<int[]> finalPermutations = BruteForce.PermutationsUnique_Recursive(arr, (activeIdx, skipIdx, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, activeIdx, skipIdx, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });

                Console.Clear();

                string finalMessage = $"Result: Generated {finalPermutations.Count} Unique Permutations successfully.";
                BruteForceVisualizer.DrawStep(arr, -1, -1, finalMessage);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nGenerated Permutations List:");
                foreach (var perm in finalPermutations)
                {
                    Console.WriteLine($"  [{string.Join(", ", perm)}]");
                }
                Console.ResetColor();
            }

            public static void Permutations_Recursive(int[] arr, int delayMs = 1000)
            {
                Console.Clear();

                List<int[]> finalPermutations = BruteForce.Permutations_Recursive(arr, (activeIdx, skipIdx, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, activeIdx, skipIdx, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });

                Console.Clear();

                string finalMessage = $"Result: Generated {finalPermutations.Count} Permutations (With Repetition) successfully.";
                BruteForceVisualizer.DrawStep(arr, -1, -1, finalMessage);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nGenerated Permutations List:");
                foreach (var perm in finalPermutations)
                {
                    Console.WriteLine($"  [{string.Join(", ", perm)}]");
                }
                Console.ResetColor();
            }

            public static void CombinationsK_Recursive(int k, int[] arr, int delayMs = 1000)
            {
                Console.Clear();

                List<int[]> finalCombinations = BruteForce.CombinationsK_Recursive(k, arr, (activeIdx, skipIdx, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, activeIdx, skipIdx, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });

                Console.Clear();

                string finalMessage = $"Result: Generated {finalCombinations.Count} Combinations of size {k} successfully.";
                BruteForceVisualizer.DrawStep(arr, -1, -1, finalMessage);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\nGenerated Combinations (Size {k}) List:");
                foreach (var comb in finalCombinations)
                {
                    Console.WriteLine($"  [{string.Join(", ", comb)}]");
                }
                Console.ResetColor();
            }

            public static void CombinationsSum_Recursive(int target, int[] arr, int delayMs = 1000)
            {
                Console.Clear();

                List<int[]> finalCombinations = BruteForce.CombinationsSum_Recursive(target, arr, (activeIdx, skipIdx, statusMessage) =>
                {
                    BruteForceVisualizer.DrawStep(arr, activeIdx, skipIdx, statusMessage);
                    System.Threading.Thread.Sleep(delayMs);
                });

                Console.Clear();

                string finalMessage = $"Result: Found {finalCombinations.Count} Combinations that sum up to {target}.";
                BruteForceVisualizer.DrawStep(arr, -1, -1, finalMessage);

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"\nValid Combinations (Sum = {target}) List:");
                foreach (var comb in finalCombinations)
                {
                    Console.WriteLine($"  [{string.Join(", ", comb)}]");
                }
                Console.ResetColor();
            }

        }
    }
}
