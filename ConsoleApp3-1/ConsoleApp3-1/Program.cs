// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace WeatherConsoleApplication
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                PrintMenu();
                var choice = DoChoice(1, 3);
                var city = "";

                switch (choice)
                {
                    case 1:
                        CitiesMenu();
                        city = ChoiceCity();
                        DownloadData.DownloadWeather(city, Show);
                        break;
                    case 2:
                        CitiesMenu();
                        city = ChoiceCity();
                        DownloadData.DownloadForecast(city, Show);
                        break;
                    case 3:
                        return;
                }

                Console.ReadKey();
            }
        }

        private static string ChoiceCity()
        {
            var choiceCity = DoChoice(1, 6);
            
            if (choiceCity == 6)
            {
                Console.Clear();
                Console.WriteLine("enter the name of the city:");
                return Console.ReadLine();
            }

            var s = (CityNames)choiceCity;
            var city = s.ToString();
            return city;
        }

        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\t+-------------------------+\n" +
                              "\t\t| 1) Weather for 1 day    |\n" +
                              "\t\t| 2) Weather for 5 days   |\n" +
                              "\t\t| 3) end the program      |\n" +
                              "\t\t+-------------------------+");
        }

        private static void CitiesMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\t+------------------------------------+\n" +
                              "\t\t| 1) Minsk                           |\n" +
                              "\t\t| 2) Moscow                          |\n" +
                              "\t\t| 3) Paris                           |\n" +
                              "\t\t| 4) Oslo                            |\n" +
                              "\t\t| 5) Bern                            |\n" +
                              "\t\t| 6) other variant                   |\n" +
                              "\t\t+------------------------------------+");
        }

        private static void Show(WeatherData weatherData)
        {
            Console.WriteLine("\t\t+------------------------------------+");
            Console.WriteLine($"\t\t| {weatherData.Name}                              |");
            Console.WriteLine($"\t\t| Temperature is : {weatherData.Main.Temp} °C           |");
            Console.WriteLine($"\t\t| Feels like : {weatherData.Main.Feels_like} °C               |");
            Console.WriteLine($"\t\t| Min temperature is: {weatherData.Main.Temp_min} °C        |");
            Console.WriteLine($"\t\t| Max temperature is: {weatherData.Main.Temp_max} °C        |");
            Console.WriteLine($"\t\t| Pressure is : {weatherData.Main.Pressure}                 |");
            Console.WriteLine($"\t\t| Humidity is : {weatherData.Main.Humidity}                   |");
            Console.WriteLine("\t\t+------------------------------------+");
        }

        private static int DoChoice(int from, int to)
        {
            while (true)
            {
                Console.Write("\t\tSelect an action: ");

                if (int.TryParse(Console.ReadLine(), out var choice) && choice >= from && choice <= to)
                {
                    Console.Clear();
                    return choice;
                }

                Console.WriteLine($"\t\tYou must enter a number from {from} to {to}");
            }
        }
    }
}