using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Interfaces.Services
{
    public interface IArticleService : IBaseService<Article>
    {
        Task<ServiceResponse<Article>> Add(Article article);
    }
}
