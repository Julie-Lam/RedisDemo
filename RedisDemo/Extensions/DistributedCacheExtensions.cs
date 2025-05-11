using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace RedisDemo.Extensions
{
    public static class DistributedCacheExtensions
    {

        public static async Task SetRecordAsync<T>(this IDistributedCache thisCache, 
                                                        string recordId, 
                                                        T data, 
                                                        TimeSpan? absoluteExpireTime = null, 
                                                        TimeSpan? unusedExpireTime = null) 
        {

            var options = new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteExpireTime ?? TimeSpan.FromSeconds(60); 
            options.SlidingExpiration = unusedExpireTime; //If the item hasn't been used in x time period, it will expire. It overrides the AbsoluteExpirationRelativeToNow. 


            var jsonData = JsonSerializer.Serialize(data);
            await thisCache.SetStringAsync(recordId, jsonData, options); 
        }

        public static async Task<T> GetRecordAsync<T>(this IDistributedCache thisCache, string recordId) 
        {
            var jsonData = await thisCache.GetStringAsync(recordId);

            if (jsonData is null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(jsonData);

        }
    }
}
