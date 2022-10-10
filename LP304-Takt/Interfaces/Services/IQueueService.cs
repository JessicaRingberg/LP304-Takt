using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IQueueService : IBaseService<Queue>
    {
        Task<ServiceResponse<int>> Add(int id);
    }
}
