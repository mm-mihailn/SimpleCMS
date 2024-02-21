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
            var menuItems = await _menuItemsService.GetMenuItemsAsync();
            var model = menuItems.Where(p=>p.ParentId==null).Select(p => p.Title);
            //return View(model.Any()?model.ToList():new List<string>());
            return View(new List<string>());


        }
    }
}
