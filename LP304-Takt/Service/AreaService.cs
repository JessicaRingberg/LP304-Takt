using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

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
            return await _areaUnitOfWork.Areas.GetAll();
        }

        public async Task<Area> GetOneArea(int id)
        {
            return await _areaUnitOfWork.Areas.GetById(id);
        }
        public async Task AddArea(Area area)
        {
            await _areaUnitOfWork.Areas.Add(area);
        }

        public async Task RemoveArea(Area area)
        {
            await _areaUnitOfWork.Areas.Remove(area);
        }
    }
}
