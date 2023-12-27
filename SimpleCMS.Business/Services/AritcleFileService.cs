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
    public class AritcleFileService : IAritcleFileService
    {
        private readonly IArticleFileRepository _articleFileRepository;
        public AritcleFileService(IArticleFileRepository articleFileRepository)
        {
            _articleFileRepository = articleFileRepository;
        }
        public async Task<ArticleFile> AddArticleFile(ArticleFile articleFile)
        {
            return await _articleFileRepository.AddAsync(articleFile);
        }

        public async Task DeleteAsync(ArticleFile articleFile)
        {
            await _articleFileRepository.DeleteAsync(articleFile);
        }

        public async Task<IEnumerable<ArticleFile>> GetArticleFileAsync()
        {
            return await _articleFileRepository.GetAllFileAsync();
        }

        public async Task<ArticleFile?> GetArticleFileByIdAsync(int id)
        {
           return await _articleFileRepository.GetByIdAsync(id);
        }

        public async Task<ArticleFile?> GetArticleFileByName(string name)
        {
            return await _articleFileRepository.GetByNameAsync(name);
        }
    }
}
