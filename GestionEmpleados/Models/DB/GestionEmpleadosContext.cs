using Microsoft.EntityFrameworkCore;

namespace GestionEmpleados.Models.DB
{
    public partial class GestionEmpleadosContext : DbContext
    {
        public GestionEmpleadosContext(DbContextOptions<GestionEmpleadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EmpleadoProyecto> EmpleadoProyectos { get; set; }
        public virtual DbSet<HistorialPosicione> HistorialPosiciones { get; set; }
        public virtual DbSet<Proyecto> Proyectos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Departamentos");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Nombre).HasMaxLength(100);
                entity.Property(e => e.Ubicacion).HasMaxLength(100);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Empleados");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Nombre).HasMaxLength(100);
                entity.Property(e => e.PosicionActual).HasMaxLength(100);
                entity.Property(e => e.Salario).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK_Empleados_Departamentos");
            });

            modelBuilder.Entity<EmpleadoProyecto>(entity =>
            {
                entity.HasKey(e => new { e.IdEmpleado, e.IdProyecto }).HasName("PK_EmpleadoProyectos");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.EmpleadoProyectos)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmpleadoProyectos_Empleados");

                entity.HasOne(d => d.IdProyectoNavigation)
                    .WithMany(p => p.EmpleadoProyectos)
                    .HasForeignKey(d => d.IdProyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmpleadoProyectos_Proyectos");
            });

            modelBuilder.Entity<HistorialPosicione>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_HistorialPosiciones");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Posicion).HasMaxLength(100);

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.HistorialPosiciones)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK_HistorialPosiciones_Empleados");
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Proyectos");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Descripcion).HasColumnType("text");
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
