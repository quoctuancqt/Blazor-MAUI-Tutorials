using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using ToDoShared.Services;

namespace ToDoShared.Extensions
{
    public static class ServiceDependencies
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();
            services.AddScoped<CustomAuthStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthStateProvider>());
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDeviceService, DeviceService>();

            return services;
        }
    }
}
