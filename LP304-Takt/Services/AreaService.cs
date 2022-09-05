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

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Area>> GetEntities()
        {
            return await _areaRepository.GetEntities();
        }

        public async Task<Area> GetEntity(int id)
        {
            return await _areaRepository.GetEntity(id);
        }

    }
}
