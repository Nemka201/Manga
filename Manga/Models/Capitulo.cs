using System;
using System.Collections.Generic;

namespace Manga.Models;

public partial class Capitulo
{
    public int Idcapitulo { get; set; }

    public int Idserie { get; set; }

    public string Titulo { get; set; } = null!;

    public DateTime FechaCarga { get; set; }

    public bool Visto { get; set; }

    public string Imagenes { get; set; } = null!;

    public int? Volumen { get; set; }
}
