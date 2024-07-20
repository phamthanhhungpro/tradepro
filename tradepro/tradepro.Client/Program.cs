using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using RestEase.HttpClientFactory;
using System.Net.Http.Json;
using tradepro.Client.Common.Model;
using tradepro.Client.CustomHandler;
using tradepro.Client.RestClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped<CustomAuthorizationMessageHandler>();
builder.Services.AddHttpClient("ApiClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<CustomAuthorizationMessageHandler>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ApiClient"));
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
// Fetch configuration settings from the server
var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

var configResponse = await httpClient.GetFromJsonAsync<Setting>("api/configuration");
var apiUrl = configResponse.ApiUrl;

builder.Services.AddRestEaseClient<IRestClient>(apiUrl);

await builder.Build().RunAsync();
