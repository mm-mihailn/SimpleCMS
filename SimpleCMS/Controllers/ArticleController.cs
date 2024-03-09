using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Data;
using SimpleCMS.Business;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleCMS.Web.Models.ViewModel;
using SimpleCMS.Data.Repositories.Interfaces;
using SimpleCMS.Data.Models;

namespace SimpleCMS.Web.Controllers
{
    public class ArticleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IArticlesRepository _articlesRepository;
        public ArticleController(ApplicationDbContext context, IArticlesRepository articlesRepository)
        {
            _context = context;
            _articlesRepository = articlesRepository;
        }
        public IActionResult Index()
        {
            var articles = _context.Articles.ToList();
            return View(articles);
        }

        //public FileResult MyAction(string dir)
        //{
        //    FileResult a;
        //    try
        //    {
        //        a = new FileStreamResult(new FileStream(dir, FileMode.Open), "image/png");
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    return a;
        //}

        public async Task<IActionResult> Details(int id)
        {
            var articles = await _articlesRepository.GetByIdAsync(id);
            var articleViewModel = new ArticleViewModel
            {
                Id = articles.Id,
                Title = articles.Title,
                Content = articles.Content,
            };
           
            return View(articleViewModel);
        }
    }
}
