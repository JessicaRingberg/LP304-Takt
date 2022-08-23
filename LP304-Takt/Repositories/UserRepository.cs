using LP304_Takt.Models;

namespace LP304_Takt.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly LP304Context _lp304Context;

        public UserRepository(LP304Context lp304Context)
        {
            _lp304Context = lp304Context;
        }
    }
}
