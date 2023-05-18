using System.ComponentModel.DataAnnotations;

namespace Manga.Models.Entities;

public partial class Categoria
{
    [Key]
    public int Idcategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }
}
