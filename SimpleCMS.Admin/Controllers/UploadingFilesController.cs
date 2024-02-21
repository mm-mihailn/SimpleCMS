using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCMS.Admin.Models.ViewModel;
using SimpleCMS.Business.Services.Interfaces;
using SimpleCMS.Data.Models;
using System.Security.Claims;

namespace SimpleCMS.Admin.Controllers
{
    [Authorize]
    public class UploadingFilesController : Controller
    {
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHost;

        public UploadingFilesController(IWebHostEnvironment webHost,
            IFileService fileService)
        {
            _webHost = webHost;
            _fileService = fileService;
        }

        public async Task<IActionResult> Index()
        {
            FileViewModel viewModel = new FileViewModel();
            viewModel.Files = (await _fileService.GetFilesAsync()).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file, string category)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file provided. You must provide a file first before proceeding");
            }

            string uploadsFolder = Path.Combine(_webHost.WebRootPath, "Uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileName = Path.GetFileName(file.FileName);
            string fileSavePath = "";

            if (!string.IsNullOrEmpty(category))
            {
                if (category == "Documents")
                {
                    string documentsFolderPath = Path.Combine(uploadsFolder, "Documents");

                    if (!Directory.Exists(documentsFolderPath))
                    {
                        Directory.CreateDirectory(documentsFolderPath);
                    }
                    fileSavePath = Path.Combine(documentsFolderPath, fileName);
                }

                else if (category == "Audio")
                {
                    string audioFolderPath = Path.Combine(uploadsFolder, "Media\\Audio");
                    
                    if (!Directory.Exists(audioFolderPath))
                    {
                        Directory.CreateDirectory(audioFolderPath);
                    }
                    fileSavePath = Path.Combine(audioFolderPath, fileName);
                }

                else if (category == "Image")
                {
                    string imageFolderPath = Path.Combine(uploadsFolder, "Media\\Image");
                    
                    if (!Directory.Exists(imageFolderPath))
                    {
                        Directory.CreateDirectory(imageFolderPath);
                    }
                    fileSavePath = Path.Combine(imageFolderPath, fileName);
                }

                else if (category == "Video")
                {
                    string videoFolderPath = Path.Combine(uploadsFolder, "Media\\Video");
                   
                    if (!Directory.Exists(videoFolderPath))
                    {
                        Directory.CreateDirectory(videoFolderPath);
                    }
                    fileSavePath = Path.Combine(videoFolderPath, fileName);
                }

                else if (category == "Other")
                {   
                    string videoFolderPath = Path.Combine(uploadsFolder, "Media\\Other");
                    
                    if (!Directory.Exists(videoFolderPath))
                    {
                        Directory.CreateDirectory(videoFolderPath);
                    }
                    fileSavePath = Path.Combine(videoFolderPath, fileName);
                }
            }

            else
            {
                fileSavePath = Path.Combine(uploadsFolder, fileName);
            }

            using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            Files uploadFile = new Files();

            uploadFile.Path = fileSavePath;
            uploadFile.Name = fileName;
            uploadFile.MimeType = file.ContentType;

            try
            {
                await _fileService.AddFile(uploadFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            ViewBag.Message = file + "Upload successfully";
            return RedirectToAction(nameof(Index));

            //return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var files = await _fileService.FindAsync(id);

            if (files == null)
            {
                return NotFound();
            }

            return View(files);
        }


        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var files = await _fileService.GetFilesByIdAsync(id);
            if (files != null)
            {
                await _fileService.DeleteAsync(files);
            }

            return RedirectToAction(nameof(Index));
        }


    }

}
    

