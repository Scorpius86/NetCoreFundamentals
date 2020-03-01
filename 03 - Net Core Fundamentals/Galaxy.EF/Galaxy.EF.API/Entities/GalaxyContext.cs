using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Galaxy.EF.API.Entities
{
    public partial class GalaxyContext : DbContext
    {
        public GalaxyContext()
        {
        }

        public GalaxyContext(DbContextOptions<GalaxyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comentario> Comentarios { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.ToTable("Comentario");

                entity.Property(e => e.Contenido).IsUnicode(false);

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComentarioPost");

                entity.HasOne(d => d.UsuarioIdActualizacionNavigation)
                    .WithMany(p => p.ComentarioUsuarioIdActualizacionNavigations)
                    .HasForeignKey(d => d.UsuarioIdActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComentarioUsuarioActualizacion");

                entity.HasOne(d => d.UsuarioIdCreacionNavigation)
                    .WithMany(p => p.ComentarioUsuarioIdCreacionNavigations)
                    .HasForeignKey(d => d.UsuarioIdCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComentarioUsuarioCreacion");

                entity.HasOne(d => d.UsuarioIdPropietarioNavigation)
                    .WithMany(p => p.ComentarioUsuarioIdPropietarioNavigations)
                    .HasForeignKey(d => d.UsuarioIdPropietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComentarioUsuarioPropietario");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Contenido).IsUnicode(false);

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsuarioIdActualizacionNavigation)
                    .WithMany(p => p.PostUsuarioIdActualizacionNavigations)
                    .HasForeignKey(d => d.UsuarioIdActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostUsuarioActualizacion");

                entity.HasOne(d => d.UsuarioIdCreacionNavigation)
                    .WithMany(p => p.PostUsuarioIdCreacionNavigations)
                    .HasForeignKey(d => d.UsuarioIdCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostUsuarioCreacion");

                entity.HasOne(d => d.UsuarioIdPropietarioNavigation)
                    .WithMany(p => p.PostUsuarioIdPropietarioNavigations)
                    .HasForeignKey(d => d.UsuarioIdPropietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostUsuarioPropietario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}