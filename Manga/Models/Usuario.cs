using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Manga.Models;

public partial class Usuario
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Obligatorio")]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Obligatorio")]

    public string Usuario1 { get; set; } = null!;
    [Required(ErrorMessage = "Obligatorio")]
    public string Clave { get; set; } = null!;  

    [Required(ErrorMessage = "Obligatorio")]

    [StringLength(50, ErrorMessage = "No puede superar 50 caracteres")]
    public string? Nombre { get; set; }

    [StringLength(20, ErrorMessage = "No puede superar 20 caracteres")]
    public string? Apellido { get; set; }

    //[Required(ErrorMessage = "Obligatorio")] // ############### Modificancion Isaias #########
    public string? Favoritos { get; set; }
    public string? Carrito { get; set; }
    public string? RutaFoto { get; set; }

    [NotMapped]
    public IFormFile? Foto { get; set; }
    [NotMapped]
    public string cClave { get; set; } = null!; // Confirmacion Contraseña
}

