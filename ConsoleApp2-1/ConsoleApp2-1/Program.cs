// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace ConsoleApp2_1
{
    public static class Program
    {
        public static void Main()
        {
            var humans = new List<Human>();

            while (true)
            {
                PrintMenu();
                var choise = DoChoise(0, 5);

                switch (choise)
                {
                    case 1:
                        PrintHumanMenu();
                        var newHumanChoise = DoChoise(1, 3);
                        
                        switch (newHumanChoise)
                        {
                            case 1:
                                var student = new Student();
                                student.RequestInfo();
                                humans.Add(student);
                                break;
                            case 2:
                                var employee = new Employee();
                                employee.RequestInfo();
                                humans.Add(employee);
                                break;
                            case 3:
                                var driver = new Driver();
                                driver.RequestInfo();
                                humans.Add(driver);
                                break;
                        }

                        break;
                    case 2:
                        Console.WriteLine("\tВведите Id человека");
                        var idRequest = int.Parse(Console.ReadLine());

                        foreach (var human in humans)
                            if (idRequest == human.Id)
                                human.RequestInfo();
                            else
                                Console.WriteLine("Человек не найден");

                        break;
                    case 3:
                        Console.WriteLine("\tВведите Id человека");
                        var idRemove = int.Parse(Console.ReadLine());

                        foreach (var human in humans)
                        {
                            if (idRemove == human.Id)
                                humans.Remove(human);
                            else
                                Console.WriteLine("Человек не найден");
                        }

                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("\tВведите Id человека");
                        var idPrint = int.Parse(Console.ReadLine());

                        foreach (var human in humans)
                            if (idPrint == human.Id)
                                Console.WriteLine(human.ToString());
                            else
                                Console.WriteLine("Человек не найден");

                        Console.ReadKey();
                        break;
                    case 5:
                        foreach (var human in humans)
                            Console.WriteLine(human.ToString());

                        Console.ReadKey();
                        break;
                    case 0:
                        return;
                }
            }
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1-добавить нового человека\n" +
                              "2-редактировать информацию о человеке\n" +
                              "3-удалить информацию о человеке\n" +
                              "4-вывести информацию о человеке\n" +
                              "5-вывести инфу о всех людях\n" +
                              "0-завершить программу");
        }

        public static void PrintHumanMenu()
        {
            Console.Clear();
            Console.WriteLine("1-добавить студента\n" +
                              "2-добавить рабочего\n" +
                              "3-добавить водителя");
        }

        public static int DoChoise(int from, int to)
        {
            while (true)
            {
                Console.Write("\tВыберите действие: ");

                if (int.TryParse(Console.ReadLine(), out var choise) && choise >= from && choise <= to)
                {
                    Console.Clear();
                    return choise;
                }

                Console.WriteLine($"Необходимо ввести число от {from} до {to}");
            }
        }
    }
}