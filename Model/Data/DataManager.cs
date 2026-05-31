using System.Collections.Generic;
using System.IO;
using Model.Core;

namespace Model.Data
{
    public static class DataManager
    {
        public static string CurrentFormat = "JSON";
        private const string JsonPath = "shelters_data.json";
        private const string XmlPath = "shelters_data.xml";

        private static readonly JsonDataSerializer _jsonSerializer = new JsonDataSerializer();
        private static readonly XmlDataSerializer _xmlSerializer = new XmlDataSerializer();

        public static List<Shelter> LoadData()
        {
            string path = CurrentFormat == "JSON" ? JsonPath : XmlPath;
            var serializer = CurrentFormat == "JSON" ? (BaseSerializer<List<Shelter>>)_jsonSerializer : _xmlSerializer;

            if (File.Exists(path))
            {
                return serializer.Deserialize(path);
            }

            var seed = GenerateInitialData();
            SaveData(seed);
            return seed;
        }

        public static void SaveData(List<Shelter> shelters)
        {
            string path = CurrentFormat == "JSON" ? JsonPath : XmlPath;
            var serializer = CurrentFormat == "JSON" ? (BaseSerializer<List<Shelter>>)_jsonSerializer : _xmlSerializer;
            serializer.Serialize(shelters, path);
        }

        public static void ChangeFormat(string newFormat)
        {
            if (CurrentFormat == newFormat) return;

            var data = LoadData();
            CurrentFormat = newFormat;
            SaveData(data);
        }

        private static List<Shelter> GenerateInitialData()
        {
            var shelters = new List<Shelter>
            {
                new Shelter("Усатый-полосатый", 15, false),
                new Shelter("Верный друг", 20, true),
                new Shelter("Пушистый дом", 10, true)
         };

            shelters[0] += new Cat("Мурзик", 3, 4.5, "Male", "Дворняга", true, false);
            shelters[0] += new Cat("Алиса", 2, 3.0, "Female", "Сиамская", false, false);
            shelters[0] += new Rabbit("Снежок", 1, 1.2, "Male", 0, "Белый", false);
            shelters[0] += new Dog("Шарик", 4, 10.0, "Male", "Дворняга", true, false);

            shelters[1] += new Dog("Рэкс", 5, 12.5, "Male", "Овчарка", false, true);
            shelters[1] += new Dog("Бобик", 7, 15.0, "Male", "Лабрадор", true, true);
            shelters[1] += new Cat("Барсик", 2, 5.0, "Male", "Мейн-кун", false, false);
            shelters[1] += new Rabbit("Крош", 2, 1.5, "Male", 2, "Серый", false);

            shelters[2] += new Cat("Симба", 1, 2.5, "Male", "Британская", false, false);
            shelters[2] += new Rabbit("Пушинка", 1, 1.0, "Female", 0, "Белый", true);
            shelters[2] += new Dog("Лайка", 3, 10.0, "Female", "Хаски", false, true);
            shelters[2] += new Cat("Багира", 5, 4.0, "Female", "Сфинкс", true, false);

            return shelters;
        }
    }
}