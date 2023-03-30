// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

namespace Task4_1
{
    /// <summary>
    /// Информация о температуре воздуха
    /// </summary>
    [Serializable]
    public class TemperatureInfo
    {
        /// <summary>
        /// Температура воздуха
        /// </summary>
        public float Temp { get; set; }
        
        /// <summary>
        /// Ощущается как
        /// </summary>
        public float Feels_like { get; set; }
       
        /// <summary>
        /// Минимальная температура
        /// </summary>
        public float Temp_min { get; set; }
        
        /// <summary>
        /// Максимальная температура
        /// </summary>
        public float Temp_max { get; set; }
        
        /// <summary>
        /// Давление
        /// </summary>
        public int Pressure { get; set; }
        
        /// <summary>
        /// Влажность
        /// </summary>
        public int Humidity { get; set; }
    }
}