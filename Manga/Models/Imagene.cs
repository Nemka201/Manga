using System;
using System.Collections.Generic;

namespace Manga.Models;

public partial class Imagene
{
    public int Id { get; set; }

    public int Idcap { get; set; }

    public byte[] Imagen { get; set; } = null!;
}
