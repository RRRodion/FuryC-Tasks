// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var array = new[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 9, 10, 11 }, { 12, 13, 14 } };

        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
                Console.Write($"{array[i, j]}\t");

            Console.WriteLine();
        }

        var max = 0;
        var maxNumbers = new int[array.GetLength(1)];

        for (var j = 0; j < array.GetLength(1); j++)
        {
            for (var i = 0; i < array.GetLength(0); i++)
                if (array[i, j] > max)
                    max = array[i, j];

            maxNumbers[j] = max;
            max = 0;
        }

        Console.Write("Максимальные числa : ");

        foreach (var number in maxNumbers)
            Console.Write($"{number} ");
    }
}