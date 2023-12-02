using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories.Interfaces;

namespace SimpleCMS.Data.Repositories
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<int> GetCountAllAsync()
        {
            return await Entities.CountAsync();
        }
    }
}
