using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.Admin.Models;
using SimpleCMS.Admin.Models.ViewModel;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using System.Configuration;
using System.Diagnostics;
using System.Security.Claims;

namespace SimpleCMS.Admin.Controllers
{
    //[Authorize]
    public class ArticlesController : Controller
    {
        private readonly IArticlesService _articlesService;
        private readonly IConfiguration _configuration;

        public ArticlesController(IArticlesService articlesService, IConfiguration configuration)
        {
            _articlesService = articlesService;
            _configuration = configuration;
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
        public async Task<IActionResult> Create(Article article, IFormFile image)
        {
            bool isValid = false;
            string[] validExtensions = { ".jpg", ".png", ".jpeg" };
            string uploadsFolder = _configuration.GetValue<string>("AppSettings:UploadsArticleImagesPath");
          
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
                article.Image = "\\UploadsArticleImages\\" + fileName;
                article.CreatedById = userId;
                await _articlesService.AddArticle(article);
                isValid = true;

                return RedirectToAction(nameof(Index));
            }
            else
            {
                isValid = false;
                return View();
            }
           
           
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
