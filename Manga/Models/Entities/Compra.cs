using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Manga.Models.Entities;

public partial class Compra
{
    [Key]
    public int Idcompra { get; set; }

    public int Unidades { get; set; }

    public double Total { get; set; }

    [ForeignKey("Usuario")]
    public int Iduser { get; set; }

    public int Volumen { get; set; }
}
