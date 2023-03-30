// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var array = new[] { 1, 2, 3, 4 };
        var evenSum = 0;
        var oddSum = 0;

        for (var i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0)
                oddSum += array[i];
            else
                evenSum += array[i];
        }

        Console.WriteLine($"{evenSum}-четные \n{oddSum}-нечетные");
    }
}