// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace ConsoleApp2_1
{
    public class Employee : Human
    {
        private string _organization;
        private decimal _salary;
        private int _experience;

        public Employee()
        {
            Console.WriteLine("Вызван конструктор без параметров");
        }

        public Employee(string surname, string name, string patronymic, DateOnly birthday, string organization,
            decimal salary, int experience) : base(surname, name, patronymic, birthday)
        {
            Console.WriteLine("Вызван конструктор с параметрами");
            _organization = organization;
            _salary = salary;
            _experience = experience;
        }

        public Employee(Employee employee) : base(employee)
        {
            Console.WriteLine("Вызван конструктор копироания");
            _organization = employee._organization;
            _salary = employee._salary;
            _experience = employee._experience;
        }

        public void EditOrganization()
        {
            while (true)
            {
                Console.Write("организация-");
                var value = Console.ReadLine();

                if (!int.TryParse(value, out _) && !string.IsNullOrWhiteSpace(value))
                {
                    _organization = value;
                    return;
                }

                Console.WriteLine("ожидалась строка");
            }
        }

        public void EditSalary()
        {
            while (true)
            {
                Console.Write("зарплата-");
                var value = Console.ReadLine();

                if (decimal.TryParse(value, out var salary) && salary >= 0)
                {
                    _salary = salary;
                    return;
                }

                Console.WriteLine("ожидалось число от 0");
            }
        }

        public void EditExperience()
        {
            while (true)
            {
                Console.Write("опыт-");
                var value = Console.ReadLine();

                if (int.TryParse(value, out var experience) && experience >= 0)
                {
                    _experience = experience;
                    return;
                }

                Console.WriteLine("ожидалось число");
            }
        }

        public string ToString()
        {
            return base.ToString() + "Organization - " + _organization + "\nsalary - " + _salary + "\nExperience" +
                   _experience;
        }

        public void RequestInfo()
        {
            base.RequestInfo();
            EditOrganization();
            EditSalary();
            EditExperience();
        }

        ~Employee()
        {
            Console.WriteLine("Вызван деструктор");
        }
    }
}