using Manga.Models.Context;
using Manga.Models.DTO;
using Manga.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Manga.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PaginaContext _context;

        public HomeController(ILogger<HomeController> logger, PaginaContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            IndexContent content = new IndexContent(_context.Series.ToList(), _context.Capitulos.ToList());

            return View(content);
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