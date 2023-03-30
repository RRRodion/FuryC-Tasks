using System.Collections;

namespace Task4_1
{
    /// <summary>
    /// Класс вызывающий события при добавлении и удалении объектов из коллекции.
    /// </summary>
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Путь к файл для хранения данных
        /// </summary>
        private string _filePath;

        /// <summary>
        /// Путь к файлу для хранения данных
        /// </summary>
        private Dictionary<TKey, TValue> _dictionary = new Dictionary<TKey, TValue>();

        /// <summary>
        /// Количество данных в словаре
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Возможность только чтения
        /// </summary>
        public bool IsReadOnly { get; }

        /// <summary>
        /// Коллекция ключей словаря
        /// </summary>
        public ICollection<TKey> Keys { get; }

        /// <summary>
        /// Коллекция значений словаря
        /// </summary>
        public ICollection<TValue> Values { get; }

        /// <summary>
        /// Делегат охранения данных
        /// </summary>
        public delegate void DataSaver(Dictionary<TKey, TValue> data, string filePath);

        /// <summary>
        /// Событие сохранения данных
        /// </summary>
        public event DataSaver DataChanged;

        /// <summary>
        /// Метод для инициализации словаря
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        public void Init(string filePath)
        {
            if (File.ReadAllLines(filePath).Length != 0)
                Storage.Load<TKey, TValue>(filePath);

            _filePath = filePath;
        }

        /// <summary>
        /// Возвращает перечислитель, осуществляющий перебор элементов списка
        /// </summary>
        /// <returns>Перечислитель</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        /// <summary>
        /// Возвращает перечислитель, осуществляющий перебор элементов списка
        /// </summary>
        /// <returns>Перечислитель</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Добавляет указанные ключ и значение в словарь
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _dictionary.Add(item.Key, item.Value);
            DataChanged?.Invoke(_dictionary, _filePath);
        }

        /// <summary>
        /// Удаляет все ключи и значения из словаря
        /// </summary>
        public void Clear()
        {
            _dictionary.Clear();
        }

        /// <summary>
        /// Определяет, содержится ли указанный ключ в словаре
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _dictionary.Contains(item);
        }

        /// <summary>
        /// Копирует значения из массива
        /// </summary>
        /// <param name="array">Масив</param>
        /// <param name="arrayIndex">С какого индекса начинать копирование</param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Удаляет значение с указанным ключом из словаря
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            var remove = _dictionary.Remove(item.Key);
            DataChanged?.Invoke(_dictionary, _filePath);
            return remove;
        }

        /// <summary>
        /// добавление ключа и значения
        /// </summary>
        /// <param name="key">ключ</param>
        /// <param name="value">значение</param>
        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
            DataChanged?.Invoke(_dictionary, _filePath);
        }

        /// <summary>
        /// Определяет, содержится ли указанный ключ в словаре
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key)
        {
            return _dictionary.ContainsKey(key);
        }

        /// <summary>
        /// Удаляет значение с указанным ключом из словаря 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(TKey key)
        {
            var remove = _dictionary.Remove(key);
            DataChanged?.Invoke(_dictionary, _filePath);
            return remove;
        }

        /// <summary>
        /// Получает значение, связанное с заданным ключом
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// Получение значения по ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <exception cref="NotImplementedException"></exception>
        public TValue this[TKey key]
        {
            get => _dictionary[key];
            set => this[key] = value;
        }
    }
}