using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using static Brute_Force.Utilites.BruteForceVisualizer;

namespace Brute_Force;

// brute force for integers
public static class BruteForce
{
    // 1. Linear Search by Index
    public static int LinearSearch(int[] arr, int target, Action<int, string>? onStepChecked = null)
    {

        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            onStepChecked?.Invoke(i, $"Checking index {i} with value {target}..");
            if (arr[i] == target)
            {

                return i;
            }
        }
        return -1;
    }
    // Linear Search by Existance
    public static bool Contains(int[] arr, int target, Action<int, string>?onStepChecked = null)
    {
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {

            onStepChecked?.Invoke(i, $"Checking index {i} with value {target}..");
            if (arr[i] == target)
            {
                return true;
            }
        }
        return false;
    }
    // Linear Search Appearnce Count
    public static int AppearanceCount(int[] arr, int target, Action<int, string>? onStepChecked = null)
    {
        int count = 0;
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            onStepChecked?.Invoke(i, $"Checking index {i} with value {target}..");
            if (arr[i] == target)
            {
                count++;
            }
        }
        return count;
    }
    // Linear Search Finding Min
    public static int Min(int[] arr, Action<int, string>? onStepCheck = null)
    {
        int min = int.MaxValue;
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {

            onStepCheck?.Invoke(i, $"Checking index {i} with value {min}..");
            if (arr[i] < min)
            {
                min = arr[i];
            }
        }

        return min;
    }
    // Linear Search Finding Max
    public static int Max(int[] arr, Action<int, string>? onStepCheck = null)
    {
        int max = int.MinValue;
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {
            onStepCheck?.Invoke(i, $"Checking index {i} with value {max}..");
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }
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
    public static bool HasDuplicates(int[] arr, Action<int, int, string> ?onStepChecked = null)
    {
        int len = arr.Length;
        for (int i = 0; i < len; i++)
        {

            for (int j = i + 1; j < len; j++)
            {
                onStepChecked?.Invoke(i, j, "Checking for duplicates...");
                if (arr[i] == arr[j])
                {
                    onStepChecked?.Invoke(i, j, $"Result: True (Duplicate found: number {arr[i]} at index {i} and {j})");
                    return true;

                }
            }
        }
        onStepChecked?.Invoke(-1, -1, "Result: False (No duplicates found)");
        return false;
    }
    // Nested Loop Duplicate Clearance
    public static List<int> RemoveDuplicates(int[] arr, Action<int, int, string>? onStepChecked = null)
    {
        int len = arr.Length;
        List<int> result = new();
        for (int i = 0; i < len; i++)
        {
            bool exists = false;
            if (result.Count == 0)
            {
                string currentState = $"Current Result: [{string.Join(", ", result)}]";
                onStepChecked?.Invoke(i, -1, currentState);
            }
            for (int j = 0; j < result.Count; j++)
            {
                string currentState = $"Current Result: [{string.Join(", ", result)}]";
                onStepChecked?.Invoke(i, j, currentState);
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
    public static int[] TwoSum(int[] arr, int target, Action<int, int, string>? onStepChecked = null)
    {
        int complement;
        int len = arr.Length;

        for (int i = 0; i < len; i++)
        {
            complement = target - arr[i];
            for (int j = i + 1; j < len; j++)
            {
                onStepChecked?.Invoke(i, j, $"Checking: {arr[i]} + {arr[j]} ==  {target} ?");
                if (complement == arr[j])
                {
                    return [i, j];
                }
            }
        }
        return [-1, -1];
    }
    //Nested Loop Unique Pairs
    public static List<int[]> GetUniquePairs(int[] arr, Action<int, int, string>? onStepChecked = null)
    {

        List<int[]> result = new();
        int len = arr.Length;

        for (int i = 0; i < len; i++)
        {
            for (int j = i; j < len; j++)
            {
                result.Add([arr[i], arr[j]]);
                onStepChecked?.Invoke(i, j, $"Creating pair: [{arr[i]},{arr[j]}] | Total pairs so far: {result.Count}");
            }
        }
        return result;

    }
    //Nested Loop All Possible Pairs 
    public static List<int[]> GetPairs(int[] arr, Action<int, int, string>? onStepChecked = null)
    {

        List<int[]> result = new();
        int len = arr.Length;

        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                result.Add([arr[i], arr[j]]);
                onStepChecked?.Invoke(i, j, $"Creating pair: [{arr[i]},{arr[j]}] | Total pairs so far: {result.Count}");
            }
        }
        return result;

    }
    // Nested Loop Sub Arrays
    public static List<int[]> SubArrays(int[] arr, Action<int, int, string> ?onStepChecked = null)
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
                string currentSubText = "[" + string.Join(", ", sub) + "]";
                onStepChecked?.Invoke(start, end, $"Extracting Subarray: {currentSubText} | Total so far: {result.Count}");
            }
        }
        return result;
    }
    // BitMask Subsets
    public static List<int[]> Subsets_BitMask(int[] arr, Action<int, int, string>? onStepChecked = null)
    {
        List<int[]> result = new();
        int len = arr.Length;
        int total = 1 << len;

        for (int mask = 0; mask < total; mask++)
        {
            List<int> subset = new();
            string binaryStr = Convert.ToString(mask, 2).PadLeft(len, '0');

            for (int i = 0; i < len; i++)
            {
                bool take = (mask & (1 << i)) != 0;
                if (take)
                {
                    subset.Add(arr[i]);
                    onStepChecked?.Invoke(i, -1, $"Mask {mask} ({binaryStr}) -> Taking Element: {arr[i]}");
                }
                else
                {
                    onStepChecked?.Invoke(-1, i, $"Mask {mask} ({binaryStr}) -> Skipping Element: {arr[i]}");
                }
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
    public static List<int[]> Subsets_Recursive(int[] arr, Action<int, int, string>? onStepChecked = null)
    {
        // Driver
        List<int[]> result = new();
        var currentSubset = new List<int>();
        int index = 0;
        GetSubset(arr, index, currentSubset, result, onStepChecked);
        return result;
    }
    private static void GetSubset(int[] arr, int index, List<int> current, List<int[]> result, Action<int, int, string>? onStepChecked)
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
            string currentPathText = "[" + string.Join(", ", current) + "]";

            current.Add(arr[index]);
            onStepChecked?.Invoke(index, -1, $"Recursion Depth {index} -> TAKE [{arr[index]}] | Current Subset: {currentPathText}");

            GetSubset(arr, index + 1, current, result, onStepChecked);
            current.RemoveAt(current.Count - 1);
            onStepChecked?.Invoke(-1, index, $"Recursion Depth {index} -> SKIP [{arr[index]}] | Current Subset: {currentPathText}");
            GetSubset(arr, index + 1, current, result, onStepChecked);
        }
    }
    // Recursive Unique Permuations
    public static List<int[]> PermutationsUnique_Recursive(int[] arr, Action<int, int, string>? onStepChecked = null)
    {
        //Driver
        var current = new List<int>();
        var len = arr.Length;
        var used = new bool[len];
        var result = new List<int[]>();
        PermutationsUnique_Recursive(arr, current, used, result, onStepChecked);
        return result;
    }
    private static void PermutationsUnique_Recursive(int[] arr, List<int> current, bool[] used, List<int[]> result, Action<int, int, string>? onStepChecked = null)
    {
        //Helper
        int len = arr.Length;
        if (current.Count == len)
        {
            result.Add(current.ToArray());

            string fullText = "[" + string.Join(", ", current) + "]";
            onStepChecked?.Invoke(-1, -1, $"✨ FOUND FULL PERMUTATION: {fullText} ✨");
            return;
        }
        for (int i = 0; i < len; i++)
        {
            string currentText = "[" + string.Join(", ", current) + "]";

            if (used[i])
            {
                onStepChecked?.Invoke(-1, i, $"Checking index {i} ({arr[i]}): Already Used! | Current: {currentText}");
                continue;
            }
            current.Add(arr[i]);
            used[i] = true;

            onStepChecked?.Invoke(i, -1, $"➔ TAKE index {i} ({arr[i]}) | Current: {currentText}");

            PermutationsUnique_Recursive(arr, current, used, result, onStepChecked);
            current.RemoveAt(current.Count - 1);
            used[i] = false;

            onStepChecked?.Invoke(-1, i, $"↩ BACKTRACK: Freeing index {i} ({arr[i]}) | Current: {currentText}");

            
        }
    }
    // Count Of Unique Permutation 
    public static long CountPermutationUnique(int[] arr)
    {
        return Factorial_Iterative(arr.Length);
    }
    // Recursive All Possible Permutations 
    public static List<int[]> Permutations_Recursive(int[] arr, Action<int, int, string>? onStepChecked = null)
    {
        //Driver
        var current = new List<int>();
        var len = arr.Length;
        var result = new List<int[]>();
        Permutations_Recursive(arr, current, result, onStepChecked);
        return result;
    }
    private static void Permutations_Recursive(int[] arr, List<int> current, List<int[]> result, Action<int, int, string>? onStepChecked)
    {
        //Helper
        int len = arr.Length;
        if (current.Count == len)
        {
            result.Add(current.ToArray());
            string fullText = "[" + string.Join(", ", current) + "]";
            onStepChecked?.Invoke(-1, -1, $"✨ FOUND FULL PERMUTATION: {fullText} ✨");
            return;
        }
        for (int i = 0; i < len; i++)
        {
            string currentText = "[" + string.Join(", ", current) + "]";

            current.Add(arr[i]);

            onStepChecked?.Invoke(i, -1, $"➔ TAKE index {i} ({arr[i]}) | Current: {currentText}");

            Permutations_Recursive(arr, current, result, onStepChecked);

            current.RemoveAt(current.Count - 1);

            string textAfterBacktrack = "[" + string.Join(", ", current) + "]";
            onStepChecked?.Invoke(-1, i, $"↩ BACKTRACK: Freeing index {i} ({arr[i]}) | Current: {textAfterBacktrack}");
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
    public static List<int[]> CombinationsK_Recursive(int k, int[] array,Action<int,int,string>? onStepChecked = null)
    {
        // Driver
        List<int[]> result = new();
        if (k > array.Length) return result;
        List<int> current = new();
        int start = 0;
        CombinationsK_Recursive(array, start, k, current, result, onStepChecked);
        return result;
    }
    private static void CombinationsK_Recursive(int[] arr, int start, int k, List<int> current, List<int[]> result, Action<int, int, string>? onStepChecked)
    {
        // Helper
        if (current.Count == k)
        {
            result.Add(current.ToArray());
            string fullText = "[" + string.Join(", ", current) + "]";
            onStepChecked?.Invoke(-1, -1, $"✨ FOUND COMBINATION OF SIZE {k}: {fullText} ✨");
            return;
        }
        for (int i = start; i < arr.Length; i++)
        {
            string currentText = "[" + string.Join(", ", current) + "]";
            current.Add(arr[i]);
            onStepChecked?.Invoke(i, -1, $"➔ TAKE index {i} ({arr[i]}) | Start index was: {start} | Current: {currentText}");

            CombinationsK_Recursive(arr, i + 1, k, current, result, onStepChecked);

            current.RemoveAt(current.Count - 1);
            string textAfterBacktrack = "[" + string.Join(", ", current) + "]";
            onStepChecked?.Invoke(-1, i, $"↩ BACKTRACK: Freeing index {i} ({arr[i]}) | Current: {textAfterBacktrack}");
        }
    }
    // Recursive Combination Sum
    public static List<int[]> CombinationsSum_Recursive(int target, int[] arr,Action<int,int,string>? onStepChecked = null)
    {
        // Driver
        List<int[]> result = new();
        List<int> current = new();
        int start = 0;
        int sum = 0;
        CombinationsSum_Recursive(arr, start, target, sum, current, result, onStepChecked);
        return result;
    }
    private static void CombinationsSum_Recursive(int[] arr, int start, int target, int currentSum, List<int> current, List<int[]> result, Action<int, int, string>? onStepChecked)
    {
        // Helper
        if (currentSum == target)
        {
            result.Add(current.ToArray());

            string fullText = "[" + string.Join(", ", current) + "]";
            onStepChecked?.Invoke(-1, -1, $"✨ SUCCESS! Found Target Sum ({target}): {fullText} ✨");
            return;
        }
        if (currentSum > target)
        {
            string fullText = "[" + string.Join(", ", current) + "]";
            // إشارة سريعة للمستخدم أن المجموع الحالي (currentSum) تخطى الـ target
            onStepChecked?.Invoke(-1, -1, $"❌ INVALID: Sum ({currentSum}) > Target ({target}) | Path: {fullText}");
            return;
        }
        for (int i = start; i < arr.Length; i++)
        {
            string currentText = "[" + string.Join(", ", current) + "]";

            current.Add(arr[i]);
            onStepChecked?.Invoke(i, -1, $"➔ TAKE index {i} ({arr[i]}) | Current Sum: {currentSum + arr[i]} | Current Path: {currentText}");

            CombinationsSum_Recursive(arr, i + 1, target, currentSum + arr[i], current, result,onStepChecked);
            current.RemoveAt(current.Count - 1);

            string textAfterBacktrack = "[" + string.Join(", ", current) + "]";
            onStepChecked?.Invoke(-1, i, $"↩ BACKTRACK: Freeing index {i} ({arr[i]}) | Restoring Sum: {currentSum} | Current Path: {textAfterBacktrack}");

        }
    }



}
