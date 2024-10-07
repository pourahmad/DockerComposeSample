using DockerComposeSample.Services.Redis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerComposeSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController(IRedisCatchServices redisCatchServices) : ControllerBase
    {
        private readonly IRedisCatchServices _redisCatchServices = redisCatchServices;

        [HttpGet]
        public async Task<ActionResult> Get(string key)
        {
            var result = await _redisCatchServices.GetRedisCatchAsync(key);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(string key, string message)
        {
            await _redisCatchServices.SetRedisCatchAsync(key, message);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Put(string key, string message)
        {
            await _redisCatchServices.UpdateRedisCatchAsync(key, message);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string key)
        {
           var result = await _redisCatchServices.RemoveDataAsync(key);
            return Ok(result);
        }
    }
}
