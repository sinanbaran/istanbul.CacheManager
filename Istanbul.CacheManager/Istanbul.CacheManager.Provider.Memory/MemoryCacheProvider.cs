using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Istanbul.CacheManager.Provider.Memory
{
    public class MemoryCacheProvider : ICacheProvider
    {
        public IMemoryCache Cache { get; set; }

        public MemoryCacheProvider()
        {
            Cache = new MemoryCache(new MemoryCacheOptions());
        }
        public Task<bool> DeleteAsync(string key)
        {
            Cache.Remove(key);
            return Task.FromResult(true);
        }
        public Task<bool> ExistsAsync(string key)
        {
            return Task.FromResult(Cache.TryGetValue(key, out _));
        }
        public Task<bool> SetAsync(string key, string serializedItem, TimeSpan? expiry)
        {
            Cache.Set(key, serializedItem);
            return Task.FromResult(true);
        }
        public Task<string> GetAsync(string key)
        {
            return Task.FromResult(Cache.Get<string>(key));
        }
        public async Task ClearAsync()
        {
            await Task.CompletedTask;
            Cache = new MemoryCache(new MemoryCacheOptions());
        }
        public void Dispose() => Cache.Dispose();

        public Task RemoveByPatternAsync(string pattern)
        {
            throw new NotImplementedException("Memory Cache is not supported on this feature");
        }


    }
}
