using StackExchange.Redis;

namespace DockerComposeSample.Services.Redis;

public class RedisCatchServices : IRedisCatchServices
{
    private readonly HttpClient _client;
    private readonly IDatabase _redis;
    public RedisCatchServices(HttpClient client, IConnectionMultiplexer muxer)
    {
        _client = client;
        _client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("testRedisInfoHeader", "1.0"));
        _redis = muxer.GetDatabase();
    }

    public async Task<string> GetRedisCatchAsync(string key)
    {
        var response = await _redis.StringGetAsync(key);

        if (!string.IsNullOrEmpty(response))
            return response;
        else
            return "";
    }
    public async Task UpdateRedisCatchAsync(string key, string message)
    {
        var response = await _redis.StringGetAsync(key);
        if (!string.IsNullOrEmpty(response))
            await _redis.StringSetAsync(key, message);
    }

    public async Task SetRedisCatchAsync(string key, string message)
    {
        var response = await _redis.StringGetAsync(key);
        if (string.IsNullOrEmpty(response))
            await _redis.StringSetAsync(key, message);
    }

    public async Task<object> RemoveDataAsync(string key)
    {
        bool isKeyExist = await _redis.KeyExistsAsync(key);
        if (isKeyExist == true)
            return _redis.KeyDelete(key);

        return false;
    }

}
