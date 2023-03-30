// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var array = new[] { 1, 2, 3, 4 };
        var m = 2;
        var n = 3;
        var moreThanMSum = 0;
        var lessThanNSum = 0;

        foreach (var variable in array)
        {
            if (variable > m)
                moreThanMSum += variable;
            else if (variable < n)
                lessThanNSum += variable;
        }

        Console.WriteLine($"{moreThanMSum}-больше m \n{lessThanNSum}-меньше n");
    }
}