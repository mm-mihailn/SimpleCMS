using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Admin.Models;
using SimpleCMS.Admin.Models.ViewModel;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories.Interfaces;
using System.Diagnostics;
using SimpleCMS.Data.Models;
using System.Diagnostics.Eventing.Reader;

namespace SimpleCMS.Admin.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {
            SettingViewModel viewModell = new SettingViewModel();
            viewModell.Settings = (await _settingService.GetSettingAsync()).ToList();
            
            return View(viewModell);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public async Task<IActionResult> Create(Setting setting)
        {
            if (ModelState.IsValid)
            {
                var isSettingNameExists = await _settingService.GetSettingByNameAsync(setting.Name);
                var isSettingValueExists = await _settingService.GetSettingByValueAsync(setting.Value);

                if (isSettingNameExists != null)
                {
                    ModelState.AddModelError(nameof(setting.Name), "A setting with this name already exists.");
                    return View(setting);
                }

                else if (isSettingValueExists != null)
                {
                    ModelState.AddModelError(nameof(setting.Value), "A setting with this name already value.");
                    return View(setting);
                }

                else
                { 
                    await _settingService.AddSetting(setting);
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(setting);
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setting = await _settingService.FindAsync(id);

            if (setting == null)
            {
                return NotFound();
            }
            return View(setting);
        }

        [HttpPost]
       
        public async Task<IActionResult> Edit(int id, Setting setting)
        {
            if (id != setting.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _settingService.UpdateSetting(setting);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index)); 
            }
            return View(setting) ;
        }

        public async Task<IActionResult> Delete(int id)
        {
            
            var setting = await _settingService.FindAsync(id);

            if (setting == null)
            {
                return NotFound();
            }

            return View(setting);
        }


        [HttpPost, ActionName("Delete")]
     
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
       
            var setting = await _settingService.GetSettingByIdAsync(id);
            if (setting != null)
            {
              await _settingService.DeleteAsync(setting);
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
