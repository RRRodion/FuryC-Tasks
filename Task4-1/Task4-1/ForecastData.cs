// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace Task4_1
{
    /// <summary>
    /// Прогноз на 5 дней
    /// </summary>
    [Serializable]
    public class ForecastData
    {
        /// <summary>
        /// Массив прогнозов на каждый день
        /// </summary>
        public WeatherData[] List { get; set; }
    }
}