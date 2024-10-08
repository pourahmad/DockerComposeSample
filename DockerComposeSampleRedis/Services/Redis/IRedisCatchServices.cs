
using DockerComposeSampleRedis.Models;

namespace DockerComposeSampleRedis.Services.Redis
{
    public interface IRedisCatchServices
    {
        Task<string> GetRedisCatchAsync(string key);
        Task SetRedisCatchAsync(RedisDto redisDto);
        Task UpdateRedisCatchAsync(RedisDto redisDto);
        Task<object> RemoveDataAsync(string key);
    }
}