using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using RestEase;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using tradepro.Client.Common.Model;
using tradepro.Client.RestClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Register Blazored LocalStorage
builder.Services.AddBlazoredLocalStorage();

// Register API authorization
builder.Services.AddApiAuthorization();

// Register MudBlazor services
builder.Services.AddMudServices();

// Register the custom message handler as scoped

// Fetch configuration settings from the server
var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
var configResponse = await httpClient.GetFromJsonAsync<Setting>("api/configuration");
var apiUrl = configResponse.ApiUrl;

// Register HttpClient with custom message handler
builder.Services.AddMyApi(apiUrl);

await builder.Build().RunAsync();
