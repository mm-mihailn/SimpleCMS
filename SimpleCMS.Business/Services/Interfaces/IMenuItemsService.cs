using SimpleCMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleCMS.Business.Services.Interfaces
{
    public interface IMenuItemsService
    {
        Task<IEnumerable<MenuItem>> GetMenuItemsAsync();
        Task<MenuItem?> GetMenuItemsByIdAsync(int id);
        Task<MenuItem> AddMenuItems(MenuItem item);
        Task<MenuItem> FindAsync(int id);
        Task DeleteAsync(MenuItem item);
        void UpdateMenuItem(MenuItem item);
    }
}
