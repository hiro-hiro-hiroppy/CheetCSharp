using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheetNetCoreMVC.CS
{
    public class JsonCh
    {
        /// <summary>
        /// Jsonをシリアル化(変換)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public string JsonSerialize<T>(List<T> data)
        {
            string jsonString = "";

            jsonString = JsonSerializer.Serialize(data);

            return jsonString;
        }

        /// <summary>
        /// Jsonに逆シリアル化(逆変換)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public List<T> JsonDeserialize<T>(string jsonString)
        {
            List<T> deserializeData = new List<T>();

            deserializeData = JsonSerializer.Deserialize<List<T>>(jsonString);

            return deserializeData;
        }

    }
}