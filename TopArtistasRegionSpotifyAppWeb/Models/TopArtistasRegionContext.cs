using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TopArtistasRegionSpotifyAppWeb.Models;

public partial class TopArtistasRegionContext : DbContext
{
    public TopArtistasRegionContext()
    {
    }

    public TopArtistasRegionContext(DbContextOptions<TopArtistasRegionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artista> Artistas { get; set; }

    public virtual DbSet<Artistum> Artista { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VwTopArtista> VwTopArtistas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artista>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Pais).HasMaxLength(255);
        });

        modelBuilder.Entity<Artistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ARTISTA__3214EC074A5184FF");

            entity.ToTable("ARTISTA");

            entity.HasIndex(e => e.Id, "IX_Artista");

            entity.Property(e => e.Estatus).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCrea)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Opais).WithMany(p => p.Artista)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK_ArtistaPais");

            entity.HasOne(d => d.OUsuarioCrea).WithMany(p => p.ArtistumIdUsuarioCreaNavigations)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .HasConstraintName("FK_ArtistauarioCrea");

            entity.HasOne(d => d.OUsuarioModifica).WithMany(p => p.ArtistumIdUsuarioModificaNavigations)
                .HasForeignKey(d => d.IdUsuarioModifica)
                .HasConstraintName("FK_ArtistaUsuarioModifica");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PAIS__3214EC0771E57BAB");

            entity.ToTable("PAIS");

            entity.HasIndex(e => e.Id, "IX_Pais");

            entity.Property(e => e.Estatus).HasDefaultValueSql("((1))");
            entity.Property(e => e.FechaCrea)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModifica).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdUsuarioCreaNavigation).WithMany(p => p.PaiIdUsuarioCreaNavigations)
                .HasForeignKey(d => d.IdUsuarioCrea)
                .HasConstraintName("FK_PaisuarioCrea");

            entity.HasOne(d => d.IdUsuarioModificaNavigation).WithMany(p => p.PaiIdUsuarioModificaNavigations)
                .HasForeignKey(d => d.IdUsuarioModifica)
                .HasConstraintName("FK_PaisUsuarioModifica");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC073D9712A1");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Id, "IX_Usuario");

            entity.Property(e => e.Estatus).HasDefaultValueSql("((1))");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<VwTopArtista>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_Top_Artistas");

            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Pais).HasMaxLength(100);
            entity.Property(e => e.TopArtist).HasColumnName("Top Artist");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
