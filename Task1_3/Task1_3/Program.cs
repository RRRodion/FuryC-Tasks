// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public class Program
{
    public static void Main()
    {
        Console.Write("введи число ");
        
        if (int.TryParse(Console.ReadLine(), out var n))
            Console.WriteLine(Factorial(n));
        else
            Console.WriteLine("Введенная строка не являлась числом.");
    }
    
    private static int Factorial(int n)
    {
        if (n == 0)
            return 1;
        
        return Factorial(n - 1) * n;
    }
}