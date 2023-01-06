using Blazored.LocalStorage;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Common.Providers
{
    public class BmsApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        private readonly ILocalStorageService _localStorageService;

        public BmsApiClient(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        private async Task SetAuthorizationHeader()
        {
            var token = await _localStorageService.GetItemAsync<string>("access_token");

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }
        }

        public async Task<T> GetAsync<T>(string url)
        {
            await SetAuthorizationHeader();

            return await _httpClient.GetFromJsonAsync<T>(url, _options);
        }

        public async Task<TResp> PostAsync<TReq, TResp>(string url, TReq data)
        {
            await SetAuthorizationHeader();

            var resp = await _httpClient.PostAsJsonAsync(url, data);

            var respJson = await resp.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<TResp>(respJson, _options);
        }
    }
}