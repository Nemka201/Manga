using System;
using System.Collections.Generic;
using System.Text;

namespace Manga.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Usuario1 { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public IFormFile ImgPerfil { get; set; }

    public string? Favoritos { get; set; }

    public string? Carrito { get; set; }
    public byte[]? ImgPerfil { get; set; }

}

