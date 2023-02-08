using Manga.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Manga.Attributes;
namespace Manga.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PaginaSerieContext _context;

        public HomeController(ILogger<HomeController> logger, PaginaSerieContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            
            return View(_context);
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