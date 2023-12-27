using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Business.Services.Interfaces
{
    public interface IAritcleFileService
    {
        Task<IEnumerable<ArticleFile>> GetArticleFileAsync();
        Task DeleteAsync(ArticleFile articleFile);
        Task<ArticleFile?> GetArticleFileByIdAsync(int id);
        Task<ArticleFile?> GetArticleFileByName(string name);
        Task<ArticleFile> AddArticleFile(ArticleFile articleFile);
    }
}
