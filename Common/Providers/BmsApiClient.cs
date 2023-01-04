using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Common.Providers
{
    public class BmsApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public BmsApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public void SetAuthorizationHeader(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        }

        public async Task<T> GetAsync<T>(string url)
            => await _httpClient.GetFromJsonAsync<T>(url);

        public async Task<TResp> PostAsync<TReq, TResp>(string url, TReq data)
        {
            var resp = await _httpClient.PostAsJsonAsync(url, data);

            var respJson = await resp.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResp>(respJson, _options);
        }
    }
}
