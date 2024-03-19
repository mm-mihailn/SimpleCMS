using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Admin.Models;
using SimpleCMS.Admin.Models.ViewModel;
using SimpleCMS.Business.Services;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using System.Diagnostics;

namespace SimpleCMS.Admin.Controllers
{
    public class SpecialtiesController : Controller
    {
        private readonly ISpecialtiesService _specialtiesService;

        public SpecialtiesController(ISpecialtiesService specialtiesService)
        {
            _specialtiesService = specialtiesService;
        }

        public async Task<IActionResult> Index()
        {
            SpecialtieViewModel specialtieViewModel = new SpecialtieViewModel();
            specialtieViewModel.Specialties = (await _specialtiesService.GetSpecialtiesAsync()).ToList();

            return View(specialtieViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Specialtie specialtie)
        {
            if (ModelState.IsValid)
            {
                await _specialtiesService.CreateSpecialtie(specialtie);
                return RedirectToAction(nameof(Index));
            }
            return View(specialtie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialtie = await _specialtiesService.GetSpecialtieByIdAsync(id.Value);
            if (specialtie == null)
            {
                return NotFound();
            }
            return View(specialtie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Specialtie specialtie)
        {
            if (id != specialtie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _specialtiesService.UpdateSpecialtieAsync(specialtie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(specialtie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialtie = await _specialtiesService.GetSpecialtieByIdAsync(id.Value);
            if (specialtie == null)
            {
                return NotFound();
            }

            return View(specialtie);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _specialtiesService.GetSpecialtieByIdAsync(id);
            if (article != null)
            {
                await _specialtiesService.DeleteAsync(article);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
