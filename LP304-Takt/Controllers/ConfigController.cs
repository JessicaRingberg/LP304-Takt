using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;
        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }

        [HttpGet("{id}")]
        public async Task<Config> GetOneConfig(int id)
        {
            return await _configService.GetOneConfig(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _configService.GetAllConfig();
        }

        [HttpPost]
        public async Task AddConfig(Config config)
        {
            await _configService.AddConfig(config);
        }

        [HttpDelete]
        public async Task RemoveConfig(Config config)
        {
            await _configService.RemoveConfig(config);
        }

        [HttpDelete("{id}")]
        public async Task DeleteConfigById(int id)
        {
            await _configService.DeleteById(id);


        }
    }
}
