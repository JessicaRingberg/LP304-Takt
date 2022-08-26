using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmController : ControllerBase
    {
        private readonly IAlarmService _alarmService;

        public AlarmController(IAlarmService alarmService)
        {
            _alarmService = alarmService;
        }
        [HttpGet("{id}")]
        public async Task<Alarm> GetOneAlarm(int id)
        {
            return await _alarmService.GetOneAlarm(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _alarmService.GetAllAlarms();
        }

        [HttpPost]
        public async Task AddAlarm(Alarm alarm)
        {
            await _alarmService.AddAlarm(alarm);
        }

        [HttpDelete]
        public async Task RemoveAlarm(Alarm alarm)
        {
            await _alarmService.RemoveAlarm(alarm);
        }

        [HttpPut]
        public async Task UpdateAlarm(Alarm alarm)
        {
            await _alarmService.UpdateAlarm(alarm);
        }
    }
}
