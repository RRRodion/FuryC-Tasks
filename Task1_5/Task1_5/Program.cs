// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        Console.Write("введи x ");
        var num = 0;
        
        while (!int.TryParse(Console.ReadLine(), out num))
            Console.WriteLine("Введенная строка не являлась числом.");
        
        foreach (var variable in Chet(num))
            Console.WriteLine(variable);
    }

    private static List<int> Chet(int x)
    {
        var someList = new List<int>();

        for (var i = 0; i <= x; i += 2)
            someList.Add(i);

        return someList;
    }
}