using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimpleCMS.Admin.Models;
namespace SimpleCMS.Admin.Views.Shared
{
    public class _NavPartialModel : PageModel
    {
        public List<MenuItemsViewModel> DynamicMenuItems = new List<MenuItemsViewModel>();
        public void OnGet()
        {
            DynamicMenuItems.Add(new MenuItemsViewModel { Link = "#", Title = "Училище" });
        }
    }
}
