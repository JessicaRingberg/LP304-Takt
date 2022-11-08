using LP304_Takt.DTO.CreateDTO;
using LP304_Takt.DTO.ReadDto;
using LP304_Takt.DTO.UpdateDTOs;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ConfigController : ControllerBase
    {
        private readonly IConfigService _configService;

        public ConfigController(IConfigService configService)
        {
            _configService = configService;
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPost]
        public async Task<IActionResult> AddConfig([FromBody] ConfigCreateDto config, [FromQuery] int areaId)
        {
            var response = await _configService.Add(config.AsEntity(), areaId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ConfigDto>>> GetConfigs()
        {
            return Ok((await _configService.GetEntities()).Select(c => c.AsDto()));
        }

        [HttpGet("{configId}")]
        public async Task<ActionResult<ConfigDto>> GetConfig(int configId)
        {
            var config = await _configService.GetEntity(configId);

            if (config is null)
            {
                return NotFound($"Config with id {configId} was not found.");
            }

            return Ok(config.AsDto());
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpDelete("{configId}")]
        public async Task<IActionResult> DeleteConfig(int configId)
        {
            var response = await _configService.DeleteEntity(configId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        //[Authorized(Role.Admin, Role.SuperUser)]
        [HttpPut]
        public async Task<IActionResult> UpdateConfig([FromBody] ConfigUpdateDto config, [FromQuery] int configId)
        {
            var response = await _configService.UpdateEntity(config.AsUpdated(), configId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
