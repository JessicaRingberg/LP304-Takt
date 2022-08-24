using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(LP304Context context) : base(context)
        {
        }
    }
}
