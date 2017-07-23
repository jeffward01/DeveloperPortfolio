using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Port.Net.Data.Utility
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
