using Blazored.LocalStorage;
using Common;
using Common.Extensions;
using Common.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ToDoApp;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var services = builder.Services;

services.AddBmsApiClient("http://sss-iot-api.azurewebsites.net/");

RegisterCustomServices(services);

await builder.Build().RunAsync();

void RegisterCustomServices(IServiceCollection services)
{
    services.AddOptions();
    services.AddBlazoredLocalStorage();
    services.AddAuthorizationCore();
    services.AddScoped<CustomAuthStateProvider>();
    services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthStateProvider>());
    services.AddScoped<IAuthService, AuthService>();
}