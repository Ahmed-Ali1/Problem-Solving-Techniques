using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using static Brute_Force.Utilites.BruteForceVisualizer;

namespace Brute_Force;

// brute force for integers
public static class BruteForce
{
    // 1. Linear Search by Index
    public static int LinearSearch(int[] arr, int target)
    {

        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            VisualHook(arr, i);
            if (arr[i] == target)
            {
                DrawStep(arr, i, -1, $"Result: Found at index {i}");
                return i;
            }
        }
        DrawStep(arr, -1, -1, $"Result: Not Found (-1)");
        return -1;
    }
    // Linear Search by Existance
    public static bool Contains(int[] arr, int target)
    {
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            VisualHook (arr, i);
            if (arr[i] == target)
            {
                DrawStep(arr, i, -1, $"Result: True (Array Contains number {target})");
                return true;
            }
        }
        DrawStep(arr, -1, -1, $"Result: False (Array doesn't contains number {target})");
        return false;
    }
    // Linear Search Appearnce Count
    public static int AppearenceCount(int[] arr, int target)
    {
        int count = 0;
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            VisualHook(arr, i);

            if (arr[i] == target)
            {
                count++;
            }
        }
        DrawStep(arr, -1, -1, $"Result: Number {target} Appeared {count} times");
        return count;
    }
    // Linear Search Finding Min
    public static int Min(int[] arr)
    {
        int min = int.MaxValue;
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            VisualHook(arr, i);
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        DrawStep(arr, -1, -1, $"Result: Min number is {min}");
        return min;
    }
    // Linear Search Finding Max
    public static int Max(int[] arr)
    {
        int max = int.MinValue;
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            VisualHook(arr, i,max);
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        DrawStep(arr, -1, -1, $"Result: Max number is {max}");
        return max;
    }
    // Recursive Factorail
    public static long Factorial_Recursive(int n)
    {
        if (n == 1) return 1;
        return Factorial_Recursive(n - 1) * n;
    }
    // Iterative Factorial
    public static long Factorial_Iterative(int n)
    {
        long factorial = (long)n;
        for (int i = n; i > 1; i--)
        {
            factorial = factorial * (i - 1);
        }
        return factorial;

    }

    public static bool IsEven(int num)
    {
        return num % 2 == 0;
    }
    // Nested Loop Duplicate Existance
    public static bool HasDuplicates(int[] arr)
    {
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            
            for (int j = i + 1; j < len; j++)
            {
                VisualHook(arr, i,j);
                if (arr[i] == arr[j])
                {
                    DrawStep(arr, i, j, $"Result: True (Duplicate found at index {i} , {j})");
                    return true;
                }
            }
        }
        DrawStep(arr, -1, -1, $"Result: False (No duplicates)");
        return false;
    }
    // Nested Loop Duplicate Clearance
    public static List<int> RemoveDuplicates(int[] arr)
    {
        int len = arr.Length;
        List<int> result = new();
        for (int i = 0; i < len; i++)
        {
            bool exists = false;
            for (int j = 0; j < result.Count; j++)
            {
                if (arr[i] == result[j])
                {
                    exists = true;
                    break;
                }
            }
            if (!exists)
                result.Add(arr[i]);
        }
        return result;
    }
    // Nested Loop Sum Of Two
    public static int[] TwoSum(int[] arr, int target)
    {
        int complement;
        int len = arr.Length;

        for (int i = 0; i < len; i++)
        {
            complement = target - arr[i];
            for (int j = i + 1; j < len; j++)
            {
                VisualHook(arr, i, j);
                if (complement == arr[j])
                {
                    DrawStep(arr, i, j, $"Result: Two sum of {target} are indexes {i}, {j}");
                    return [i, j];
                }
            }
        }
        DrawStep(arr, -1, -1,$"Result: Two sum of {target} not found");
        return [-1, -1];
    }
    //Nested Loop Unique Pairs
    public static List<int[]> GetUniquePairs(int[] arr)
    {

        List<int[]> result = new();
        int len = arr.Length;

        for (int i = 0; i < len; i++)
        {

            for (int j = i; j < len; j++)
            {
                result.Add([arr[i], arr[j]]);
            }
        }
        return result;

    }
    //Nested Loop All Possible Pairs 
    public static List<int[]> GetPairs(int[] arr)
    {

        List<int[]> result = new();
        int len = arr.Length;

        for (int i = 0; i < len; i++)
        {

            for (int j = 0; j < len; j++)
            {
                result.Add([arr[i], arr[j]]);
            }
        }
        return result;

    }
    // Nested Loop Sub Arrays
    public static List<int[]> SubArrays(int[] arr)
    {
        List<int[]> result = new();
        int len = arr.Length;
        for (int start = 0; start < len; start++)
        {
            for (int end = start; end < len; end++)
            {
                int size = end - start + 1;
                int[] sub = new int[size];
                int index = 0;
                for (int k = start; k <= end; k++)
                {
                    sub[index] = arr[k];
                    index++;
                }
                result.Add(sub);
            }
        }
        return result;
    }
    // BitMask Subsets
    public static List<int[]> Subsets_BitMask(int[] arr)
    {
        List<int[]> result = new();
        int len = arr.Length;
        int total = 1 << len;

        for (int mask = 0; mask < total; mask++)
        {
            List<int> subset = new();
            for (int i = 0; i < len; i++)
            {
                bool take = (mask & (1 << i)) != 0;
                if (take) subset.Add(arr[i]);
            }
            result.Add(subset.ToArray());
        }
        return result;
    }
    // Subset Count Bit
    public static int CountSubsets(int[] arr)
    {
        return 1 << arr.Length;
    }
    // Recursive Subsets
    public static List<int[]> Subsets_Recursive(int[] arr)
    {
        // Driver
        List<int[]> result = new();
        var currentSubset = new List<int>();
        int index = 0;
        GetSubset(arr, index, currentSubset, result);
        return result;
    }
    private static void GetSubset(int[] arr, int index, List<int> current, List<int[]> result)
    {
        // Helper
        int len = arr.Length;
        if (index == len)
        {
            result.Add(current.ToArray());
            return;
        }
        else
        {
            current.Add(arr[index]);
            GetSubset(arr, index + 1, current, result);
            current.RemoveAt(current.Count - 1);
            GetSubset(arr, index + 1, current, result);
        }
    }
    // Recursive Unique Permuations
    public static List<int[]> PermutationsUnique_Recursive(int[] arr)
    {
        //Driver
        var current = new List<int>();
        var len = arr.Length;
        var used = new bool[len];
        var result = new List<int[]>();
        PermutationsUnique_Recursive(arr, current, used, result);
        return result;
    }
    private static void PermutationsUnique_Recursive(int[] arr, List<int> current, bool[] used, List<int[]> result)
    {
        //Helper
        int len = arr.Length;
        if (current.Count == len)
        {
            result.Add(current.ToArray());
            return;
        }
        for (int i = 0; i < len; i++)
        {
            if (used[i] == false)
            {
                current.Add(arr[i]);
                used[i] = true;
                PermutationsUnique_Recursive(arr, current, used, result);
                current.RemoveAt(current.Count - 1);
                used[i] = false;
            }
        }
    }
    // Count Of Unique Permutation 
    public static long CountPermutationUnique(int[] arr)
    {
        return Factorial_Iterative(arr.Length);
    }
    // Recursive All Possible Permutations 
    public static List<int[]> Permutations_Recursive(int[] arr)
    {
        //Driver
        var current = new List<int>();
        var len = arr.Length;
        var result = new List<int[]>();
        Permutations_Recursive(arr, current, result);
        return result;
    }
    private static void Permutations_Recursive(int[] arr, List<int> current, List<int[]> result)
    {
        //Helper
        int len = arr.Length;
        if (current.Count == len)
        {
            result.Add(current.ToArray());
            return;
        }
        for (int i = 0; i < len; i++)
        {
            current.Add(arr[i]);
            Permutations_Recursive(arr, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
    // Count of All Possible Permutation
    public static long CountPermutation(int[] arr)
    {
        long len = (long)arr.Length;
        return (long)Math.Pow(len, len);
    }

    /// <summary>
    /// Return List Of k-Combinations of array of integers
    /// </summary>
    /// <param name="k"></param>
    /// <param name="array"></param>
    /// <returns></returns>
    public static List<int[]> CombinationsK_Recursive(int k, int[] array)
    {
        // Driver
        List<int[]> result = new();
        List<int> current = new();
        int start = 0;
        CombinationsK_Recursive(array, start, k, current, result);
        return result;
    }
    private static void CombinationsK_Recursive(int[] arr, int start, int k, List<int> current, List<int[]> result)
    {
        // Helper
        if (current.Count == k)
        {
            result.Add(current.ToArray());
            return;
        }
        for (int i = start; i < arr.Length; i++)
        {
            current.Add(arr[i]);
            CombinationsK_Recursive(arr, i + 1, k, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
    // Recursive Combination Sum
    public static List<int[]> CombinationsSum_Recursive(int target, int[] arr)
    {
        // Driver
        List<int[]> result = new();
        List<int> current = new();
        int start = 0;
        int sum = 0;
        CombinationsSum_Recursive(arr, start, target, sum, current, result);
        return result;
    }
    private static void CombinationsSum_Recursive(int[] arr, int start, int target, int currentSum, List<int> current, List<int[]> result)
    {
        // Helper
        if (currentSum == target)
        {
            result.Add(current.ToArray());
            return;
        }
        if (currentSum > target) return;
        for (int i = start; i < arr.Length; i++)
        {

            current.Add(arr[i]);
            CombinationsSum_Recursive(arr, i + 1, target, currentSum + arr[i], current, result);
            current.RemoveAt(current.Count - 1);
        }
    }



}
