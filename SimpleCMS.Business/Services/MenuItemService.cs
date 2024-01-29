using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SimpleCMS.Business.Services
{
    public class MenuItemService: IMenuItemsService
    {
        private readonly IMenuItemsRepository _menuItemsRepository;
        public MenuItemService(IMenuItemsRepository menuItemsRepository)
        {
            _menuItemsRepository = menuItemsRepository;
        }

        public async Task<IEnumerable<MenuItem>> GetMenuItemsAsync()
        {
            return await _menuItemsRepository.GetAllMenuItemsAsync();
        }

        public Task DeleteAsync(MenuItem item)
        {
            return _menuItemsRepository.DeleteAsync(item);
        }

        public async Task<MenuItem?> GetMenuItemsByIdAsync(int id)
        {
            return await _menuItemsRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<MenuItem?>> GetMenuItemsByParentIdAsync(int id)
        {
            return await _menuItemsRepository.GetByParentIdAsync(id);
        }
        public async Task<MenuItem> AddMenuItems(MenuItem item)
        {
            return await _menuItemsRepository.AddAsync(item);
        }
        public async Task<bool> IsMenuItemAParent(int id)
        {
            return await _menuItemsRepository.HasChildItemsAsync(id);
        }

        public async Task UpdateMenuItem(MenuItem item)
        {
           await _menuItemsRepository.UpdateAsync(item);
        }

        public async Task<MenuItem> FindAsync(int id)
        {
            return await _menuItemsRepository.FindAsync(id);
        }



    }
}
