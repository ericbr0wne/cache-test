using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

public class CacheService
{
    // From Microsoft.Extensions.Caching.Memory
    private readonly IMemoryCache _cache;
    private readonly ILogger<CacheService> _logger;

    public CacheService(IMemoryCache cache, ILogger<CacheService> logger)
    {
        _cache = cache;
        _logger = logger;
    }

public (DateTime DateTime, string Message) GetOrSetCurrentDateTime()
{
    DateTime currentDateTime = DateTime.Now;

    if (!_cache.TryGetValue(CacheKeys.Entry, out DateTime cacheValue))
    {
        cacheValue = currentDateTime;

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(1))
            .SetAbsoluteExpiration(TimeSpan.FromHours(1));

        _cache.Set(CacheKeys.Entry, cacheValue, cacheEntryOptions);
        return (cacheValue, "Newly generated and cached");
    }
    Console.WriteLine(cacheValue);
    return (cacheValue, "Retrieved from cache");
}

    public static class CacheKeys
    {
        public static string Entry => "_CacheEntry";
    }
}
