using System;

using System.Linq;
using System.Collections.Generic;

namespace Brute_Force;

public static class BruteForce
{
    public static int LinearSearch(int[] arr, int target)
    {

        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            if (arr[i] == target)
            {
                return i;
            }
        }
        return -1;
    }
    public static bool Contains(int[] arr, int target)
    {
        return LinearSearch(arr, target) != -1;
    }
    public static int AppearenceCount(int[] arr, int target)
    {
        int count = 0;
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            if (arr[i] == target)
            {
                count++;
            }
        }
        return count;
    }
    public static int Min(int[] arr)
    {
        int min = int.MaxValue;
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }
        return min;
    }

    public static int Max(int[] arr)
    {
        int max = int.MinValue;
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
        return max;
    }
    public static bool IsEven(int num)
    {
        return num % 2 == 0;
    }

    public static bool HasDuplicates(int[] arr)
    {

        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            for (int j = i + 1; j < len; j++)
            {
                if (arr[i] == arr[j])
                {

                    return true;
                }
            }
        }
        return false;
    }
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
    public static int[] TwoSum(int[] arr, int target)
    {

        int complement;
        int len = arr.Length;

        for (int i = 0; i < len; i++)
        {
            complement = target - arr[i];
            for (int j = i + 1; j < len; j++)
            {
                if (complement == arr[j])
                {
                    return [i, j];
                }
            }
        }
        return [-1, -1];
    }
    public static List<int[]> GetPairsWithSelf(int[] arr)
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
    public static List<int[]> GetSubArrays(int[] arr)
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
    public static List<int[]> GetSubSets(int[] arr)
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

    // Console rendering utility functions
    static void p<T>(T t) => Console.Write($"{t}");
    public static void PrintListOfArr(List<int[]> list)
    {
        foreach (var arr in list)
        {
            p("  [");
            int end = arr.Length;
            int count = 0;

            foreach (var item in arr)
            {
                p(item);
                count++;
                if (count == end) continue;
                p(", ");
            }
            p("]");
            Console.WriteLine();

        }
    }
    public static void PrintArr(int[] arr)
    {
        p("  [");
        int end = arr.Length;
        int count = 0;

        foreach (var item in arr)
        {
            p(item);
            count++;
            if (count == end) continue;
            p(", ");
        }
        p("]");
        Console.WriteLine();
    }
}



public static class Program

{
    static void p<T>(T t) => Console.Write($"{t}");

    public static void Main()
    {
        int[] nums = [6, 1, 2, 3, 7, 11, 4, 9, 8, 0, -1, 2];
        int[] n = [1, 2, 3, 4, 5, 6];

        var pairs = BruteForce.GetPairsWithSelf(n);
        BruteForce.PrintListOfArr(pairs);





    }

}

