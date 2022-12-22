using System;
using System.Collections.Generic;

namespace Manga.Models;

public partial class Serie
{
    public int Idserie { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int? Capitulos { get; set; }

    public int? Volumenes { get; set; }

    public string Categoria { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string? Serializacion { get; set; }

    public int Favoritos { get; set; }

    public bool Estado { get; set; }
}
