// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Net;
using Newtonsoft.Json;

namespace WeatherConsoleApplication
{
    public class DownloadData
    {
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

            received?.Invoke(weatherData);
        }

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

            for (var i = 0; i < forecastData.List.Length; i += 8)
            {
                forecastData.List[i].Name = cityName;
                received?.Invoke(forecastData.List[i]);
            }
        }

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
    }
}