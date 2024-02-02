using FPSBank.Client.Authentication;
using FPSBank.Shared.Models.User;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FPSBank.Client.Services.User
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider authStateProvider;
        private readonly NavigationManager navManager;

        public UserService(HttpClient httpClient, NavigationManager navManager, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            this.navManager = navManager;
            this.authStateProvider = authStateProvider;
        }

        public async Task<bool> Login(LoginRequest loginRequest)
        {
            var loginResponse = await _httpClient.PostAsJsonAsync("api/User/Login",loginRequest);

            if (loginResponse.IsSuccessStatusCode)
            {
                var userSession = await loginResponse.Content.ReadFromJsonAsync<UserSession>();
                var customAuthStateProvider = (CustomAuthenticationStateProvider)authStateProvider;
                await customAuthStateProvider.UpdateAuthenticationState(userSession);
                navManager.NavigateTo($"home/{loginRequest.UserName}");
                return true;
            }
            else if (loginResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                
                return false;
            }
            return false;
        }

        public async Task Register(RegisterRequest registerRequest)
        {
            var userAccount = await _httpClient.PostAsJsonAsync("api/User/Register", registerRequest);
            if(userAccount.IsSuccessStatusCode)
            {
                navManager.NavigateTo("/");
            }
        }
    }
}
