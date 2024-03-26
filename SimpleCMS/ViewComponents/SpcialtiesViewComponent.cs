using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleCMS.Business.Services;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCMS.Web.ViewComponents

{
    public class SpecialtiesViewComponent : ViewComponent
    {
        private ISpecialtiesService _specialtiesService;
        public SpecialtiesViewComponent(ISpecialtiesService specialtiesService)
        {
            _specialtiesService = specialtiesService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var specialties = await _specialtiesService.GetAllSpecialtiesAsync();
            var model = new List<SpecialtieViewModel>();
            foreach (var specialtie in specialties)
            {
                var specialtyViewModel = new SpecialtieViewModel
                {
                    Id = specialtie.Id,
                    Name = specialtie.Name,
                    Description = specialtie.Description,


                };

                model.Add(specialtyViewModel);
            }

            return View(model);
        }

    }
}
