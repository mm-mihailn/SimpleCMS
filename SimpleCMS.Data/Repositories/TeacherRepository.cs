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
    public class TeacherRepository : Repository<Teacher>,ITeacherRepository
    {
        public TeacherRepository(ApplicationDbContext context) : base(context) 
        {
            
        }

        public async Task<IEnumerable<Teacher>> GetAllTeacherAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Teacher> GetByNameAsync(string name)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Name == name);
        }

        public async Task<Teacher> GetByIdAsyncNoTracking(int id)
        {
            return await Entities.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
