// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Runtime.Serialization;

namespace Task4_1
{
    /// <summary>
    /// Главный класс программы
    /// </summary>
    class Program
    {
        /// <summary>
        /// Главный метод программы
        /// </summary>
        public static void Main()
        {
            DataDownloader.Init();
            
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
                        DataDownloader.DownloadWeather(city, Show);
                        break;
                    case 2:
                        CitiesMenu();
                        city = ChoiceCity();
                        DataDownloader.DownloadForecast(city, Show);
                        break;
                    case 3:
                        DataDownloader.PrintAllWeatherData();
                        break;
                    case 4:
                        DataDownloader.PrintAllForecastData();
                        break;
                    case 5:
                        return;
                }

                Console.ReadKey();
            }
        }

        /// <summary>
        /// Метод для выбора города
        /// </summary>
        /// <returns>Выбранный город</returns>
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

        /// <summary>
        /// Вывод меню на экран
        /// </summary>
        private static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\t+--------------------------------------+\n" +
                              "\t\t| 1) Weather forecast for 1 day        |\n" +
                              "\t\t| 2) Weather forecast for 5 days       |\n" +
                              "\t\t| 3) Latest weather forecast for 1 day |\n" +
                              "\t\t| 4) Latest weather forecast for 5 day |\n" +
                              "\t\t| 5) end the program                   |\n" +
                              "\t\t+--------------------------------------+");
        }

        /// <summary>
        /// Вывод списка городов на экран
        /// </summary>
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

        /// <summary>
        /// Вывод прогноза погоды на 1 день
        /// </summary>
        /// <param name="weatherData">Прогноз погоды</param>
        public static void Show(WeatherData weatherData)
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

        /// <summary>
        /// Выбор значений в указанном диапазоне
        /// </summary>
        /// <param name="from">от</param>
        /// <param name="to">до</param>
        /// <returns>Корректное значение</returns>
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