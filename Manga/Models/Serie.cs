using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace Manga.Models;

public partial class Serie
{
    public int Idserie { get; set; }
    [Required(ErrorMessage = "Obligatorio")]
    [StringLength(50, ErrorMessage = "No puede superar los 50 caracteres")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "Obligatorio")]
    [StringLength(1000, ErrorMessage = "No puede superar los 1000 caracteres")]
    public string Descripcion { get; set; } = null!;

    public int? Capitulos { get; set; }

    public int? Volumenes { get; set; }

    [Required(ErrorMessage = "Obligatorio")]
    public string Categoria { get; set; } = null!;

    [Required(ErrorMessage = "Obligatorio")]
    public string Autor { get; set; } = null!;

    public string? Serializacion { get; set; }

    public int Favoritos { get; set; }

    public bool Estado { get; set; }
}
