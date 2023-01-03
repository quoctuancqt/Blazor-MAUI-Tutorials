using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ToDoApp;
using ToDoApp.Providers;
using ToDoApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var services = builder.Services;

services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = false;
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

services.AddHttpClient<BmsApiClient>(configs =>
{
    configs.BaseAddress = new Uri("http://sss-iot-api.azurewebsites.net/");
});

//services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://sss-iot-api.azurewebsites.net/") });

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