using Microsoft.EntityFrameworkCore;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleCMS.Data.Repositories
{
    public class MenuItemsRepository:Repository<MenuItem>,IMenuItemsRepository
    {
        public MenuItemsRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<MenuItem?> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<MenuItem>> GetByParentIdAsync(int id)
        {
            return await Entities
        .Where(x => x.ParentId == id)
        .ToListAsync(); 
        }
        public  async Task<bool> HasChildItemsAsync(int parentId)
        {
            return await Entities.AnyAsync(x => x.ParentId == parentId);
        }
        
    }
}
