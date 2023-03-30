// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Net;
using Newtonsoft.Json;

namespace Task4_1
{
    /// <summary>
    /// Класс загрузки данных
    /// </summary>
    public static class DataDownloader
    {
        private static string WeatherDataFilePath = @"D:\fury course\fork\r.babichev\Task4-1\Task4-1\WeatherData.txt";
        private static string ForecastDataFilePath = @"D:\fury course\fork\r.babichev\Task4-1\Task4-1\ForecastData.txt";

        /// <summary>
        /// Словарь с погодой на 1 день
        /// </summary>
        private static ObservableDictionary<string, WeatherData> _weatherDataDictionary = new();

        /// <summary>
        /// Словарь с погодой на 5 дней
        /// </summary>
        private static ObservableDictionary<string, ForecastData> _forecastDataDictionary = new();

        /// <summary>
        /// Инициализация словарей
        /// </summary>
        public static void Init()
        {
            _weatherDataDictionary.DataChanged += Storage.Save;
            _forecastDataDictionary.DataChanged += Storage.Save;
            _weatherDataDictionary.Init(WeatherDataFilePath);
            _forecastDataDictionary.Init(ForecastDataFilePath);
        }

        /// <summary>
        /// Загрузка погоды на 1 день
        /// </summary>
        /// <param name="cityName">Название города</param>
        /// <param name="received">Вызываемое событие</param>
        public static async void DownloadWeather(string cityName, Action<WeatherData> received)
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=metric" +
                      "&appid=f2904a40521026c51042c11d6d1ad02f";
            var response = await DoResponse(url);

            if (string.IsNullOrEmpty(response))
                return;

            var weatherData = new WeatherData();

            try
            {
                weatherData = JsonConvert.DeserializeObject<WeatherData>(response);
            }
            catch (WebException _)
            {
                Console.WriteLine("There is no such city");
                return;
            }

            if (_weatherDataDictionary.ContainsKey(weatherData.Name))
                _weatherDataDictionary[weatherData.Name] = weatherData;
            else
                _weatherDataDictionary.Add(weatherData.Name, weatherData);

            received?.Invoke(weatherData);
        }

        /// <summary>
        /// Загрузка погоы на 5 дней
        /// </summary>
        /// <param name="cityName">Название города</param>
        /// <param name="received">Вызываемое событие</param>
        public static async void DownloadForecast(string cityName, Action<WeatherData> received)
        {
            var url = $"http://api.openweathermap.org/data/2.5/forecast?q={cityName}&units=metric" +
                      "&appid=f2904a40521026c51042c11d6d1ad02f";
            var response = await DoResponse(url);

            if (string.IsNullOrEmpty(response))
                return;

            var forecastData = new ForecastData();

            try
            {
                forecastData = JsonConvert.DeserializeObject<ForecastData>(response);
            }
            catch (WebException _)
            {
                Console.WriteLine("There is no such city");
                return;
            }

            _forecastDataDictionary.Add(cityName, forecastData);

            for (var i = 0; i < forecastData.List.Length; i += 8)
            {
                forecastData.List[i].Name = cityName;
                received?.Invoke(forecastData.List[i]);
            }
        }

        /// <summary>
        /// Метод запроса данных
        /// </summary>
        /// <param name="url">Ссылка на запрос</param>
        /// <returns>Возвращает Json в строке</returns>
        private static async Task<string> DoResponse(string url)
        {
            using var client = new HttpClient();
            var result = await client.GetAsync(url);

            if (result.StatusCode != HttpStatusCode.OK)
            {
                Console.WriteLine("Something wrong");
                return string.Empty;
            }

            using var streamReader = new StreamReader(await client.GetStreamAsync(url));
            return await streamReader.ReadToEndAsync();
        }

        /// <summary>
        /// вывод всех прогнозов на 1 день из кеша
        /// </summary>
        public static void PrintAllWeatherData()
        {
            foreach (var weather in _weatherDataDictionary)
                Program.Show(weather.Value);
        }

        /// <summary>
        /// вывод всех прогнозов на 5 дней из кеша
        /// </summary>
        public static void PrintAllForecastData()
        {
            foreach (var weather in _forecastDataDictionary)
                foreach (var weatherData in weather.Value.List)
                    Program.Show(weatherData);
        }
    }
}