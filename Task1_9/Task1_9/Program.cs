// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var array = new[] { 1, 2, 3, 4, 5 };

        for (var i = 0; i < array.Length / 2; i++)
            (array[i], array[^(i + 1)]) = (array[^(i + 1)], array[i]);

        foreach (var variable in array)
            Console.Write($"{variable} ");
    }
}