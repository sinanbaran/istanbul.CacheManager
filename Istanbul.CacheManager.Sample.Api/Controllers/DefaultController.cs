using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Istanbul.CacheManager.Sample.Api.Controllers
{
    [Route("api/cache")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly ICacheManager _cacheManager;

        public DefaultController(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        [HttpGet("set")]
        public async Task<IActionResult> SetValue()
        {
            await _cacheManager.SetAsync("name", "sinan.baran");
            return Ok("");
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetValue()
        {
            return Ok(await _cacheManager.GetAsync<string>("name"));
        }
        [HttpGet("getCacheAside")]
        public async Task<IActionResult> GetCacheAside()
        {
            return Ok(await _cacheManager.GetAsync("name", GetAccountName));
        }

        private async Task<string> GetAccountName()
        {
            await Task.CompletedTask;

            return "sinan";
        }
    }
}
