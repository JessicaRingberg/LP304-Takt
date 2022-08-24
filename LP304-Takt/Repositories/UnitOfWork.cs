using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LP304Context _context;

        public UnitOfWork(LP304Context context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Companies = new CompanyRepository(_context);
        }
        public IUserRepository Users { get; private set; }
        public ICompanyRepository Companies { get; private set; }
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
