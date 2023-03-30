// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Text.RegularExpressions;

public static class Program
{
    public static void Main()
    {
        Console.Write("введи строку ");
        var s = Console.ReadLine()!;
        var count = 0;
        
        foreach (var variable in s)
            if (variable == 'A')
                count++;

        Console.WriteLine(count);
    }
}