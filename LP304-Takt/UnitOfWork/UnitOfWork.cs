using LP304_Takt.Models;
using LP304_Takt.Repositories;

namespace LP304_Takt.UnitOfWork
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
        public IUserRepository Users { get; }
        public ICompanyRepository Companies { get; }


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
