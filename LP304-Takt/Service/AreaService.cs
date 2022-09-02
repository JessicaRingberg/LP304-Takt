using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Data;
namespace LP304_Takt.Service
{
    public class AreaService : IAreaService
    {
        private readonly IUnitOfWork _areaUnitOfWork;

        public AreaService(IUnitOfWork areaUnitOfWork)
        {
            _areaUnitOfWork = areaUnitOfWork;
        }

        public async Task<IEnumerable<Area>> GetAllAreas()
        {
            return await _areaUnitOfWork.Areas.GetAllAreas();
        }

        public async Task<Area> GetOneArea(int id)
        {
            return await _areaUnitOfWork.Areas.GetOneArea(id);
        }

        public async Task AddArea(Area area, int id)
        {
            await _areaUnitOfWork.Areas.AddArea(area, id);
        }

        public async Task RemoveArea(Area area)
        {
            await _areaUnitOfWork.Areas.RemoveArea(area);
        }

        public async Task DeleteById(int id)
        {
            var area = await _areaUnitOfWork.Areas.GetById(id);
            await _areaUnitOfWork.Areas.Remove(area);
            _areaUnitOfWork.Complete();

        }

        public async Task<Area> UpdateArea(Area area)
        {
            return await _areaUnitOfWork.Areas.Update(area);
        }

    }
}
