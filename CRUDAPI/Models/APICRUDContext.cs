using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUDAPI.Models
{
    public partial class APICRUDContext : DbContext
    {
        public APICRUDContext()
        {
        }

        public APICRUDContext(DbContextOptions<APICRUDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacion> Calificacions { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasKey(e => e.IdCalificacion)
                    .HasName("PK__Califica__40E4A7518AE547B7");

                entity.ToTable("Calificacion");

                entity.Property(e => e.Calificacion1).HasColumnName("Calificacion");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Curso__085F27D680074CE9");

                entity.ToTable("Curso");

                entity.Property(e => e.Curso1).HasColumnName("Curso");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.Property(e => e.Apellido)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.oIdCalificacion)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdCalificacion)
                    .HasConstraintName("FK_IDCALIFICACION");

                entity.HasOne(d => d.oIdCurso)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK_IdCurso");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
