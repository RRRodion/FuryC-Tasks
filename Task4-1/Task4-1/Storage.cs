// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Runtime.Serialization.Formatters.Binary;

namespace Task4_1
{
    /// <summary>
    /// Хранилище данных.
    /// </summary>
    public static class Storage
    {
        /// <summary>
        /// Сохранение объекта в файл.
        /// </summary>
        /// <param name="data">Словарь</param>
        /// <param name="filePath">Путь</param>
        /// <typeparam name="TKey">Ключ</typeparam>
        /// <typeparam name="TValue">Значение</typeparam>
        public static async void Save<TKey, TValue>(Dictionary<TKey, TValue> data, string filePath)
        {
            await using var fstream = new FileStream(filePath, FileMode.Create);
            var buffer = data.GetBytes();
            await fstream.WriteAsync(buffer);
            Console.WriteLine("Текст записан в файл");
        }

        /// <summary>
        /// Загрузка объекта из файла
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <typeparam name="TKey">Ключ</typeparam>
        /// <typeparam name="TValue">Значение</typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> Load<TKey, TValue>(string filePath)
        {
            var dataBytes = File.ReadAllBytes(filePath);
            Dictionary<TKey, TValue> result;
            using (var memoryStream = new MemoryStream(dataBytes))
            {
                var formatter = new BinaryFormatter();
                result = (Dictionary<TKey, TValue>)formatter.Deserialize(memoryStream);
            }
            
            return result;
        }
    }
}