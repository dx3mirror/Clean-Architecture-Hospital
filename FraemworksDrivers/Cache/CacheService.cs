using Newtonsoft.Json;
using StackExchange.Redis;

public interface ICacheService
{
    Task<T> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan expiration);
}
namespace FraemworksDrivers.Cache
{
    public class CacheService : ICacheService
    {
        private readonly IConnectionMultiplexer _redis;

        public CacheService(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var db = _redis.GetDatabase();
            var value = await db.StringGetAsync(key);

            if (value.IsNullOrEmpty)
                return default;

            return JsonConvert.DeserializeObject<T>(value);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan expiration)
        {
            var db = _redis.GetDatabase();
            var serializedValue = JsonConvert.SerializeObject(value);
            await db.StringSetAsync(key, serializedValue, expiration);
        }
    }
}
