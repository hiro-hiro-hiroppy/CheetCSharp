using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CsSummary
{
    public class JsonConvertCh
    {
        /// <summary>
        /// Jsonをシリアル化(変換)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public string JsonSerialize<T>(List<T> data)
        {
            string serializeObject = "";

            serializeObject = JsonConvert.SerializeObject(data);

            return serializeObject;
        }

        /// <summary>
        /// Jsonに逆シリアル化(逆変換)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public List<T> JsonDeserialize<T>(string serializeObject)
        {
            List<T> deserializeObject = new List<T>();

            if (!string.IsNullOrEmpty(serializeObject))
            {
                deserializeObject = JsonConvert.DeserializeObject<List<T>>(serializeObject);
            }

            return deserializeObject;
        }

    }
}