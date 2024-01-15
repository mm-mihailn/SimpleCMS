using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Admin.Models;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using System.Diagnostics;

namespace SimpleCMS.Admin.Controllers
{
    public class MenuItemsController : Controller
    {
        private readonly IMenuItemsService _menuItemsService;

        public MenuItemsController(IMenuItemsService menuItemsService)
        {
            _menuItemsService = menuItemsService;
        }
        public async Task<IActionResult> Index()
        {
            MenuItemsViewModel viewModell = new MenuItemsViewModel();
            viewModell.Items = (await _menuItemsService.GetMenuItemsAsync()).ToList();

            return View(viewModell);
        }
        [HttpPost]

        public async Task<IActionResult> Create(MenuItem item)
        {
            if (ModelState.IsValid)
            {
               

                await _menuItemsService.AddMenuItems(item);
                return RedirectToAction(nameof(Index));

            }

            return View(item);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _menuItemsService.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int id, MenuItem item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _menuItemsService.UpdateMenuItem(item);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }
        public async Task<IActionResult> Delete(int id)
        {

            var item = await _menuItemsService.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var item = await _menuItemsService.GetMenuItemsByIdAsync(id);
            if (item != null)
            {
                await _menuItemsService.DeleteAsync(item);
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Private()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
