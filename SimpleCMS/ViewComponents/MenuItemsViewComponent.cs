using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Business.Services.Interfaces;
using System.Threading.Tasks;
namespace SimpleCMS.Web.ViewComponents
{
    public class MenuItemsViewComponent: ViewComponent
    {
        private IMenuItemsService _menuItemsService;
        public MenuItemsViewComponent(IMenuItemsService menuItemsService)
        {
            _menuItemsService = menuItemsService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuItem = await _menuItemsService.GetMenuItemsAsync();
            return View(menuItem);
        }
    }
}
