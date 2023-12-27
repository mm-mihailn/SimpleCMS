using Microsoft.EntityFrameworkCore;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.Data.Repositories
{
    public class ArticleFileRepository : Repository<ArticleFile>, IArticleFileRepository
    {
        public ArticleFileRepository(ApplicationDbContext context) : base(context) 
        {
            
        }
        public async Task<IEnumerable<ArticleFile>> GetAllFileAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<ArticleFile> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ArticleFile> GetByNameAsync(string name)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<int> GetCountAllAsync()
        {
            return await Entities.CountAsync();
        }
    }
}
