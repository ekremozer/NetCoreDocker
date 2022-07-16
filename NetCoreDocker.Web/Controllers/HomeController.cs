using Microsoft.AspNetCore.Mvc;
using NetCoreDocker.Web.Models;
using System.Diagnostics;
using Microsoft.Extensions.FileProviders;
using NetCoreDocker.Utility;

namespace NetCoreDocker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFileProvider _fileProvider;

        public HomeController(ILogger<HomeController> logger, IFileProvider fileProvider)
        {
            _logger = logger;
            _fileProvider = fileProvider;
        }

        public IActionResult Index()
        {
            var images = _fileProvider.GetDirectoryContents("wwwroot/images").Select(x => x.Name).ToList();
            return View(images);
        }

        [HttpPost]
        public IActionResult Index(IFormFile image)
        {
            if (image is { Length: > 0 })
            {
                //var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                var fileName = StringHelper.GetRandomFileName(image.FileName);

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                image.CopyTo(stream);
            }
            return RedirectToAction("Index");
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