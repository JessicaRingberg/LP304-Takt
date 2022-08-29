using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        private readonly IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet("{id}")]
        public async Task<Station> GetOneStation(int id)
        {
            return await _stationService.GetOneStation(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _stationService.GetAllStations();
        }

        [HttpPost]
        public async Task AddStation(Station station)
        {
            await _stationService.AddStation(station);
        }

        [HttpDelete]
        public async Task RemoveStation(Station station)
        {
            await _stationService.RemoveStation(station);
        }

        [HttpDelete("{id}")]
        public async Task DeleteStationById(int id)
        {
            await _stationService.DeleteById(id);

        }

        [HttpPut]
        public async Task UpdateStation(Station station)
        {
            await _stationService.UpdateStation(station);
        }
    }
}
