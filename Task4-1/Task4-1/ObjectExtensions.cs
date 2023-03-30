// Copyright (c) 2012-2022 FuryLion Group. All Rights Reserved.

using System.Runtime.Serialization.Formatters.Binary;

namespace Task4_1
{
    /// <summary>
    /// Расширения для object.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Получение байтового представления объекта.
        /// </summary>
        /// <returns>Байтовое представление объекта</returns>
        public static byte[] GetBytes(this Object obj)
        {
            var bf = new BinaryFormatter();
            using var ms = new MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }
    }
}