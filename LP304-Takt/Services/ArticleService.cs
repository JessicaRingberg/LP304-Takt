using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Interfaces.Services;
using LP304_Takt.Models;
using LP304_Takt.Shared;

namespace LP304_Takt.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ServiceResponse<Article>> Add(Article article)
        {
            return await _articleRepository.Add(article);
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int articleId)
        {
            return await _articleRepository.DeleteEntity(articleId);
        }

        public async Task<ICollection<Article>> GetEntities()
        {
            return await _articleRepository.GetEntities();
        }

        public async Task<Article?> GetEntity(int articleId)
        {
            return await _articleRepository.GetEntity(articleId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Article article, int articleId)
        {
            return await _articleRepository.UpdateEntity(article, articleId);
        }
    }
}
