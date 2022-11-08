using LP304_Takt.Interfaces.Repositories;
using LP304_Takt.Models;
using LP304_Takt.Shared;
using Microsoft.EntityFrameworkCore;

namespace LP304_Takt.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DataContext _context;

        public ArticleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Article>> Add(Article article)
        {
            var found = await _context.Article.FirstOrDefaultAsync(a => a.ArticleNumber == article.ArticleNumber);
            if (found is not null)
            {
                return new ServiceResponse<Article>()
                {
                    Success = false,
                    Message = $"This article already exists!"
                };
            }

            await _context.Article.AddAsync(article);

            await _context.SaveChangesAsync();
            return new ServiceResponse<Article>()
            {
                Data = article,
                Success = true,
                Message = $"Article {article.Name} added"
            };
        }

        public async Task<ServiceResponse<int>> DeleteEntity(int articleId)
        {
            var article = await _context.Article
                .FirstOrDefaultAsync(a => a.Id == articleId);
            if (article is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Article with id {articleId} was not found"
                };
            }
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Article with id {article.Id} deleted"
            };
        }

        public async Task<ICollection<Article>> GetEntities()
        {
            return await _context.Article
                 .ToListAsync();
        }

        public async Task<Article?> GetEntity(int articleId)
        {
            return await _context.Article
                .FirstOrDefaultAsync(a => a.Id == articleId);
        }

        public async Task<ServiceResponse<int>> UpdateEntity(Article article, int articleId)
        {
            var articleToUpdate = await _context.Article
                .FindAsync(articleId);
            if(articleToUpdate is null)
            {
                return new ServiceResponse<int>()
                {
                    Success = false,
                    Message = $"Article with id {articleId} was not found"
                };
            }
            articleToUpdate.ArticleNumber = article.ArticleNumber;
            articleToUpdate.Name = article.Name;
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>()
            {
                Success = true,
                Message = $"Article with id {article.Id} deleted"
            };
        }
    }
}
