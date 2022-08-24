using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class MacRepository :GenericRepository<Mac>, IMacRepository
    {
        public MacRepository(LP304Context context) : base(context)
        {

        }
    }
}
