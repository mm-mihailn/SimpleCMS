using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Business.Services.Interfaces
{
    public interface IArticlesService
    {
        Task<IEnumerable<Article>> GetArticlesAsync();
        Task DeleteAsync(Article article);
        void UpdateArticle(Article article);
        Task<Article> FindAsync(int id);
        Task<IEnumerable<Article>> GetAllArticlesAsync();
        Task<Article> AddArticle(Article article);
        Task<Article?> GetArticleByIdAsync(int id);
        Task CreateArticle(Article article);

    }
}
