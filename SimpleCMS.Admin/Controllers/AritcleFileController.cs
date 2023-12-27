using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Admin.Models;
using SimpleCMS.Admin.Models.ViewModel;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Repositories.Interfaces;
using System.Diagnostics;

namespace SimpleCMS.Admin.Controllers
{
    public class AritcleFileController : Controller
    {
        private readonly IAritcleFileService _aritcleFileService;
        public AritcleFileController(IAritcleFileService aritcleFileService)
        {
            _aritcleFileService = aritcleFileService;
        }
        public async Task<IActionResult> Index()
        {
            ArticleFileViewModel articleFileViewModel = new ArticleFileViewModel();
            articleFileViewModel.ArticleFiles = (await _aritcleFileService.GetArticleFileAsync()).ToList();

            return View(articleFileViewModel);
        }

        public IActionResult Private()
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
