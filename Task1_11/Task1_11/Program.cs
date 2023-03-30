// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var array = new[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 9, 10, 11 }, { 12, 13, 14 } };
        var rows = array.GetUpperBound(0) + 1;
        var columns = array.GetUpperBound(1) + 1;

        for (var i = 0; i < rows - 1; i += 2)
            for (var j = 0; j < columns; j++)
                (array[i, j], array[i + 1, j]) = (array[i + 1, j], array[i, j]);
        
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
                Console.Write($"{array[i, j]} \t");
            
            Console.WriteLine();
        }
    }
}