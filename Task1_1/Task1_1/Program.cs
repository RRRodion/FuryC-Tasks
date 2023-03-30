// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        var nums = new int[3];
        Console.WriteLine("Введите числa: ");

        for (var i = 0; i < 3; i++)
        {
            var number = 0;

            while (!int.TryParse(Console.ReadLine(), out number))
                Console.WriteLine("ошибка");

            nums[i] = number;
        }

        Array.Sort(nums);
        
        foreach (var variable in nums)
            Console.Write($"{variable} ");
    }
}