using Blazored.LocalStorage;
using Common.Models.Common;
using Common.Models.Requests;
using Common.Models.Responses;
using Common.Providers;
using Microsoft.AspNetCore.Components.Authorization;

namespace Common.Services
{
    public interface IAuthService
    {
        Task<TokenInfo> Login(LoginRequest loginRequest);
        Task Register(RegisterRequest registerRequest);
        Task Logout();
        Task<ProfileResponse> CurrentUserInfo();
    }

    public class AuthService : IAuthService
    {
        private readonly BmsApiClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(BmsApiClient httpClient, AuthenticationStateProvider authStateProvider,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
        }

        public async Task<ProfileResponse> CurrentUserInfo()
        {
            var resp = await _httpClient.GetAsync<BaseResponse<ProfileResponse>>("api/v1/Accounts/Profile");

            return resp.Data;
        }

        public async Task<TokenInfo> Login(LoginRequest loginRequest)
        {
            var resp = await _httpClient.PostAsync<LoginRequest, BaseResponse<TokenInfo>>("api/v1/OAuth/login", loginRequest);

            await _localStorage.SetItemAsync("access_token", resp.Data.AccessToken);

            ((CustomAuthStateProvider)_authStateProvider).NotifyUserAuthentication(loginRequest.Email);

            _httpClient.SetAuthorizationHeader(resp.Data.AccessToken);

            return resp.Data;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("access_token");
            ((CustomAuthStateProvider)_authStateProvider).NotifyUserLogout();
            _httpClient.SetAuthorizationHeader(null);
        }

        public Task Register(RegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }
    }
}
