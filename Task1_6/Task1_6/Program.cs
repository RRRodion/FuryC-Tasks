// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

class Program
{
    public static void Main()
    {
        Console.Write("введи x ");

        if (!int.TryParse(Console.ReadLine(), out var number))
        {
            Console.WriteLine("Введенная строка не являлась числом.");
            return;
        }

        var perfectNumbers = PerfectNumbers(number);

        if (perfectNumbers.Count == 0)
        {
            Console.WriteLine("Совершенных чисел нет.");
            return;
        }

        foreach (var variable in perfectNumbers)
            Console.WriteLine(variable);
    }

    private static List<int> PerfectNumbers(int number)
    {
        var perfectNumbers = new List<int>();

        for (var i = 1; i <= number; i++)
        {
            var y = 0;

            for (var del = 1; del <= i / 2; del++)
                if (i % del == 0)
                    y += del;

            if (y == i)
                perfectNumbers.Add(i);
        }

        return perfectNumbers;
    }
}