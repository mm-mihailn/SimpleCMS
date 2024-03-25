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
        private readonly IConfiguration _configuration;
        public ArticleController(ApplicationDbContext context, IArticlesRepository articlesRepository,
            IConfiguration configuration)
        {
            _context = context;
            _articlesRepository = articlesRepository;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var articles = _context.Articles.ToList();
            return View(articles);
        }

      
        public async Task<IActionResult> Details(int id)
        {
            var articles = await _articlesRepository.GetByIdAsync(id);
            var articleViewModel = new ArticleViewModel
            {
                Id = articles.Id,
                Title = articles.Title,
                SubTitle = articles.SubTitle,
                Content = articles.Content,
                Image = articles.Image

            };
           
            return View(articleViewModel);
        }
    }
}
