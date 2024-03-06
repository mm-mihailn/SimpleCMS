using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleCMS.Business.Services;
using SimpleCMS.Business.Services.Interfaces;
using System.Collections.Generic;
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
            //    var menuItems = await _menuItemsService.GetMenuItemsAsync();
            //    return View(menuItems);
            //    //var model = menuItems.Where(p => p.ParentId == null).Select(p => p.Title);
            //    //return View(model.Any() ? model.ToList() : new List<string;


            List<string> list = new List<string>() { "училище", "прием", "за родителя", "за ученика", "контакти", "галерия", "профил на купувача" };
            return View(list);


        }
    }
}
