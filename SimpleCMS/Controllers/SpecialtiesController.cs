using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Data.Repositories.Interfaces;
using SimpleCMS.Data;

namespace SimpleCMS.Web.Controllers
{
    public class SpecialtiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISpecialtiesRepository _specialtyRepository;
        private readonly IConfiguration _configuration;
        public SpecialtiesController(ApplicationDbContext context, ISpecialtiesRepository specialityRepository,
            IConfiguration configuration)
        {
            _context = context;
            _specialtyRepository = specialityRepository;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var specialties = _context.Specialties.ToList();

            return View(specialties);
        }

    }
}