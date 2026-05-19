using System;
using System.Runtime.InteropServices;

namespace Brute_Force;

public static class Program

{
    static void p<T>(T t) => Console.Write($"{t}");

    public static void Main()
    {
        int[] nums = [1,2,3,4,5,6];
        int[] n = [1, 2, 3];
        int[] numbers = [1, 2, 3, 4, 5,6,7,8,9,10,11,12];

        var fact = BruteForce.CountPermutation(numbers);
        p(fact);






    }

}

