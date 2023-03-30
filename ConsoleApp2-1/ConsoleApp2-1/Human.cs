// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace ConsoleApp2_1
{
    public abstract class Human
    {
        private static int _nextId;
        public int Id { get; }
        private string _surname;
        private string _name;
        private string _patronymic;
        private DateOnly _birthday;

        public Human()
        {
            Id = Interlocked.Increment(ref _nextId);
            Console.WriteLine("Вызван конструктор без параметров класса Human");
        }

        public Human(string surname, string name, string patronymic, DateOnly birthday)
        {
            Id = Interlocked.Increment(ref _nextId);
            Console.WriteLine("Вызван конструктор с параметрами класса Human");
            _surname = surname;
            _name = name;
            _patronymic = patronymic;
            _birthday = birthday;
        }

        public Human(Human human)
        {
            Id = Interlocked.Increment(ref _nextId);
            Console.WriteLine("Вызван конструктор копироания класса Human");
            _surname = human._surname;
            _name = human._name;
            _patronymic = human._patronymic;
            _birthday = human._birthday;
        }

        public void EditSurname()
        {
            while (true)
            {
                Console.Write("фамилия-");
                var value = Console.ReadLine();

                if (!int.TryParse(value, out _) && !string.IsNullOrWhiteSpace(value))
                {
                    _surname = value;
                    return;
                }

                Console.WriteLine("ожидалась строка");
            }
        }

        public void EditName()
        {
            while (true)
            {
                Console.Write("имя-");
                var value = Console.ReadLine();

                if (!int.TryParse(value, out _) && !string.IsNullOrWhiteSpace(value))
                {
                    _name = value;
                    return;
                }

                Console.WriteLine("ожидалась строка");
            }
        }

        public void EditPatronymic()
        {
            while (true)
            {
                Console.Write("отчество-");
                var value = Console.ReadLine();

                if (!int.TryParse(value, out _) && !string.IsNullOrWhiteSpace(value))
                {
                    _patronymic = value;
                    return;
                }

                Console.WriteLine("ожидалась строка");
            }
        }
        
        public void EditBirthday()
        {
            while (true)
            {
                Console.Write("дата рождения-");
                var value = Console.ReadLine();

                if (DateOnly.TryParse(value, out var birthday))
                {
                    _birthday = birthday;
                    return;
                }

                Console.WriteLine("ожидалась дата гггг.мм.дд");
            }
        }
        
        public int FullYears()
        {
            return DateTime.Now.Year - _birthday.Year;
        }

        public string ToString()
        {
            return "\nid - " + Id + "\nsurname - " + _surname + "\nname - " + _name + "\npatronymic - " + _patronymic +
                   "\nbirthday - " + _birthday;
        }

        public void RequestInfo()
        {
            EditSurname();
            EditName();
            EditPatronymic();
            EditBirthday();
        }

        ~Human()
        {
            Console.WriteLine("Вызван деструктор класса Human");
        }
    }
}