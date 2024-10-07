
namespace DockerComposeSample.Services.Redis
{
    public interface IRedisCatchServices
    {
        Task<string> GetRedisCatchAsync(string key);
        Task SetRedisCatchAsync(string key, string message);
        Task UpdateRedisCatchAsync(string key, string message);
        Task<object> RemoveDataAsync(string key);
    }
}