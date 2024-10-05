using _3_InterfaceAdapters_Adapters;
using _3_InterfaceAdapters_Adapters.Dtos;
using System.Text.Json;

namespace _4_FrameworksDrivers_ExternalService
{
    public class PostService : IExternalService<PostServiceDto>
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        public PostService(HttpClient httpclient)
        {
            _httpClient = httpclient;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
        }
        public async Task<IEnumerable<PostServiceDto>> GetServicesAsync()
        {
            var response = await _httpClient.GetAsync(_httpClient.BaseAddress);
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<PostServiceDto>>(responseData, _options);
        }
    }
}
