using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Model.Core;

namespace Model.Data
{
    public abstract class BaseSerializer<T>
    {
        public abstract void Serialize(T data, string filePath);
        public abstract T Deserialize(string filePath);
    }

    public class JsonDataSerializer : BaseSerializer<List<Shelter>>
    {
        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented
        };

        public override void Serialize(List<Shelter> data, string filePath)
        {
            string json = JsonConvert.SerializeObject(data, _settings);
            File.WriteAllText(filePath, json);
        }

        public override List<Shelter> Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) return new List<Shelter>();
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Shelter>>(json, _settings) ?? new List<Shelter>();
        }
    }

    public class XmlDataSerializer : BaseSerializer<List<Shelter>>
    {
        public override void Serialize(List<Shelter> data, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Shelter>));
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, data);
            }
        }

        public override List<Shelter> Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) return new List<Shelter>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Shelter>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (List<Shelter>)serializer.Deserialize(fs);
            }
        }
    }
}