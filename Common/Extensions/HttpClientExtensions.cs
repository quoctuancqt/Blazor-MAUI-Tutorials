using Common.Handlers;
using Common.Providers;
using Common.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Web;

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

        public static string GetQueryString(this object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null && !p.GetValue(obj, null).GetType().Equals(typeof(string[]))
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return string.Join("&", properties.ToArray());
        }
    }
}
