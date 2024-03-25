using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using SimpleCMS.Admin.Models.ViewModel;
using SimpleCMS.Business.Services;
using Microsoft.EntityFrameworkCore;

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
            if (ModelState.IsValid)
            {
                var isSettingNameExists = await _studentProgramService.GetStudentProgramByNameAsync(studentProgram.SubjectName);

                if (isSettingNameExists != null)
                {
                    ModelState.AddModelError(nameof(studentProgram.SubjectName), "A subject with this name already exists.");
                    return View(studentProgram);
                }

                await _studentProgramService.AddSetting(studentProgram);
                return RedirectToAction(nameof(Index));
            }

            return View(studentProgram);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }

            var studentProgram = await _studentProgramService.FindAsync(id);

            if (studentProgram == null)
            {
                return NotFound();
            }
            return View(studentProgram);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StudentProgram program)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }

            if (id != program.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _studentProgramService.UpdateSetting(program);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(program);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid id parameter");
            }

            var setting = await _studentProgramService.FindAsync(id);

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

            var studentProgram = await _studentProgramService.GetStudentProgramByIdAsync(id);
            if (studentProgram != null)
            {
                await _studentProgramService.DeleteAsync(studentProgram);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
