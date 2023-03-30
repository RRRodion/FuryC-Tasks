// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Введите текст");
        var s = Console.ReadLine();
        char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r' };
        var words = s.Split(chars, StringSplitOptions.RemoveEmptyEntries);
        var count = 0;

        foreach (var word in words)
            if (word.All(Char.IsLetter) && word[0] == 'K')
                count++;
                
        Console.WriteLine(count);
    }
}