using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Repositories
{
    public interface IArticleRepository : IBaseRepository<Article>
    {
        Task<ServiceResponse<int>> Add(Article article);
    }
}
