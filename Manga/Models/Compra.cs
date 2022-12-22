using System;
using System.Collections.Generic;

namespace Manga.Models;

public partial class Compra
{
    public int Idcompra { get; set; }

    public int Unidades { get; set; }

    public double Total { get; set; }

    public int Iduser { get; set; }

    public int Volumen { get; set; }
}
