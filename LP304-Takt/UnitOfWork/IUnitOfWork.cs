﻿using LP304_Takt.Repositories;

namespace LP304_Takt.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAreaRepository Areas { get; }
        ICompanyRepository Companies { get; }
        IConfigRepository Configs { get; }
        IMacRepository Macs { get; }
        IOrderRepository Orders { get; }
        IQueueRepository Queues { get; }
        IRoleRepository Roles { get; }
        IStationRepository Stations { get; }
        IUserRepository Users { get; }
        
        
        
        int Complete();
    }
}
