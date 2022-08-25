using LP304_Takt.Repositories;

namespace LP304_Takt.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ICompanyRepository Companies { get; }
        IRoleRepository Roles { get; }
        IOrderRepository Orders { get; }
        
        int Complete();
    }
}
