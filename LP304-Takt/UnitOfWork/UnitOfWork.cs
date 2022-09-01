using LP304_Takt.Models;
using LP304_Takt.Repositories;
using LP304_Takt.Service;

namespace LP304_Takt.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LP304Context _context;
        
        public UnitOfWork(LP304Context context)
        {
            _context = context;
            Alarms = new AlarmRepository(_context);
            AlarmTypes = new AlarmTypeRepository(_context);
            Areas = new AreaRepository(_context);
            Companies = new CompanyRepository(_context);
            Configs = new ConfigRepository(_context);
            Events = new EventRepository(_context);
            EventStatus = new EventStatusRepository(_context);
            Macs = new MacRepository(_context);
            OrderAlarms = new OrderAlarmRepository(_context);
            OrderEvents = new OrderEventRepository(_context);
            Orders = new OrderRepository(_context);
            Queues = new QueueRepository(_context);
            Roles = new RoleRepository(_context);
            Stations = new StationRepository(_context);
            Users = new UserRepository(_context);
        }
        public IAlarmRepository Alarms { get; }
        public IAlarmTypeRepository AlarmTypes { get; }
        public IAreaRepository Areas { get; }
        public ICompanyRepository Companies { get; }
        public IConfigRepository Configs { get; }
        public IEventRepository Events { get; }
        public IEventStatusRepository EventStatus { get; }
        public IMacRepository Macs { get; }
        public IOrderAlarmRepository OrderAlarms { get; }
        public IOrderEventRepository OrderEvents { get; }
        public IOrderRepository Orders { get; }
        public IQueueRepository Queues { get; }
        public IRoleRepository Roles { get; }
        public IStationRepository Stations { get; }
        public IUserRepository Users { get; }
        
       


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
