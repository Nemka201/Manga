using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace Manga.Models;

public partial class Serie
{
    public int Idserie { get; set; }
    [Required(ErrorMessage = "El nombre de la serie es obligatorio")]
    [StringLength(50, ErrorMessage = "No puede superar los 50 caracteres")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "La descripción es obligatoria")]
    [StringLength(1000, ErrorMessage = "No puede superar los 1000 caracteres")]
    public string Descripcion { get; set; } = null!;

    public int? Capitulos { get; set; }

    public int? Volumenes { get; set; }

    [Required(ErrorMessage = "La categoría es obligatoria")]
    public string Categoria { get; set; } = null!;

    [Required(ErrorMessage = "El Autor es obligatorio")]
    public string Autor { get; set; } = null!;

    public string? Serializacion { get; set; }

    public int Favoritos { get; set; }

    public bool Estado { get; set; }
    public string? RutaPortada { get; set; } // Ruta de portada que se guarda en la DB
    [NotMapped]
    public IFormFile? Portada { get; set; } // IFormFile para cargar portada
    [NotMapped]
    public string? RutaBanner { get; set; } // Ruta del banner que se guarda en la DB
    [NotMapped]
    public IFormFile? Banner { get; set; } // IFormFile para cargar Banner
    [NotMapped]
    public int Id { get; set; } // ID usuario
    [NotMapped]
    public List<String> CatList { get; set; } = null!; // Lista de categorias
}
