
using Microsoft.Extensions.DependencyInjection;

namespace Istanbul.CacheManager.Provider.Memory
{
    public static class PackagesExtensions
    {
        public static IServiceCollection AddCacheMemory(this IServiceCollection services)
        {
            services.AddSingleton<ICacheManager>(new CacheManager(new MemoryCacheProvider()));
            return services;
        }
    }
}