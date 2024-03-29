﻿using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace Anpero.Ultil
{
    class HttpHelper<T>
    {
        private static readonly HttpClient client = new HttpClient();

        public static T? Post(string url, object paramObject)
        {

            string json = "";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var content = new FormUrlEncodedContent(ObjectToDictionary(paramObject));
            var response = client.PostAsync(url, content).Result;
            json = response.Content.ReadAsStringAsync().Result;
            if (json != "")
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }
                catch (Exception)
                {

                    return default(T);
                }

            }
            else
            {
                return default(T);
            }
        }
        public static T? PostJson(string url, object paramObject)
        {

            string json = "";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var dataJson = JsonConvert.SerializeObject(paramObject);
            var content = new StringContent(dataJson, Encoding.UTF8, "application/json");
            var response = client.PostAsync(url, content).Result;
            json = response.Content.ReadAsStringAsync().Result;
            if (json != "")
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(json);
                }
                catch (Exception ex)
                {

                    return default(T);
                }

            }
            else
            {
                return default(T);
            }
        }
        public static string PostGetString(string url, object paramObject)
        {

            try
            {
                var dataJson = JsonConvert.SerializeObject(paramObject);
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var content = new StringContent(dataJson, Encoding.UTF8, "application/json");
                var response = client.PostAsync(url, content).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                throw;
            }


        }
        public static string PostAndReturnJson(string url, object paramObject)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new FormUrlEncodedContent(ObjectToDictionary(paramObject));
            var response = client.PostAsync(url, content).Result;
            return response.Content.ReadAsStringAsync().Result;

        }
        public static T? Get(string url, object paramObject)
        {
            string json = "";
            var content = ObjectToDictionary(paramObject);
            var condition = "?";
            foreach (KeyValuePair<string, string> entry in content)
            {
                url += condition + entry.Key + "=" + entry.Value;
                condition = "&";
            }
            var response = client.GetAsync(url).Result;

            json = response.Content.ReadAsStringAsync().Result;
            try
            {
                if (json != "")
                {

                    return JsonConvert.DeserializeObject<T>(json);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {

                return default(T);
            }

        }
        public static string GetAndReturnJson(string url, object paramObject)
        {
            var content = ObjectToDictionary(paramObject);
            var condition = "?";
            foreach (KeyValuePair<string, string> entry in content)
            {
                url += condition + entry.Key + "=" + entry.Value;
                condition = "&";
            }
            var response = client.GetAsync(url).Result;
            return response.Content.ReadAsStringAsync().Result;

        }
        public static Dictionary<string, string> ObjectToDictionary(object obj)
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            if (obj != null)
            {
                foreach (PropertyInfo prop in obj.GetType().GetProperties().OrderBy(x => x.Name))
                {
                    string propName = prop.Name;
                    var val = obj.GetType().GetProperty(propName).GetValue(obj, null);
                    if (val != null)
                    {
                        ret.Add(propName, val.ToString());
                    }
                    else
                    {
                        ret.Add(propName, "");
                    }
                }
            }
            return ret;
        }
    }
}
