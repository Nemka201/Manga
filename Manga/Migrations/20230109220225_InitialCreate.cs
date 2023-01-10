using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Manga.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Capitulos",
                columns: table => new
                {
                    IDcapitulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDserie = table.Column<int>(type: "int", nullable: false),
                    titulo = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    fechaCarga = table.Column<DateTime>(type: "date", nullable: false),
                    visto = table.Column<bool>(type: "bit", nullable: false),
                    imagenes = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    volumen = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitulos", x => x.IDcapitulo);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IDcategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nchar(1500)", fixedLength: true, maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IDcategoria);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    IDcompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unidades = table.Column<int>(type: "int", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    IDuser = table.Column<int>(type: "int", nullable: false),
                    volumen = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compra", x => x.IDcompra);
                });

            migrationBuilder.CreateTable(
                name: "Imagenes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDcap = table.Column<int>(type: "int", nullable: false),
                    imagen = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagenes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    IDSerie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    capitulos = table.Column<int>(type: "int", nullable: true),
                    volumenes = table.Column<int>(type: "int", nullable: true),
                    categoria = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    autor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    serializacion = table.Column<string>(type: "nchar(100)", fixedLength: true, maxLength: 100, nullable: true),
                    favoritos = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.IDSerie);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    usuario = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    clave = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    favoritos = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    carrito = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    rutaFoto = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Volumenes",
                columns: table => new
                {
                    IDvol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<double>(type: "float", nullable: true),
                    stock = table.Column<int>(type: "int", nullable: true),
                    imagen = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volumenes", x => x.IDvol);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capitulos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Imagenes");

            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Volumenes");
        }
    }
}
