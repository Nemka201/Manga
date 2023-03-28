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

        public CapitulosController(PaginaSerieContext context)
        {
            _context = context;
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
                _context.Add(capitulo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
                try
                {
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
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",nombreSerie, fileName);

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
