using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleCMS.Business.Services;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCMS.Web.ViewComponents

{
    public class MenuItemsViewComponent : ViewComponent
    {
        private IMenuItemsService _menuItemsService;
        public MenuItemsViewComponent(IMenuItemsService menuItemsService)
        {
            _menuItemsService = menuItemsService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuItems = await _menuItemsService.GetMenuItemsAsync();
            var model = new List<MenuItemsViewModel>();
            var children = await _menuItemsService.GetChildrenByParentIdAsync(2);
            foreach (var menuItem in menuItems.Where(p => p.ParentId == null))
            {
                var menuItemViewModel = new MenuItemsViewModel
                {
                    Id = menuItem.Id,
                    Title = menuItem.Title,
                    Link = menuItem.Link,
                    Published = menuItem.Published,
                    ParentId = menuItem.ParentId,
                    Parent = menuItem.Parent,
                    SubMenuItems = await _menuItemsService.GetChildrenByParentIdAsync(menuItem.Id)
                };

                model.Add(menuItemViewModel);
            }

            return View(model);
        }

    }
}