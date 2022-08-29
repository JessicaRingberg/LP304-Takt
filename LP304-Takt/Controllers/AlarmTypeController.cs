using System.Collections;
using LP304_Takt.Models;
using LP304_Takt.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LP304_Takt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmTypeController : ControllerBase
    {
        private readonly IAlarmTypeService _alarmTypeService;

        public AlarmTypeController(IAlarmTypeService alarmTypeService)
        {
            _alarmTypeService = alarmTypeService;
        }
        [HttpGet("{id}")]
        public async Task<AlarmType> GetOneAlarmType(int id)
        {
            return await _alarmTypeService.GetOneAlarmType(id);
        }

        [HttpGet]
        public async Task<IEnumerable> GetAll()
        {
            return await _alarmTypeService.GetAllAlarmTypes();
        }

        [HttpPost]
        public async Task AddAlarmType(AlarmType alarmType)
        {
            await _alarmTypeService.AddAlarmType(alarmType);
        }

        [HttpDelete]
        public async Task RemoveAlarm(AlarmType alarmType)
        {
            await _alarmTypeService.RemoveAlarmType(alarmType);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAlarmTypeById(int id)
        {
            await _alarmTypeService.DeleteById(id);

        }

        [HttpPut]
        public async Task UpdateAlarm(AlarmType alarmType)
        {
            await _alarmTypeService.UpdateAlarmType(alarmType);
        }
    }
}
