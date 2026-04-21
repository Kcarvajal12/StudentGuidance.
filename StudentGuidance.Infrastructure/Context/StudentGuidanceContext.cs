using Microsoft.EntityFrameworkCore;
using StudentGuidance.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StudentGuidance.Infrastructure.Context;

public class StudentGuidanceContext : DbContext
{
    public StudentGuidanceContext(DbContextOptions<StudentGuidanceContext> options) : base(options)
    {
    }

    public DbSet<Estudiante> Estudiantes => Set<Estudiante>();
    public DbSet<Orientador> Orientadores => Set<Orientador>();
    public DbSet<Cita> Citas => Set<Cita>();
    public DbSet<Seguimiento> Seguimientos => Set<Seguimiento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.ToTable("Estudiantes");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Apellido).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Correo).HasMaxLength(150).IsRequired();
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.Matricula).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Carrera).HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<Orientador>(entity =>
        {
            entity.ToTable("Orientadores");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Apellido).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Correo).HasMaxLength(150).IsRequired();
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.CodigoEmpleado).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Especialidad).HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.ToTable("Citas");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Motivo).HasMaxLength(250).IsRequired();

            entity.HasOne(e => e.Estudiante)
                  .WithMany(e => e.Citas)
                  .HasForeignKey(e => e.EstudianteId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Orientador)
                  .WithMany(e => e.Citas)
                  .HasForeignKey(e => e.OrientadorId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Seguimiento>(entity =>
        {
            entity.ToTable("Seguimientos");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Observaciones).HasMaxLength(500).IsRequired();
            entity.Property(e => e.Recomendaciones).HasMaxLength(500).IsRequired();

            entity.HasOne(e => e.Cita)
                  .WithMany(e => e.Seguimientos)
                  .HasForeignKey(e => e.CitaId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}