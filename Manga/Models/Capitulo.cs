using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit.Sdk;

namespace Manga.Models;

public partial class Capitulo
{

    public int Idcapitulo { get; set; }

    public int Idserie { get; set; }

    [Required(ErrorMessage = "El titulo del capitulo es obligatorio")]
    [StringLength(30, ErrorMessage = "No puede superar 30 caracteres")]
    public string Titulo { get; set; } = null!;
    public DateTime FechaCarga { get; set; }
    public string? Imagenes { get; set; }
    public bool? Visto { get; set; }

    public int? Volumen { get; set; }
    [Required(ErrorMessage = "El número del capitulo es Obligatorio")]
    public int NumeroCapitulo { get; set; }
    [NotMapped]
    public string[]? files { get; set; } 
}
