using LP304_Takt.Models;

namespace LP304_Takt.Interfaces.Services
{
    public interface IQueueService : IBaseService<Queue>
    {
        Task Add(int id);
    }
}
