using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Business.Services
{
    public class ArticlesService : IArticlesService
    {
        private readonly IArticlesRepository _articleRepository;
        public ArticlesService(IArticlesRepository articlesRepository)
        {
            _articleRepository = articlesRepository;
        }
        public async Task<Article> AddArticle(Article article)
        {
            return await _articleRepository.AddAsync(article);
        }

        public async Task DeleteAsync(Article article)
        {
            await _articleRepository.DeleteAsync(article);
        }
        public async Task<IEnumerable<Article>> GetAllArticlesAsync()
        {
            return await _articleRepository.GetAllArticlesAsync();
        }

        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            return await _articleRepository.GetAllArticlesAsync();
        }
       

        public async Task CreateArticle(Article article)
        {
            await _articleRepository.AddAsync(article);
        }

        public void UpdateArticle(Article article)
        {
            _articleRepository.UpdateAsync(article);
        }

        public async Task<Article> FindAsync(int id)
        {
            return await _articleRepository.FindAsync(id);
        }

        public async Task<Article?> GetArticleByIdAsync(int id)
        {
            return await _articleRepository.GetByIdAsync(id);
        }
    }
}
