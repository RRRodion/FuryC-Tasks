// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите текст");
        var s = Console.ReadLine();
        Console.WriteLine(s.Replace('C', 'E'));
    }
}