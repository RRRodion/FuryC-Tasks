// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace ConsoleApp2_1
{
    public class Student : Human
    {
        private string _faculty;
        private int _course;
        private string _group;

        public Student()
        {
            Console.WriteLine("Вызван конструктор без параметров класса Student");
        }

        public Student(string surname, string name, string batronymic, DateOnly birthday, string faculty, int course,
            string group) : base(surname, name, batronymic, birthday)
        {
            Console.WriteLine("Вызван конструктор с параметрами класса Student");
            _faculty = faculty;
            _course = course;
            _group = group;
        }

        public Student(Student student) : base(student)
        {
            Console.WriteLine("Вызван конструктор копироания класса Student");
            _faculty = student._faculty;
            _course = student._course;
            _group = student._group;
        }
        
        public void EditFaculty()
        {
            while (true)
            {
                Console.Write("факультет-");
                var value = Console.ReadLine();

                if (!int.TryParse(value, out _) && !string.IsNullOrWhiteSpace(value))
                {
                    _faculty = value;
                    return;
                }

                Console.WriteLine("ожидалась строка");
            }
        }
        
        public void EditCourse()
        {
            while (true)
            {
                Console.Write("курс-");
                var value = Console.ReadLine();

                if (int.TryParse(value, out var course) && course >= 0 && course<=6)
                {
                    _course = course;
                    return;
                }

                Console.WriteLine("ожидалось число");
            }
        }
        
        public void EditGroup()
        {
            while (true)
            {
                Console.Write("группа-");
                var value = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(value))
                {
                    _group = value;
                    return;
                }

                Console.WriteLine("ожидалась строка");
            }
        }

        public string ToString()
        {
            return base.ToString() + "faculty - " + _faculty + "\ncourse - " + _course + "\ngroup" + _group;
        }

        public void RequestInfo()
        {
            base.RequestInfo();
           EditFaculty();
           EditCourse();
           EditGroup();
        }

        ~Student()
        {
            Console.WriteLine("Вызван деструктор класса Student");
        }
    }
}