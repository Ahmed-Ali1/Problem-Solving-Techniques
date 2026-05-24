using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static Brute_Force.Utilites;

namespace Brute_Force;

// Brute force for strings
public static class StringBruteForce
{
    public static int IndexOf(string text, char target)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == target)
            {
                return i;
            }
        }
        return -1;
    }
    public static int LastIndexOf(string text, char target)
    {
        for (int i = text.Length - 1; i >= 0; i--)
        {
            if (text[i] == target)
            {
                return i;
            }
        }
        return -1;
    }
    public static bool Contains(string text, char target)
    {
        return IndexOf(text, target) != -1;
    }
    public static int Count(string text, char target)
    {
        int count = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == target)
                count++;
        }
        return count;
    }
    public static int[] AllIndices(string text, char target)
    {
        List<int> result = [];
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == target)
            {
                result.Add(i);
            }
        }
        return result.ToArray();
    }
    public static List<string> SubStrings(string text)
    {
        List<string> result = [];
        int len = text.Length;
        for (int start = 0; start < len; start++)
        {
            for (int end = start; end < len; end++)
            {
                int size = end - start + 1;
                char[] sub = new char[size];
                int index = 0;
                for (int k = start; k <= end; k++)
                {
                    sub[index] = text[k];
                    index++;
                }
                result.Add(new string(sub));
            }
        }
        return result;
    }
    public static bool ContainsPattern(string text, string pattern)
    {
        int end = text.Length - pattern.Length;

        for (int i = 0; i <= end; i++)
        {
            bool match = true;
            for (int j = 0; j < pattern.Length; j++)
            {
                if (pattern[j] != text[i + j])
                {
                    match = false;
                    break;
                }
            }
            if (match)
                return true;
        }
        return false;
    }
    public static int IndexOfPattern(string text, string pattern)
    {
        int end = text.Length - pattern.Length;

        for (int i = 0; i <= end; i++)
        {
            bool match = true;
            for (int j = 0; j < pattern.Length; j++)
            {
                if (pattern[j] != text[i + j])
                {
                    match = false;
                    break;
                }
            }
            if (match)
                return i;
        }
        return -1;
    }
    public static List<string> SubStrings_ContainChar(string text, char target)
    {
        List<string> result = [];
        int len = text.Length;
        for (int start = 0; start < len; start++)
        {
            for (int end = start; end < len; end++)
            {
                int size = end - start + 1;
                char[] sub = new char[size];
                int index = 0;
                for (int k = start; k <= end; k++)
                {
                    sub[index] = text[k];
                    index++;
                }
                var newSub = new string(sub);
                if (Contains(newSub, target))
                {
                    result.Add(newSub);
                }

            }
        }
        return result;
    }

    public static List<string> SubStrings_ContainPattern(string text, string pattern)
    {
        List<string> result = [];
        int len = text.Length;
        for (int start = 0; start < len; start++)
        {
            for (int end = start; end < len; end++)
            {
                int size = end - start + 1;
                char[] sub = new char[size];
                int index = 0;
                for (int k = start; k <= end; k++)
                {
                    sub[index] = text[k];
                    index++;
                }
                var subString = new string(sub);
                if (ContainsPattern(subString, pattern))
                {
                    result.Add(subString);
                }
            }
        }
        return result;
    }

    public static List<string> PermutationsUnique_Recursive(string text)
    {
        //Driver
        StringBuilder current = new();
        var len = text.Length;
        var used = new bool[len];
        List<string> result = [];
        PermutationsUnique_Recursive(text, current, used, result);
        return result;
    }
    private static void PermutationsUnique_Recursive(string text, StringBuilder current, bool[] used, List<string> result)
    {
        //Helper
        int len = text.Length;
        if (current.Length == len)
        {
            result.Add(current.ToString());
            return;
        }
        for (int i = 0; i < len; i++)
        {
            if (used[i] == false)
            {
                current.Append(text[i]);
                used[i] = true;
                PermutationsUnique_Recursive(text, current, used, result);
                current.Length--;
                used[i] = false;
            }
        }
    }
    public static long CountPermutationUnique(string text)
    {
        return BruteForce.Factorial_Iterative(text.Length);
    }

    public static List<string> CombinationsK_Recursive(int k, string text)
    {
        // Driver
        List<string> result = new();
        StringBuilder current = new();
        int start = 0;
        CombinationsK_Recursive(text, start, k, current, result);
        return result;
    }
    private static void CombinationsK_Recursive(string text, int start, int k, StringBuilder current, List<string> result)
    {
        // Helper
        if (current.Length == k)
        {
            result.Add(current.ToString());
            return;
        }
        for (int i = start; i < text.Length; i++)
        {
            current.Append(text[i]);
            CombinationsK_Recursive(text, i + 1, k, current, result);
            current.Length--;
        }
    }

    public static List<string> Subsets_BitMask(string text)
    {
        List<string> result = new();
        int len = text.Length;
        int total = 1 << len;

        for (int mask = 0; mask < total; mask++)
        {
            StringBuilder subset = new();
            for (int i = 0; i < len; i++)
            {
                bool take = (mask & (1 << i)) != 0;
                if (take) subset.Append(text[i]);
            }
            result.Add(subset.ToString());
        }
        return result;
    }
    public static int CountSubsets(string text)
    {
        return 1 << text.Length;
    }
    public static List<string> GenerateParenthess(int number)

    {
        List<string> result = [];

        StringBuilder current = new("");
        int open = 0, close = 0;
        GenerateParenthess(number, current, open, close, result);
        return result;

    }
    private static void GenerateParenthess(int n, StringBuilder current, int open, int close, List<string> result)
    {
        if (open == n && close == n)
        {
            result.Add(current.ToString());
            Console.WriteLine(current.ToString());
            return;
        }
        if (open < n)
        {
            current.Append('(');

            GenerateParenthess(n, current, open + 1, close, result);
            current.Length--;
        }
        if (close < open)
        {
            current.Append(')');

            GenerateParenthess(n, current, open, close + 1, result);
            current.Length--;
        }
    }


    



}

