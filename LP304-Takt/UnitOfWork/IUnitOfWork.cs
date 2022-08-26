using LP304_Takt.Repositories;

namespace LP304_Takt.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAreaRepository Areas { get; }
        ICompanyRepository Companies { get; }
        IConfigRepository Configs { get; }
        IMacRepository Macs { get; }
        IOrderRepository Orders { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        
        
        
        int Complete();
    }
}
