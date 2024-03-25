using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using SimpleCMS.Admin.Models;
using SimpleCMS.Admin.Models.ViewModel;
using SimpleCMS.Business.Services;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data;
using SimpleCMS.Data.Models;
using System.Diagnostics;
using System.Security.Claims;
namespace SimpleCMS.Admin.Controllers
{
    [Authorize]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IConfiguration _configuration;

        public TeacherController(ITeacherService teacherService, IConfiguration configuration)
        {
            _teacherService = teacherService;
            _configuration = configuration;

        }
        public async Task<IActionResult> Index()
        {
            TeacherViewModel teacherViewModel = new TeacherViewModel();
            teacherViewModel.Teachers = (await _teacherService.GetTeacherAsync()).ToList();

            return View(teacherViewModel);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teacher teacher, IFormFile image)
        {
            string uploadsFolder = _configuration.GetValue<string>("AppSettings:UploadsArticleImagesPath");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileName = Path.GetFileName(image.FileName);
            
            string fileSavePath = Path.Combine(uploadsFolder, fileName);

                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                teacher.Image = "\\TeacherImages\\" + fileName;
                await _teacherService.AddTeacher(teacher);

                return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {

            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            var teacherEdit = new Teacher()
            {
                Name = teacher.Name,
                Position = teacher.Position,
                Image = teacher.Image
            };

            return View(teacherEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, Teacher teacherEdit, IFormFile image)
        {

            if (image == null || image.Length == 0)
            {
                return Content("File not selected");
            }
            string uploadsFolder = _configuration.GetValue<string>("AppSettings:UploadsArticleImagesPath");
            string fileName = Path.GetFileName(image.FileName);
            string fileSavePath = Path.Combine(uploadsFolder, fileName);

            using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            var teacherEd = new Teacher
            {
                Id = teacherEdit.Id,
                Name = teacherEdit.Name,
                Position = teacherEdit.Position,
                Image = "\\TeacherImages\\" + fileName

            };


            _teacherService.UpdateTeacher(teacherEd);

            return RedirectToAction("Index");
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
