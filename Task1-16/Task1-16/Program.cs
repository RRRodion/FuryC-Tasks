// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        Console.Write("введи строку ");
        var someString = Console.ReadLine();

        if (someString == null)
        {
            Console.WriteLine("получено null значение");
            return;
        }

        var arr = someString.ToCharArray();
        Array.Reverse(arr);
        Console.WriteLine(new string(arr));
    }
}