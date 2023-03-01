using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manga.Models;

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
            if (serie == null)
            {
                return NotFound();
            }
            ViewBag.BackgroundImage = "../../../media/serie/" + serie.RutaFoto;
            return View(serie);
        }

        // GET: Series/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idserie,Nombre,Descripcion,Capitulos,Volumenes,Categoria,Autor,Serializacion,Favoritos,Estado,RutaFoto,Id")] Serie serie)
        {
            if (ModelState.IsValid)
            {
                if (serie.Portada != null)
                {
                    if (!(serie.Portada.FileName.Contains("jpg") || serie.Portada.FileName.Contains("png") || serie.Portada.FileName.Contains("jpeg")))
                    {
                        ModelState.AddModelError("Foto", "El archivo que su subiste no es png o jpg");
                        return View(serie);
                    }
                    GetRutaFoto(serie);
                }
                serie.Capitulos = 0;
                serie.Volumenes = 0;
                serie.Categoria = "4";
                serie.Estado = true;
                serie.Id = (int)HttpContext.Session.GetInt32("id");
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
                return Problem("Entity set 'PaginaContext.Series'  is null.");
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
        private void GetRutaFoto(Serie serie)
        {
            string guidImagen = null;
            string ficherosImagenes = Path.Combine(path1: _webhost.WebRootPath, path2: "media/serie");
            guidImagen = Guid.NewGuid().ToString() + serie.Portada.FileName;
            string rutaDefinitiva = Path.Combine(path1: ficherosImagenes, path2: guidImagen);
            serie.Portada.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));
            serie.RutaFoto = guidImagen;
        }
    }
}
