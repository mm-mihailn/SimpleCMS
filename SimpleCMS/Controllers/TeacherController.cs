using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Data.Repositories.Interfaces;
using SimpleCMS.Data;

namespace SimpleCMS.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IConfiguration _configuration;
        public TeacherController(ApplicationDbContext context, ITeacherRepository teacherRepository,
            IConfiguration configuration)
        {
            _context = context;
            _teacherRepository = teacherRepository;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var teacher = _context.Teachers.ToList();

            return View(teacher);
        }

    }
}
