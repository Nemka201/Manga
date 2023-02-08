using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Manga.Models;

public partial class PaginaSerieContext : DbContext
{
    public PaginaSerieContext()
    {
    }

    public PaginaSerieContext(DbContextOptions<PaginaSerieContext> options) : base(options)
    {
    }

    public virtual DbSet<Capitulo> Capitulos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    public virtual DbSet<Serie> Series { get; set; }

    public virtual DbSet<Volumene> Volumenes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("server=B450-R31-2060; database=Pagina; Integrated Security=True; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
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
            entity.Property(e => e.RutaFoto).HasColumnName("portada");

        });

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
