 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Manga.Models;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Http;
using Manga.Attributes;

namespace Manga.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly long _fileSizeLimit = 5 * 1024 * 1024; // 5MB
        private readonly PaginaContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _webhost; // Obtener wwwroot
        public UsuariosController(PaginaContext context, IWebHostEnvironment webhost, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _webhost = webhost;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }
        // GET: Login
        public IActionResult Login()
        {
            return View();
        }
        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                return RedirectToAction("Login", "Usuarios");
            }
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUser,Email,Usuario1,Clave,cClave,Nombre,Apellido,Foto,Favoritos,Carrito,RutaPortada")] Usuario usuario)
        {
            if (ModelState.IsValid && usuario.Clave == usuario.cClave) //Valida que las contraseñas sean iguales
            {
                if (!UserOrEmailExists(usuario.Usuario1, usuario.Email))
                {
                    if (usuario.Foto != null)
                    {
                        // ############### Modificancion Isaias #########
                        if (!(usuario.Foto.FileName.Contains("jpg") || usuario.Foto.FileName.Contains("png") || usuario.Foto.FileName.Contains("jpeg")))
                        {
                            ModelState.AddModelError("Foto", "El archivo que su subiste no es png o jpg");
                            return View(usuario);
                        } // ############### Modificancion Isaias #########
                        GetRutaFoto(usuario);
                    }
                    usuario.Clave = ConvertSha256(usuario.Clave); // Encripta password
                    _context.Add(usuario);
                    SetSession(usuario);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("Usuario1", "El correo electronico o usuario esta en uso");
                return View(usuario);
            }
            ModelState.AddModelError("cClave", "Las contraseñas no coinciden"); // Mensaje para la vista
            return View(usuario);
        }

        // POST: Usuarios/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Usuario1,Clave")] Usuario usuario)
        {
            if (LoginValidate(usuario.Usuario1, usuario.Clave))
            {
                usuario = (Usuario)_context.Usuarios.Where(d => d.Usuario1 == usuario.Usuario1).First();
                SetSession(usuario);
                return RedirectToAction(nameof(Index), "Home");
            }
            else
            {
                ViewData["Message"] = "Usuario no encontrado";
                return View(usuario);
            }
        }
        public IActionResult Logout()
        {   // ELIMINO DATOS DEL SESSION
            _httpContextAccessor.HttpContext.Session.Remove("username");
            _httpContextAccessor.HttpContext.Session.Remove("rutaFoto");
            _httpContextAccessor.HttpContext.Session.Remove("id");
            _httpContextAccessor.HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index), "Home");
        }
        //GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public async Task<IActionResult> Edit(int id, [Bind("IdUser,Email,Usuario1,Clave,cClave,Nombre,Apellido,Favoritos,Carrito,RutaPortada")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid && usuario.Clave == usuario.cClave)
            {
                try
                {
                    if (usuario.Foto != null)
                    {
                        // ############### Modificancion Isaias #########
                        if (!(usuario.Foto.FileName.Contains("jpg") || usuario.Foto.FileName.Contains("png") || usuario.Foto.FileName.Contains("jpeg")))
                        {
                            ModelState.AddModelError("Foto", "El archivo que su subiste no es png o jpg");
                            return View(usuario);
                        } // ############### Modificancion Isaias #########
                        GetRutaFoto(usuario);
                    }
                    usuario.Clave = ConvertSha256(usuario.Clave);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            else
            {
                ModelState.AddModelError("cClave", "Las contraseñas no coinciden");
            }

            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'PaginaContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Metodos
        /// </summary>

        private bool UsuarioExists(int id) // Verify if users exist with id
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
        static string ConvertSha256(string rawData) // SHA256 ENCRYPTER
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private bool UserOrEmailExists(string user, string email) // Verify if users exist with User or Email
        {
            return _context.Usuarios.Any(e => e.Usuario1 == user || e.Email == email);
        }
        private bool LoginValidate(string userOrEmail, string password) // Comprueba contraseña del usuario
        {
            Usuario u = null;
            if (!string.IsNullOrEmpty(userOrEmail))
            {
                if (_context.Usuarios.Any(e => e.Usuario1 == userOrEmail))
                {
                    u = _context.Usuarios.Where(e => e.Usuario1 == userOrEmail).First(); // Si encuentra el usuario en la DB
                }
                if (_context.Usuarios.Any(e => e.Email == userOrEmail))
                {
                    u = _context.Usuarios.Where(e => e.Email == userOrEmail).First(); // Si encuentra el email en la DB
                }
                return (u.Clave == ConvertSha256(password));
            }
            return false;
        }
        private void GetRutaFoto(Usuario usuario)
        {
            string guidImagen = null;
            string ficherosImagenes = Path.Combine(path1: _webhost.WebRootPath, path2: "media/perfil");
            guidImagen = Guid.NewGuid().ToString() + usuario.Foto.FileName;
            string rutaDefinitiva = Path.Combine(path1: ficherosImagenes, path2: guidImagen);
            usuario.Foto.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));
            usuario.RutaFoto = guidImagen;
        }
        private void SetSession(Usuario usuario)
        {
            _httpContextAccessor.HttpContext.Session.SetString("username", usuario.Usuario1);
            _httpContextAccessor.HttpContext.Session.SetString("rutaFoto", usuario.RutaFoto);
            _httpContextAccessor.HttpContext.Session.SetInt32("id", usuario.Id);
        }
    }
}
