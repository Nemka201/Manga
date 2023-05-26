using Manga.Attributes;
using Manga.Models.Context;
using Manga.Models.DTO;
using Manga.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Manga.Controllers
{
    public class SeriesController : Controller
    {
        private readonly PaginaContext _context;
        private readonly IWebHostEnvironment _webhost; // Obtener wwwroot

        public SeriesController(PaginaContext context, IWebHostEnvironment webhost)
        {
            _context = context;
            _webhost = webhost;
        }

        // GET: Series
        public async Task<IActionResult> Index()
        {
            return View(await _context.Series.ToListAsync());
        }

        // GET: Series/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Series == null)
            {
                return NotFound();
            }

            var serie = await _context.Series
                .FirstOrDefaultAsync(m => m.Idserie == id);
            var capList = _context.Capitulos.Where(e => e.Idserie == serie.Idserie).ToList();
            var catList = _context.Categorias.ToList();
            SeriesDTO seriesDetail = new(serie, capList, catList);

            if (serie == null)
            {
                return NotFound();
            }
            ViewBag.BackgroundImage = "../../../media/serie/" + (serie.RutaBanner ?? serie.RutaPortada);
            return View(seriesDetail);
        }

        // GET: Series/Create
        [SessionCheck]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idserie,Nombre,Descripcion,Capitulos,Volumenes,Categoria,Autor,Serializacion,Favoritos,Estado,IdUser,RutaBanner,RutaPortada")] Serie serie)
        {

            if (ModelState.IsValid)
            {
                if (serie.Portada != null)
                {
                    if (ImageValidator(serie))
                    {
                        ModelState.AddModelError("Foto", "El archivo que su subiste no es png o jpg");
                        return View(serie);
                    }
                    serie = SetRutaImagen(serie);
                }
                serie = SerieDefaultValues(serie);
                _context.Add(serie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serie);
        }

        // GET: Series/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Series == null)
            {
                return NotFound();
            }

            var serie = await _context.Series.FindAsync(id);
            if (serie == null)
            {
                return NotFound();
            }
            return View(serie);
        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idserie,Nombre,Descripcion,Capitulos,Volumenes,Categoria,Autor,Serializacion,Favoritos,Estado")] Serie serie)
        {
            if (id != serie.Idserie)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SerieExists(serie.Idserie))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(serie);
        }

        // GET: Series/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Series == null)
            {
                return NotFound();
            }

            var serie = await _context.Series
                .FirstOrDefaultAsync(m => m.Idserie == id);
            if (serie == null)
            {
                return NotFound();
            }

            return View(serie);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Series == null)
            {
                return Problem("Entity set 'PaginaSerieContext.Series'  is null.");
            }
            var serie = await _context.Series.FindAsync(id);
            if (serie != null)
            {
                _context.Series.Remove(serie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Métodos
        /// </summary>

        private bool SerieExists(int id)
        {
            return _context.Series.Any(e => e.Idserie == id);
        }
        private Serie SetRutaImagen(Serie serie)
        {
            serie.RutaPortada = GuidImagen(serie.Portada);
            serie.RutaBanner = GuidImagen(serie.Banner);
            return serie;
        }
        private string GuidImagen(IFormFile image)
        {
            string guidImagen = null;
            string ficherosImagenes = Path.Combine(path1: _webhost.WebRootPath, path2: "media/serie");
            guidImagen = Guid.NewGuid().ToString() + image.FileName;
            string rutaDefinitiva = Path.Combine(path1: ficherosImagenes, path2: guidImagen);
            image.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));
            return guidImagen;
        }
        private bool ImageValidator(Serie serie)
        {
            return !(serie.Portada.FileName.Contains("jpg")
                  || serie.Portada.FileName.Contains("png")
                  || serie.Portada.FileName.Contains("jpeg")
                  || serie.Banner.FileName.Contains("jpg")
                  || serie.Banner.FileName.Contains("png")
                  || serie.Banner.FileName.Contains("jpeg"));
        }
        private Serie SerieDefaultValues(Serie serie)
        {
            serie.Capitulos = 0;
            serie.Volumenes = 0;
            serie.Estado = true;
            serie.Favoritos = 0;
            serie.IdUser = (int)HttpContext.Session.GetInt32("id");
            return serie;
        }
    }
}
