using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using RedisAPI.Extensions;

namespace RedisAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedisAPIController : ControllerBase
    {
        IDistributedCache _cache;
        private readonly ILogger<RedisAPIController> _logger;

        public RedisAPIController(ILogger<RedisAPIController> logger, IDistributedCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpPost]
        public async Task SetProduct()
        {
            var data = new Product()
            {
                Id = 1,
                Name = "Phone",
                Cost = 12000
            };
            await _cache.SetRecordAsync(data.Id.ToString(), data);
        }
        [HttpGet]
        public async Task<Product> GetProduct() => await _cache.GetRecordAsync<Product>("1");
    }
}