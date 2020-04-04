using Luis.Manage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LuisManager
{
    public static class LuisService
    {
        public static async Task<LuisResult> GetIntent(string query)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(LuisConfiguration.EndpointUrl + query).ConfigureAwait(false);
            var responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var obj = JsonConvert.DeserializeObject<LuisResult>(responseString);
            return obj;
        }

    }
}
