using Newtonsoft.Json;

namespace Port.Data.Utility
{
    public static class JsonUtil
    {
        public static T DeserializeObject<T>(string stream)
        {
            return JsonConvert.DeserializeObject<T>(stream);
        }

        public static string SerializeObject<T>(T objectToStringify)
        {
            return JsonConvert.SerializeObject(objectToStringify);
        }
    }
}