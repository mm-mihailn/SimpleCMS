using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleCMS.Data.Repositories.Interfaces
{
    public interface IMenuItemsRepository: IRepository<MenuItem>
    {
        Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync();
        Task<MenuItem?> GetByIdAsync(int id);
        Task<IEnumerable<MenuItem>> GetByParentIdAsync(int id);
        Task <bool> HasChildItemsAsync(int parentId);
        
    }
}
