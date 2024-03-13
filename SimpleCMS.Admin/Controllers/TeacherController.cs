using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Admin.Models;
using SimpleCMS.Admin.Models.ViewModel;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using System.Diagnostics;
using System.Security.Claims;
namespace SimpleCMS.Admin.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TeacherController(ITeacherService teacherService, IWebHostEnvironment webHostEnvironment)
        {
            _teacherService = teacherService;
            _webHostEnvironment = webHostEnvironment;

        }
        public async Task<IActionResult> Index()
        {
            TeacherViewModel teacherViewModel = new TeacherViewModel();
            teacherViewModel.Teachers = (await _teacherService.GetTeacherAsync()).ToList();

            return View(teacherViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher, IFormFile image)
        {

            bool isValid = false;
            string[] validExtensions = { ".jpg", ".png", ".jpeg" };
            string uploadsFolder = Path.Combine("C:\\Users\\LENOVO GAMING\\source\\repos\\SimpleSMCTest\\SimpleCMS\\wwwroot", "TeacherImages");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileName = Path.GetFileName(image.FileName);
            string fileExtension = Path.GetExtension(fileName);
            string fileSavePath = Path.Combine(uploadsFolder, fileName);

            if (validExtensions.Contains(fileExtension))
            {
                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                teacher.Image = "\\UploadsArticleImages\\" + fileName;
                await _teacherService.AddTeacher(teacher);
                isValid = true;

                return RedirectToAction(nameof(Index));
            }
            else
            {
                isValid = false;
                return View();
            }
        }


        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }

            var setting = await _teacherService.FindTeacherAsync(id);

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

            var teacher = await _teacherService.FindTeacherAsync(id);
            if (teacher != null)
            {
                await _teacherService.DeleteAsyncTeacher(teacher);
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
