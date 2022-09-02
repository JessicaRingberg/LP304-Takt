using LP304_Takt.Repositories;

namespace LP304_Takt.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAlarmRepository Alarms { get; }
        IAlarmTypeRepository AlarmTypes { get; }
        IAreaRepository Areas { get; }
        ICompanyRepository Companies { get; }
        IConfigRepository Configs { get; }
        IEventRepository Events { get; }
        IEventStatusRepository EventStatus { get; }
        IOrderRepository Orders { get; }
        IQueueRepository Queues { get; }
        IRoleRepository Roles { get; }
        IStationRepository Stations { get; }
        IUserRepository Users { get; }
        
        
        
        int Complete();
    }
}
