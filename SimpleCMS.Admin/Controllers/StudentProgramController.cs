using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using SimpleCMS.Admin.Models.ViewModel;
using SimpleCMS.Business.Services;

namespace SimpleCMS.Admin.Controllers
{
    [Authorize]
    public class StudentProgramController : Controller
    {
        private readonly IStudentProgramService _studentProgramService;
        public StudentProgramController(IStudentProgramService studentProgramService)
        {
            _studentProgramService = studentProgramService;
        }
        public async Task<IActionResult> Index()
        {
            StudentProgramViewModel viewModel = new StudentProgramViewModel
            {
                StudentPrograms = (await _studentProgramService.GetStudentProgramAsync()).ToList()
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentProgram studentProgram)
        {
            return View(studentProgram);
        }
    }
}
