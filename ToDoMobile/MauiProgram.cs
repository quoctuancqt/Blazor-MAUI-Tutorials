using Blazored.LocalStorage;
using Common;
using Common.Extensions;
using Common.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;

namespace ToDoMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif
            builder.Services.AddBmsApiClient("http://sss-iot-api.azurewebsites.net/");

            RegisterCustomServices(builder.Services);

            return builder.Build();
        }

        private static void RegisterCustomServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();
            services.AddScoped<CustomAuthStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthStateProvider>());
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}