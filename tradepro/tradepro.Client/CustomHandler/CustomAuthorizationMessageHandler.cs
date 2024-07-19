using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
namespace tradepro.Client.CustomHandler
{
    public class CustomAuthorizationMessageHandler : DelegatingHandler
    {
        private readonly IAccessTokenProvider _tokenProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navigationManager;

        public CustomAuthorizationMessageHandler(IAccessTokenProvider tokenProvider, ILocalStorageService localStorageService, NavigationManager navigationManager)
        {
            _tokenProvider = tokenProvider;
            _localStorage = localStorageService;
            _navigationManager = navigationManager;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var accessTokenResult = await _localStorage.GetItemAsStringAsync("token");
            if (accessTokenResult == null)
            {
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessTokenResult);
            }
            else
            {
                // Handle token not available case, e.g., redirect to login
                _navigationManager.NavigateTo("/login");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
