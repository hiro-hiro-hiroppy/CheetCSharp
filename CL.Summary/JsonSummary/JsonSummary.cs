using CL.Summary.JsonSummary.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Summary.JsonSummary
{
    /// <summary>
    /// Jsonのシリアル化、逆シリアル化
    /// </summary>
    public class JsonSummary:IJsonSummary
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
