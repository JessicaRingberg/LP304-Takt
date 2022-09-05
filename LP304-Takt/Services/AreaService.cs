using LP304_Takt.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;

namespace LP304_Takt.Service
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task Add(Area area, int companyId)
        {
            await _areaRepository.Add(area, companyId);
        }

        public async Task DeleteEntity(int id)
        {
            await _areaRepository.DeleteEntity(id);
        }

        public async Task<ICollection<Area>> GetEntities()
        {
            return await _areaRepository.GetEntities();
        }

        public async Task<Area> GetEntity(int id)
        {
            return await _areaRepository.GetEntity(id);
        }

        //public async Task UpdateArea(Area area)
        //{
        //    await _areaRepository.UpdateEntity(area);
        //}

        public async Task UpdateEntity(Area area)
        {
            await _areaRepository.UpdateEntity(area);
        }
    }
}
