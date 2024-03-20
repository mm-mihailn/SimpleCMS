using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Data.Repositories.Interfaces;
using SimpleCMS.Data;

namespace SimpleCMS.Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITeacherRepository _teacherRepository;
        public TeacherController(ApplicationDbContext context, ITeacherRepository teacherRepository)
        {
            _context = context;
            _teacherRepository = teacherRepository;
        }
        public IActionResult Index()
        {
            var teacher = _context.Teachers.ToList();

            return View(teacher);
        }

    }
}
