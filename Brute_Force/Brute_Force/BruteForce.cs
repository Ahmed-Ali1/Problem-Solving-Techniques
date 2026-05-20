using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
    public static long Factorial(int n)
    {
        if (n == 1) return 1;
        return Factorial(n - 1) * n;
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
    public static List<int[]> GetSubsetsBitMask(int[] arr)
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
    public static int CountSubsets(int[] arr)
    {
        return 1 << arr.Length;
    }

    public static List<int[]> GetSubsets(int[] arr)
    {
        List<int[]> result = new();
        var currentSubset = new List<int>();
        int index = 0;
        GetSubset(arr, index, currentSubset, result);
        return result;
    }
    private static void GetSubset(int[] arr, int index, List<int> current, List<int[]> result)
    {
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
    public static List<int[]> Permutations(int[] arr)
    {
        var current = new List<int>();
        var len = arr.Length;
        var used = new bool[len];
        var result = new List<int[]>();
        Permutations(arr, current, used, result);
        return result;
    }
    private static void Permutations(int[] arr, List<int> current, bool[] used, List<int[]> result  )
    {
        int len = arr.Length;
        if(current.Count == len)
        {
            result.Add(current.ToArray());
            return;
        }
        for(int i = 0; i < len; i++)
        {
            if (used[i] == false)
            {
                current.Add(arr[i]);
                used[i] = true;
                Permutations(arr, current, used, result);
                current.RemoveAt(current.Count - 1);
                used[i] = false;
            }
        }
    }
    public static long CountPermutation(int[] arr)
    {
        return Factorial(arr.Length);
    }
   
    public static List<int[]> PermutationsR(int[] arr)
    {
        var current = new List<int>();
        var len = arr.Length;
        var result = new List<int[]>();
        PermutationsR(arr, current, result);
        return result;
    }
    private static void PermutationsR(int[] arr, List<int> current, List<int[]> result)
    {
        int len = arr.Length;
        if (current.Count == len)
        {
            result.Add(current.ToArray());
            return;
        }
        for (int i = 0; i < len; i++)
        {
            current.Add(arr[i]);
            PermutationsR(arr, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }
    public static long CountPermutationR(int[] arr)
    {
        long len = (long)arr.Length;
        return (long)Math.Pow(len, len);
    }

    public static List<int[]> K_Combinations(int k , int[] arr)
    {
        List<int[]> result = new();
        List<int> current = new();
        int start = 0;
        K_Combinations(arr, start, k, current, result);
        return result;
    }
    private static void K_Combinations(int[] arr, int start,int k, List<int> current, List<int[]> result)
    {
        if (current.Count == k)
        {
            result.Add(current.ToArray());
            return;
        }
       
        for(int i = start; i < arr.Length; i++)
        {
            current.Add(arr[i]);
            K_Combinations(arr, i + 1,k, current, result);
            current.RemoveAt(current.Count - 1);
        }
    }

    public static List<int[]> Combinations_Sum(int target, int[] arr)
    {
        List<int[]> result = new();
        List<int> current = new();
        int start = 0;
        int sum = 0;
        Combinations_Sum(arr, start, target, sum,  current, result);
        return result;
    }
    private static void Combinations_Sum(int[] arr, int start, int target,int currentSum, List<int> current, List<int[]> result)
    {
        
        if (currentSum == target)
        {
            result.Add(current.ToArray());
            return;
        }
        if (currentSum > target) return;
        for (int i = start; i < arr.Length; i++)
        {
            
            current.Add(arr[i]);
            Combinations_Sum(arr, i + 1, target, currentSum + arr[i], current, result);
            current.RemoveAt(current.Count - 1);
        }
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
    public static void PrintBinaryMasks(int[] arr)
    {
        int len = arr.Length;
        int total = 1 << len;
        for (int mask = 0; mask < total; mask++)
        {
            Console.WriteLine(Convert.ToString(mask, 2).PadLeft(len, '0'));
        }
    }
}
