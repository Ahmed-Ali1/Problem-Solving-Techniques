using System;
using System.Runtime.InteropServices;

namespace Brute_Force;

public static class Program

{
    static void p<T>(T t) => Console.Write($"{t}");

    public static void Main()
    {
        int[] nums = [6, 1, 2, 3, 7, 11, 4, 9, 8, 0, -1, 2];
        int[] n = [1, 2, 3];

        var lst = BruteForce.GetSubsets(n);
        BruteForce.PrintListOfArr(lst);

        lst = BruteForce.GetSubsetsBitMask(n);
        BruteForce.PrintListOfArr(lst);






    }

}

