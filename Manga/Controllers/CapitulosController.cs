using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manga.Models;
using System.Net;

namespace Manga.Controllers
{
    public class CapitulosController : Controller
    {
        private readonly PaginaSerieContext _context;
        private readonly IWebHostEnvironment _webhost; // Obtener wwwroot


        public CapitulosController(PaginaSerieContext context, IWebHostEnvironment webhost)
        {
            _context = context;
            _webhost = webhost;
        }

        // GET: Capitulos
        public async Task<IActionResult> Index()
        {
              return View(await _context.Capitulos.ToListAsync());
        }

        // GET: Capitulos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Capitulos == null)
            {
                return NotFound();
            }

            var capitulo = await _context.Capitulos
                .FirstOrDefaultAsync(m => m.Idcapitulo == id);
            if (capitulo == null)
            {
                return NotFound();
            }

            return View(capitulo);
        }

        // GET: Capitulos/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Capitulos/View
        public async Task<IActionResult> Chapter(int? id)
        {
            if (id == null || _context.Capitulos == null)
            {
                return NotFound();
            }

            Capitulo capitulo = await _context.Capitulos
                .FirstOrDefaultAsync(m => m.Idcapitulo == id);
            Serie serie = _context.Series.Where(s => s.Idserie == capitulo.Idserie).First();
            string uploadsFolder = Path.Combine(path1: _webhost.WebRootPath, path2: $"media/capitulos/{serie.Nombre}/{capitulo.NumeroCapitulo}");
            capitulo.files = Directory.GetFiles(uploadsFolder);

            if (capitulo == null)
            {
                return NotFound();
            }

            return View(capitulo);
        }



        // POST: Capitulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idcapitulo,Idserie,Titulo,FechaCarga,Visto,Imagenes,Volumen")] Capitulo capitulo)
        {
            if (ModelState.IsValid)
            {
                capitulo.FechaCarga = DateTime.Now;
                capitulo.NumeroCapitulo = 0;
                _context.Add(capitulo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", new { id = capitulo.Idcapitulo });
            }
            return View(capitulo);
        }

        // GET: Capitulos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Capitulos == null)
            {
                return NotFound();
            }

            var capitulo = await _context.Capitulos.FindAsync(id);
            if (capitulo == null)
            {
                return NotFound();
            }
            return View(capitulo);
        }

        // POST: Capitulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idcapitulo,Idserie,Titulo,FechaCarga,Visto,Imagenes,Volumen")] Capitulo capitulo)
        {
            if (id != capitulo.Idcapitulo)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                string nombreSerie = HttpContext.Session.GetString("nombreSerie");
                string capituloSerie = HttpContext.Session.GetString("capituloSerie");
                string uploadsFolder = Path.Combine(path1: _webhost.WebRootPath, path2: $"media/capitulos/{nombreSerie}/{capituloSerie}");
                ViewBag.urlFolder = uploadsFolder;
                try
                {
                    foreach(string archivoPath in Directory.GetFiles(uploadsFolder))
                    {
                        capitulo.NumeroCapitulo++;
                    }
                    _context.Update(capitulo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapituloExists(capitulo.Idcapitulo))
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
            return View(capitulo);
        }

        // GET: Capitulos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Capitulos == null)
            {
                return NotFound();
            }

            var capitulo = await _context.Capitulos
                .FirstOrDefaultAsync(m => m.Idcapitulo == id);
            if (capitulo == null)
            {
                return NotFound();
            }

            return View(capitulo);
        }

        // POST: Capitulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Capitulos == null)
            {
                return Problem("Entity set 'PaginaSerieContext.Capitulos'  is null.");
            }
            var capitulo = await _context.Capitulos.FindAsync(id);
            if (capitulo != null)
            {
                _context.Capitulos.Remove(capitulo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> UploadFiles()
        {

            var files = Request.Form.Files;
            string nombreSerie = HttpContext.Session.GetString("nombreSerie");
            string capituloSerie = HttpContext.Session.GetString("capituloSerie");
            string uploadsFolder = Path.Combine(path1: _webhost.WebRootPath, path2: $"media/capitulos/{nombreSerie}");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
                uploadsFolder = Path.Combine(path1:uploadsFolder, path2:capituloSerie);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
            }
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(path1:uploadsFolder,path2:fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            HttpContext.Session.SetInt32("fileUpload", 1);
            return Ok();
        }
        private bool CapituloExists(int id)
        {
          return _context.Capitulos.Any(e => e.Idcapitulo == id);
        }
    }
}
