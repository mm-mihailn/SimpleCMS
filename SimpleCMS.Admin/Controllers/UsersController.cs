using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Admin.Models;
using SimpleCMS.Admin.Models.ViewModel;
using SimpleCMS.Business.Services;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using System.Diagnostics;
using System.Security.Claims;
using PagedList;
using PagedList.Mvc;


namespace SimpleCMS.Admin.Controllers
{
    //[Authorize]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService userService)
        {
            _usersService = userService;
        }

        public class IndexViewModel
        {
            public List<User> Users { get; set; }
        }
        public async Task<IActionResult> Index(int? page,string email)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            IEnumerable<User> users;

            if (!string.IsNullOrEmpty(email))
            {
                var foundUser = await _usersService.GetUserByEmail(email);
                if (foundUser != null)
                {
                    users = new List<User> { foundUser };
                }
                else
                {
                    users = new List<User>();
                }
            }
            else
            {
                users = await _usersService.GetUsersAsync();
            }
            var pagedList = users.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
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
        public async Task<IActionResult> Create(User user)
        {

            if (ModelState.IsValid)
            {
                await _usersService.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var user = await _usersService.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
      
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, User updateUser)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            var user = await _usersService.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingUserWithEmail = await _usersService.GetUserByEmail(updateUser.Email);
                if (existingUserWithEmail != null && existingUserWithEmail.Id != user.Id)
                {
                    
                    ModelState.AddModelError("Email", "Имейл адресът вече е регистриран.");
                    return View(updateUser);
                }
                try
                {
                    user.Name = updateUser.Name;
                    user.Email = updateUser.Email;
                    user.PasswordHash = updateUser.PasswordHash;
                    _usersService.UpdateUser(user);

                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(updateUser);

        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _usersService.FindAsync(id);
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(string id)
        {

            var user = await _usersService.GetUserByIdAsync(id);
            if (user != null)
            {
                await _usersService.DeleteAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
