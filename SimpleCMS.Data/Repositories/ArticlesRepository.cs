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
    public class ArticlesRepository : Repository<Article>, IArticlesRepository
    {
        public ArticlesRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Article>> GetAllArticlesAsync()
        {
            return await Entities.ToListAsync();
        }

      

        public async Task<Article> GetArticleById(int id)
        {
            return await Entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Article?> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Article?> GetByNameAsync(string name)
        {
            return await Entities.FirstOrDefaultAsync(x => x.Title == name);
        }
    }
}
