// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public class Program
{
    public static void Main()
    {
        var n = RequestNumber("n");
        var m = RequestNumber("m");
        var x = RequestNumber("x");
        var sum = 0;

        for (var i = x; i <= x + (n - 1) * m; i += m)
            sum += i;
        
        Console.WriteLine(sum);
    }

    private static int RequestNumber(string nameVariable)
    {
        var number = 0;
        Console.Write($"введи число {nameVariable}");

        while (!int.TryParse(Console.ReadLine(), out number))
            Console.WriteLine("Введенная строка не являлась числом");

        return number;
    }
}