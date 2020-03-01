using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Galaxy.EF.Client.Models
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

        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-VA7V47E;Initial Catalog=Galaxy;Persist Security Info=True;User ID=sa; Password=Password123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.Property(e => e.Contenido).IsUnicode(false);

                entity.Property(e => e.FechaActualizacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComentarioPost");

                entity.HasOne(d => d.UsuarioIdActualizacionNavigation)
                    .WithMany(p => p.ComentarioUsuarioIdActualizacionNavigation)
                    .HasForeignKey(d => d.UsuarioIdActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComentarioUsuarioActualizacion");

                entity.HasOne(d => d.UsuarioIdCreacionNavigation)
                    .WithMany(p => p.ComentarioUsuarioIdCreacionNavigation)
                    .HasForeignKey(d => d.UsuarioIdCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComentarioUsuarioCreacion");

                entity.HasOne(d => d.UsuarioIdPropietarioNavigation)
                    .WithMany(p => p.ComentarioUsuarioIdPropietarioNavigation)
                    .HasForeignKey(d => d.UsuarioIdPropietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ComentarioUsuarioPropietario");
            });

            modelBuilder.Entity<Post>(entity =>
            {
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
                    .WithMany(p => p.PostUsuarioIdActualizacionNavigation)
                    .HasForeignKey(d => d.UsuarioIdActualizacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostUsuarioActualizacion");

                entity.HasOne(d => d.UsuarioIdCreacionNavigation)
                    .WithMany(p => p.PostUsuarioIdCreacionNavigation)
                    .HasForeignKey(d => d.UsuarioIdCreacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostUsuarioCreacion");

                entity.HasOne(d => d.UsuarioIdPropietarioNavigation)
                    .WithMany(p => p.PostUsuarioIdPropietarioNavigation)
                    .HasForeignKey(d => d.UsuarioIdPropietario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostUsuarioPropietario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
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
        }
    }
}
