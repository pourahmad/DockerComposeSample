using DockerComposeSampleRedis.Models;
using DockerComposeSampleRedis.Services.Redis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerComposeSampleRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController(IRedisCatchServices redisCatchServices) : ControllerBase
    {
        private readonly IRedisCatchServices _redisCatchServices = redisCatchServices;

        [HttpGet("{key}")]
        public async Task<ActionResult> Get(string key)
        {
            var result = await _redisCatchServices.GetRedisCatchAsync(key);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RedisDto redisDto)
        {
            await _redisCatchServices.SetRedisCatchAsync(redisDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] RedisDto redisDto)
        {
            await _redisCatchServices.UpdateRedisCatchAsync(redisDto);
            return Ok();
        }

        [HttpDelete("{key}")]
        public async Task<ActionResult> Delete(string key)
        {
           var result = await _redisCatchServices.RemoveDataAsync(key);
            return Ok(result);
        }
    }
}
