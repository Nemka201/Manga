using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Manga.Models;

public partial class PaginaContext : DbContext
{
    public PaginaContext()
    {
    }

    public PaginaContext(DbContextOptions<PaginaContext> options) : base(options)
    {
    }

    public virtual DbSet<Capitulo> Capitulos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    public virtual DbSet<Serie> Series { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Volumene> Volumenes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Capitulo>(entity =>
        {
            entity.HasKey(e => e.Idcapitulo);

            entity.Property(e => e.Idcapitulo).HasColumnName("IDcapitulo");
            entity.Property(e => e.FechaCarga)
                .HasColumnType("date")
                .HasColumnName("fechaCarga");
            entity.Property(e => e.Idserie).HasColumnName("IDserie");
            entity.Property(e => e.Imagenes)
                .IsUnicode(false)
                .HasColumnName("imagenes");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("titulo");
            entity.Property(e => e.Visto).HasColumnName("visto");
            entity.Property(e => e.Volumen).HasColumnName("volumen");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategoria);

            entity.Property(e => e.Idcategoria).HasColumnName("IDcategoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1500)
                .IsFixedLength()
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Idcompra);

            entity.ToTable("Compra");

            entity.Property(e => e.Idcompra).HasColumnName("IDcompra");
            entity.Property(e => e.Iduser).HasColumnName("IDuser");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.Unidades).HasColumnName("unidades");
            entity.Property(e => e.Volumen).HasColumnName("volumen");
        });

        modelBuilder.Entity<Imagene>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idcap).HasColumnName("IDcap");
            entity.Property(e => e.Imagen)
                .HasColumnType("image")
                .HasColumnName("imagen");
        });

        modelBuilder.Entity<Serie>(entity =>
        {
            entity.HasKey(e => e.Idserie);

            entity.ToTable("Serie");

            entity.Property(e => e.Idserie).HasColumnName("IDSerie");
            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("autor");
            entity.Property(e => e.Capitulos).HasColumnName("capitulos");
            entity.Property(e => e.Categoria)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Favoritos).HasColumnName("favoritos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Serializacion)
                .HasMaxLength(100)
                .IsFixedLength()
                .HasColumnName("serializacion");
            entity.Property(e => e.Volumenes).HasColumnName("volumenes");
        });

        modelBuilder.Entity<Usuario>((Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Usuario>>)(entity =>
        {
            entity.ToTable<Usuario>("Usuario");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property<string>(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName<string>("apellido");
            entity.Property<string>(e => e.Carrito)
                .IsUnicode(false)
                .HasColumnName<string>("carrito");
            entity.Property<string>(e => e.Clave)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName<string>("clave");
            entity.Property<string>(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName<string>("email");
            entity.Property<string>(e => e.Favoritos)
                .IsUnicode(false)
                .HasColumnName<string>("favoritos");
            entity.Property<IFormFile>(e => (IFormFile)e.ImgPerfil).HasColumnType<IFormFile>("image");
            entity.Property<string>(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName<string>("nombre");
            entity.Property<string>(e => e.Usuario1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName<string>("usuario");
        }));

        modelBuilder.Entity<Volumene>(entity =>
        {
            entity.HasKey(e => e.Idvol);

            entity.Property(e => e.Idvol).HasColumnName("IDvol");
            entity.Property(e => e.Imagen)
                .HasColumnType("image")
                .HasColumnName("imagen");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
