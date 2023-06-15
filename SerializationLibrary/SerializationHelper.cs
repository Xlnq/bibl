using Newtonsoft.Json;
using System.IO;

namespace SerializationLibrary
{
    public class SerializationHelper
    {
        public static void Serialize<T>(T data, string filePath)
        {
            string serializedData = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, serializedData);
        }

        public static T Deserialize<T>(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            T deserializedData = JsonConvert.DeserializeObject<T>(jsonData);
            return deserializedData;
        }
    }
}