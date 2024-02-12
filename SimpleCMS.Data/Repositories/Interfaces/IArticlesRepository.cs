using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Repositories.Interfaces
{
    public interface IArticlesRepository: IRepository<Article>
    {
        Task<IEnumerable<Article>> GetAllArticlesAsync();
        Task<Article> GetArticleById(int id);
        Task<Article?> GetByIdAsync(int id);
        Task<Article?> GetByNameAsync(string name);
    }
}
