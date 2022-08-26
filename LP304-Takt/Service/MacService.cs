using LP304_Takt.Models;
using LP304_Takt.UnitOfWork;

namespace LP304_Takt.Service
{
    public class MacService : IMacService
    {
        private readonly IUnitOfWork _macUnitOfWork;

        public MacService(IUnitOfWork macUnitOfWork)
        {
            _macUnitOfWork = macUnitOfWork;
        }
        public async Task AddMac(Mac mac)
        {
            await _macUnitOfWork.Macs.Add(mac);
        }

        public async Task<IEnumerable<Mac>> GetAllMac()
        {
            return await _macUnitOfWork.Macs.GetAll();
        }

        public async Task<Mac> GetOneMac(int id)
        {
            return await _macUnitOfWork.Macs.GetById(id);
        }

        public async Task RemoveMac(Mac mac)
        {
            await _macUnitOfWork.Macs.Remove(mac);
        }
    }
}
