using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AsyncDemos.Demo7.Services
{
    public class AmiibosService
    {
        private readonly HttpClient _httpClient;
        public AmiibosService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Models.Amiibo>> GetAllData()
        {
            var url = "https://www.amiiboapi.com/api/amiibo/";
            var response = await _httpClient.GetStringAsync(url);
            //var content = response.Content.ReadAsStringAsync().Result;
            var list = JsonConvert.DeserializeObject<Models.AmiiboModel>(response);
            return list.amiibo;
        }
    }
}
