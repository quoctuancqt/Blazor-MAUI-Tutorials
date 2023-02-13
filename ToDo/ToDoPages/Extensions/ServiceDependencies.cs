using Blazored.LocalStorage;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoShared.Extensions
{
    public static class ServiceDependencies
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();

            return services;
        }
    }
}
