using LP304_Takt.DTO;
using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using LP304_Takt.Shared;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddConfig([FromBody] ConfigCreateDto config, [FromQuery] int areaId)
        {
            await _configService.Add(config.AsEntity(), areaId);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<ConfigDto>>> GetConfigs()
        {
            return Ok((await _configService.GetEntities()).Select(c => c.AsDto()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ConfigDto>> GetConfig(int id)
        {
            var config = await _configService.GetEntity(id);

            if (config is null)
            {
                return NotFound($"Config with id {id} was not found.");
            }

            return Ok(config.AsDto());
        }

        [HttpDelete("{id}"), Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> DeleteConfig(int id)
        {
            await _configService.DeleteEntity(id);
            return Ok();
        }

        [HttpPut, Authorize(Roles = nameof(Role.Admin))]
        public async Task<IActionResult> UpdateConfig([FromBody] ConfigUpdateDto config, [FromQuery] int configId)
        {
            await _configService.UpdateEntity(config.AsUpdated(), configId);

            return Ok();
        }
    }
}
