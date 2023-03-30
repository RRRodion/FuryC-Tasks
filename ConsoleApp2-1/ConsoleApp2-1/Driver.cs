// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace ConsoleApp2_1
{
    public sealed class Driver : Employee
    {
        private string _carBrand;
        private string _carModel;

        public Driver()
        {
            Console.WriteLine("вызван конструктор без параметров класса Driver");
        }

        public Driver(string surname, string name, string patronymic, DateOnly birthday, string organization,
            decimal salary, int experience, string carBrand, string carModel) : base(surname, name, patronymic, 
            birthday, organization, salary, experience)
        {
            Console.WriteLine("вызван конструктор c параметрами класса Driver");
            _carBrand = carBrand;
            _carModel = carModel;
        }

        public Driver(Driver driver) : base(driver)
        {
            Console.WriteLine("вызван конструктор копирования класса Driver");
            _carBrand = driver._carBrand;
            _carModel = driver._carModel;
        }
        
        public void EditCarBrand()
        {
            while (true)
            {
                Console.Write("марка машины-");
                var value = Console.ReadLine();

                if (!int.TryParse(value, out _) && !string.IsNullOrWhiteSpace(value))
                {
                    _carBrand = value;
                    return;
                }

                Console.WriteLine("ожидалась строка");
            }
        }
        
        public void EditCarModel()
        {
            while (true)
            {
                Console.Write("модель машины-");
                var value = Console.ReadLine();

                if (!int.TryParse(value, out _) && !string.IsNullOrWhiteSpace(value))
                {
                    _carModel = value;
                    return;
                }

                Console.WriteLine("ожидалась строка");
            }
        }

        public string ToString()
        {
            return base.ToString() + "\nCarBrand - " + _carBrand + "\nCarModel - " + _carModel;
        }

        public void RequestInfo()
        {
            base.RequestInfo();
            EditCarBrand();
            EditCarModel();
        }
        
        ~Driver()
        {
            Console.WriteLine("вызван деструктор класса Driver");
        }
    }
}