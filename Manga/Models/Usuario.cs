using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Manga.Models;

public partial class Usuario
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Obligatorio")]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "Obligatorio")]

    public string Usuario1 { get; set; } = null!;
<<<<<<< HEAD
    [Required(ErrorMessage = "Obligatorio")]
    public string Clave { get; set; } = null!;  

    [Required(ErrorMessage = "Obligatorio")]
    [NotMapped]
    public string cClave { get; set; } = null!; // Confirmacion Contraseña

=======
    [Required(ErrorMessage ="Obligatorio")]
    public string Clave { get; set; } = null!;

    [Required(ErrorMessage = "Obligatorio")]
    public string cClave { get; set; } = null!; // Confirmacion Contraseña

>>>>>>> 7085b88b0fd6f55351fd7c05c83be11782c6d467
    [StringLength(50, ErrorMessage = "No puede superar 50 caracteres")]
    public string? Nombre { get; set; }

    [StringLength(20, ErrorMessage = "No puede superar 20 caracteres")]
    public string? Apellido { get; set; }

<<<<<<< HEAD
    [NotMapped]
    public IFormFile? Foto { get; set; }
=======
    public IFormFile Foto { get; set; } // Ruta foto de perfil
>>>>>>> 7085b88b0fd6f55351fd7c05c83be11782c6d467

    public string? Favoritos { get; set; }

    public string? Carrito { get; set; }
    public string? RutaFoto { get; set; }
<<<<<<< HEAD
=======

>>>>>>> 7085b88b0fd6f55351fd7c05c83be11782c6d467
}

