using Microsoft.AspNetCore.Authorization;
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
    public class ArticleController : Controller
    {
        private readonly IArticlesService _articlesService;

        public ArticleController(IArticlesService articlesService)
        {
            _articlesService = articlesService;
        }

        public async Task<IActionResult> Index()
        {
            ArticleViewModel articleViewModel = new ArticleViewModel();
            articleViewModel.Articles = (await _articlesService.GetArticlesAsync()).ToList();

            return View(articleViewModel);
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
        public async Task<IActionResult> Create(Article article)
        {
            
            if (ModelState.IsValid)
            {
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                article.CreatedById = userId;
                await _articlesService.AddArticle(article);
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var article = await _articlesService.FindAsync(id);
            
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }
      
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _articlesService.UpdateArticle(article);
                
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var article = await _articlesService.FindAsync(id);
            if (id <= 0)
            {
                return NotFound();
            }

            return View(article);
        }
        
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var article = await _articlesService.GetArticleByIdAsync(id);
            if (article != null)
            {
                await _articlesService.DeleteAsync(article);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
