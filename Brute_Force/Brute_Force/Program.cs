using System;
using System.Runtime.InteropServices;
using static Brute_Force.Utilites;
using static Brute_Force.Generator;
using static Brute_Force.Maze;
using static Brute_Force.WordSearch;
using System.Runtime.CompilerServices;
using System.Security;

namespace Brute_Force;

public static class Program

{
    [DllImport("user32.dll")]
    private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

    private const byte VK_F11 = 0x7A;
    private const uint KEYEVENTF_KEYUP = 0x0002;
    static void StartSolveMaze()
    {
        var maze = GenerateMaze();
        SolveMaze(maze);
    }
    static void StartSearchWord(string word)
    {
        var grid = GenerateGridWithWord(20, 20, word);
        Exist(grid, word);
    }
    public static void Main()
    {
        
     
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        System.Threading.Thread.Sleep(100);
        keybd_event(VK_F11, 0, 0, 0);
        keybd_event(VK_F11, 0, KEYEVENTF_KEYUP, 0)         ;
        System.Threading.Thread.Sleep(100);
        Console.CursorVisible = false;
        Console.Clear();

        //StartSolveMaze();
        StartSearchWord("BRUTEFORCE");
        //BruteForceVisualizer.Simulation.LinearSearch([1,2,3],3,1000);
        //BruteForceVisualizer.Simulation.RemoveDuplicates([1, 2, 3, 1, 2, 3, 4], 1000);


    }

}

