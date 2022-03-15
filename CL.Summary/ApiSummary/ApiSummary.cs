using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Summary.ApiSummary
{
    public class ApiSummary
    {
        /// <summary>
        /// GET WebAPIを呼び出す
        /// </summary>
        /// <returns></returns>
        public dynamic CallGetWebAPI(string url)
        {
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                using (System.Net.Http.HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    //生のレスポンス全体を文字列で取得
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    dynamic oResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);

                    //bool success = oResponse.success;
                    //string dataName = oResponse.data.name;
                    //string dataNote = oResponse.data.note;
                    //int dataAge = oResponse.data.age;
                    //DateTime dataRegisterDate = oResponse.data.registerDate;

                    return oResponse;

                }

            }

        }

        /// <summary>
        /// POST WebAPIを呼び出す
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        public void CallPostWebAPI(string url, string data)
        {
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                var requestContent = new System.Net.Http.StringContent(data, System.Text.Encoding.UTF8, "application/json");

                using (System.Net.Http.HttpResponseMessage response = client.PostAsync(url, requestContent).Result)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        /// <summary>
        /// PUT WebAPIを呼び出す
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        public void CallPutWebAPI(string url, string data)
        {
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                var requestContent = new System.Net.Http.StringContent(data, System.Text.Encoding.UTF8, "application/json");

                using (System.Net.Http.HttpResponseMessage response = client.PutAsync(url, requestContent).Result)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        /// <summary>
        /// DELETE WebAPIを呼び出す
        /// </summary>
        /// <param name="url"></param>
        public void CallDeleteWebAPI(string url)
        {
            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                using (System.Net.Http.HttpResponseMessage response = client.DeleteAsync(url).Result)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}
