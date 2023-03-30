// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var array = new[] { 1, 2, 3, 4 };

        for (var i = 0; i < array.Length; i++)
            for (var j = 0; j < array.Length; j++)
                if (array[i] < 0 && array[j] < 0 && array[i] < array[j])
                    (array[i], array[j]) = (array[j], array[i]);

        foreach (var variable in array)
            Console.Write($"{variable} ");
    }
}