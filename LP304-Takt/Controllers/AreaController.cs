using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;
        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }
        [HttpGet]
        public async Task<IEnumerable<Area>> GetAll()
        {
            return await _areaService.GetAllAreas();

        }


        [HttpGet("{id}")]
        public async Task<Area> GetOneArea(int id)
        {
            return await _areaService.GetOneArea(id);
        }

        [HttpPost("{companyId}")]
        public async Task AddArea(Area area, int companyId)
        {
            await _areaService.AddArea(area, companyId);
        }

        [HttpDelete]
        public async Task RemoveArea(Area area)
        {
            await _areaService.RemoveArea(area);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAreaById(int id)
        {
            await _areaService.DeleteById(id);
        }

      
    }
}
