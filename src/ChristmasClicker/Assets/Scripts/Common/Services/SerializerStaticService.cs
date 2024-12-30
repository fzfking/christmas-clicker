using Newtonsoft.Json;

namespace Common.Services
{
    public class SerializerStaticService
    {
        private static readonly JsonSerializerSettings JsonSettings = new()
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };
        
        public static string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value, JsonSettings);
        }

        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, JsonSettings);
        }
    }
}