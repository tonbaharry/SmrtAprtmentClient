using Newtonsoft.Json;
using SmrtAprtmentClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmrtAprtmentClient.APIClient
{
    public static class Request
    {
        static HttpClient client = new HttpClient();
        static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        public static async Task<List<Management>> GetManagementAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                List<Management> value = JsonConvert.DeserializeObject<List<Management>>(result, settings);
                return value;
            }
            return new List<Management>();
        }

        public static async Task<List<Properties>> GetPropertiesAsync(string path)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                List<Properties> value = JsonConvert.DeserializeObject<List<Properties>>(result, settings);
                return value;
            }
            return new List<Properties>();
        }

        public static List<RequestType> PopulateRequestTypes()
        {

            List<RequestType> types = new List<RequestType>();
            types.Add(new RequestType { RequestId = 1, RequestName = "Management" });
            types.Add(new RequestType { RequestId = 2, RequestName = "Properties" });

            return types;
        }
    }
}
