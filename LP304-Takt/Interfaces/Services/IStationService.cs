using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IStationService : IBaseService<Station>
    {
        Task<ServiceResponse<Station>> Add(Station station, int areaId);     
    }
}
