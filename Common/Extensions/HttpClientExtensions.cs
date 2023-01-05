using Common.Handlers;
using Common.Providers;
using Common.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Extensions
{
    public static class HttpClientExtensions
    {
        public static IServiceCollection AddBmsApiClient(this IServiceCollection services, string url)
        {
            services.AddSingleton<SpinnerService>();

            services.AddScoped<LoadingInterceptorHandler>();

            services.AddHttpClient<BmsApiClient>(configs =>
            {
                configs.BaseAddress = new Uri(url);
            }).AddHttpMessageHandler<LoadingInterceptorHandler>();

            return services;
        }
    }
}
