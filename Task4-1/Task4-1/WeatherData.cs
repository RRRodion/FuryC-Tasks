// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace Task4_1
{
    /// <summary>
    /// Прогноз погоды на 1 день
    /// </summary>
    [Serializable]
    public class WeatherData
    {
        /// <summary>
        /// Инфо от температуре
        /// </summary>
        public TemperatureInfo Main { get; set; }
        
        /// <summary>
        /// Название города
        /// </summary>
        public string Name { get; set; }
    }
}