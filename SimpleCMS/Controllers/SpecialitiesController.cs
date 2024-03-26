using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Web.Models;

namespace SimpleCMS.Web.Controllers
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
            SpecialitiesViewModel specialtieViewModel = new SpecialitiesViewModel();
            specialtieViewModel.Specialties = (await _specialtiesService.GetSpecialtiesAsync()).ToList();

            return View(specialtieViewModel);
        }
    }
}
