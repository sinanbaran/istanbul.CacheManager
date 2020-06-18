
using Microsoft.Extensions.DependencyInjection;

namespace Istanbul.CacheManager.Extensions
{
    public static class PackagesExtensions
    {
        public static IServiceCollection AddCache(this IServiceCollection services, ICacheProvider provider)
        {
            services.AddSingleton<ICacheManager>(new CacheManager(provider));
            return services;
        }
    }
}