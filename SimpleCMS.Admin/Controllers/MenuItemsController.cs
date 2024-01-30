﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Admin.Models;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using System.Diagnostics;

namespace SimpleCMS.Admin.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Create()
        {
            ViewBag.ParentItems = await _menuItemsService.GetMenuItemsAsync();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(MenuItem item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    if (item.ParentId.HasValue)
                    {
                        var selectedParent = await _menuItemsService.FindAsync(item.ParentId.Value);

                        if (selectedParent != null)
                        {
                            
                            item.ParentId = selectedParent.Id;
                            item.Parent = selectedParent;
                            
                        }
                        else
                        {
                           
                            ModelState.AddModelError("ParentId", "Selected parent not found");
                            
                            ViewBag.ParentItems = await _menuItemsService.GetMenuItemsAsync();
                            return View(item);
                        }
                    }
                    else
                    {
                        
                        item.ParentId = null;
                        item.Parent = null;
                    }

                    await _menuItemsService.AddMenuItems(item);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }

           
            ViewBag.ParentItems = await _menuItemsService.GetMenuItemsAsync();

            return View(item);
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
            ViewBag.ParentItems = await _menuItemsService.GetMenuItemsAsync();
            ViewBag.ParentItems = ((IEnumerable<MenuItem>)ViewBag.ParentItems)
    .Where(menuItem => menuItem.Id != item.Id)
    .ToList();
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
                   
                    if (item.ParentId.HasValue)
                    {
                        var selectedParent = await _menuItemsService.FindAsync(item.ParentId.Value);

                        if (selectedParent != null)
                        {
                            
                            item.ParentId = selectedParent.Id;
                            item.Parent = selectedParent;
                            

                           await _menuItemsService.UpdateMenuItem(item);
                            return RedirectToAction(nameof(Index));
                        }
                    }

                    
                    item.ParentId = null;
                    item.Parent = null;
                    

                  await  _menuItemsService.UpdateMenuItem(item);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }

            
            ViewBag.ParentItems = await _menuItemsService.GetMenuItemsAsync();
           

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
            if (item!=null)
            {
                var IsParent = await _menuItemsService.IsMenuItemAParent(id);
                if (IsParent) 
                {
                    var childItems = await _menuItemsService.GetMenuItemsByParentIdAsync(id);
                    foreach (var childItem in childItems)
                    {
                        childItem.ParentId = null;
                        childItem.Parent = null;

                       
                       await _menuItemsService.UpdateMenuItem(childItem);

                    }
                    await _menuItemsService.DeleteAsync(item);
                }
                else
                {
                    await _menuItemsService.DeleteAsync(item);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
