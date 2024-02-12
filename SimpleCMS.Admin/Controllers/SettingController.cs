using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Admin.Models;
using SimpleCMS.Admin.Models.ViewModel;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using SimpleCMS.Data.Repositories.Interfaces;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Authorization;

namespace SimpleCMS.Admin.Controllers
{
    [Authorize]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<IActionResult> Index()
        {
            SettingViewModel viewModel = new SettingViewModel
            {
                Settings = (await _settingService.GetSettingAsync()).ToList()
            };

            return View(viewModel);
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
              
                if (isSettingNameExists != null)
                {
                    ModelState.AddModelError(nameof(setting.Name), "A setting with this name already exists.");
                    return View(setting);
                }

                await _settingService.AddSetting(setting);
                return RedirectToAction(nameof(Index));
            }

            return View(setting);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
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
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }

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
            return View(setting);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }
            
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
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }

            var setting = await _settingService.GetSettingByIdAsync(id);
            if (setting != null)
            {
              await _settingService.DeleteAsync(setting);
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