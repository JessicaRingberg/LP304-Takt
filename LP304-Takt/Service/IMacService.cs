using LP304_Takt.Models;

namespace LP304_Takt.Service
{
    public interface IMacService
    {
        Task<IEnumerable<Mac>> GetAllMac();
        Task<Mac> GetOneMac(int id);
        Task AddMac(Mac mac);
        Task<Mac> UpdateMac(Mac mac);
        Task RemoveMac(Mac mac);
        Task DeleteById(int id);
    }
}
