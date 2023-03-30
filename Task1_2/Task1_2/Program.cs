// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program 
{
    public static void Main()
    {
        Console.Write("введи число ");
        var s = Console.ReadLine()!;
        
        if (int.TryParse(s, out _))
            Console.WriteLine(s.Reverse().ToArray());
        else
            Console.WriteLine("Введенная строка не являлась числом.");
    }
}