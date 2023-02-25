using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace Manga.Models;

public partial class Capitulo
{
    public int Idcapitulo { get; set; }

    public int Idserie { get; set; }

    [Required(ErrorMessage = "Obligatorio")]
    [StringLength(30, ErrorMessage = "No puede superar 30 caracteres")]
    public string Titulo { get; set; } = null!;
    [Required(ErrorMessage = "Obligatorio")]
    public DateTime FechaCarga { get; set; }

    public bool Visto { get; set; }
    [Required(ErrorMessage = "Obligatorio")]
    public string Imagenes { get; set; } = null!;

    public int? Volumen { get; set; }
}
