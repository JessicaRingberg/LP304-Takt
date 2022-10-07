﻿using LP304_Takt.Interfaces.Repositories;
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

        public async Task<ServiceResponse<int>> Add(Article article)
        {
            return await _articleRepository.Add(article);
        }

        public async Task DeleteEntity(int id)
        {
            await _articleRepository.DeleteEntity(id);
        }

        public async Task<ICollection<Article>> GetEntities()
        {
            return await _articleRepository.GetEntities();
        }

        public async Task<Article?> GetEntity(int id)
        {
            return await _articleRepository.GetEntity(id);
        }

        public Task UpdateEntity(Article entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}