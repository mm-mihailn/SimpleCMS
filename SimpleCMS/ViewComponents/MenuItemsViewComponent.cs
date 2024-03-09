using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleCMS.Business.Services;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Web.Models;
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
            var menuItems = await _menuItemsService.GetMenuItemsAsync();
            var model = menuItems
                .Where(p => p.ParentId == null)
                .Select(p => new MenuItemsViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Link = p.Link,
                    Published = p.Published,
                    ParentId = p.ParentId,
                    Parent = p.Parent,
                    SubMenuItems = p.SubMenuItems
                })
                .ToList();

            return View(model);

        }
    }
}
