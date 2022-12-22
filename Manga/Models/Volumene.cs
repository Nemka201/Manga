using System;
using System.Collections.Generic;

namespace Manga.Models;

public partial class Volumene
{
    public int Idvol { get; set; }

    public double? Precio { get; set; }

    public int? Stock { get; set; }

    public byte[] Imagen { get; set; } = null!;
}
