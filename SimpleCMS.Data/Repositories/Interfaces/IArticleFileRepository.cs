using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleCMS.Data.Models;

namespace SimpleCMS.Data.Repositories.Interfaces
{
    public interface IArticleFileRepository : IRepository<ArticleFile>
    {
        Task<IEnumerable<ArticleFile>> GetAllFileAsync();
        Task<ArticleFile> GetByIdAsync(int id);
        Task<ArticleFile> GetByNameAsync(string name);
        Task<int> GetCountAllAsync();

    }
}
