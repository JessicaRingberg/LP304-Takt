using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MacController : ControllerBase
    {
        private readonly IMacService _macService;
        public MacController(IMacService macService)
        {
            _macService = macService;
        }

        [HttpGet("{id}")]
        public async Task<Mac> GetOneMac(int id)
        {
            return await _macService.GetOneMac(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _macService.GetAllMac();
        }

        [HttpPost]
        public async Task AddMac(Mac mac)
        {
            await _macService.AddMac(mac);
        }

        [HttpDelete]
        public async Task RemoveMac(Mac mac)
        {
            await _macService.RemoveMac(mac);
        }
    }
}
