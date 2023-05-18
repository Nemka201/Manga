using System.ComponentModel.DataAnnotations;

namespace Manga.Models.Entities;

public partial class Volumene
{
    [Key]
    public int Idvol { get; set; }

    public double? Precio { get; set; }

    public int? Stock { get; set; }

    public byte[] Imagen { get; set; } = null!;
}
