// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var array = new[,]
        {
            { 0, 1, 2, 3, 4 }, { 5, 6, 7, 8, 9 }, { 10, 11, 12, 13, 14 }, { 15, 16, 17, 18, 19 }, { 20, 21, 22, 23, 24 }
        };
        var strings = array.GetLength(0);
        var columns = array.GetLength(1) - 1;

        for (var i = 0; i < strings; i++)
            (array[i, i], array[i, columns - i]) = (array[i, columns - i], array[i, i]);

        Console.WriteLine("массив после:");

        for (var i = 0; i < array.GetLength(0); i++)
        {
            for (var j = 0; j < array.GetLength(1); j++)
                Console.Write($"{array[i, j]}\t");

            Console.WriteLine();
        }
    }
}