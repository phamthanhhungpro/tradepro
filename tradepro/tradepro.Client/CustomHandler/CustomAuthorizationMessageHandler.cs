using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

public class AuthHandler : DelegatingHandler
{
    private readonly IServiceProvider _serviceProvider;

    public AuthHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Ensure JavaScript interop is available
        if (_serviceProvider.GetService<IJSRuntime>() is not null)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var localStorageService = scope.ServiceProvider.GetRequiredService<ILocalStorageService>();
                var token = await localStorageService.GetItemAsync<string>("token");

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Replace("\"", ""));
                }
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
