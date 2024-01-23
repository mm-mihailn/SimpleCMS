using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Admin.Models;
using System.Diagnostics;
using SimpleCMS.Business.Services.Interfaces;

namespace SimpleCMS.Admin.Controllers
{
    public class HomeController : Controller
        //efsfsefsefesfesfs
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersService _usersService;
        
        public HomeController(ILogger<HomeController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _usersService.GetUsersAsync();
            // Todo - map to UserViewModel and pass it the view
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}