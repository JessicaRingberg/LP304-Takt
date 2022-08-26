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

            Areas = new AreaRepository(_context);
            Companies = new CompanyRepository(_context);
            Orders = new OrderRepository(_context);
            Roles = new RoleRepository(_context);
            Users = new UserRepository(_context);
        }
        public IAreaRepository Areas { get; }
        public ICompanyRepository Companies { get; }
        public IOrderRepository Orders { get; }
        public IRoleRepository Roles { get; }
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
