using EstacionamientoMVC.B.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EstacionamientoMVC.B.Data
{
    public class MiDb_B : IdentityDbContext<IdentityUser<int>, IdentityRole<int>,int>
    {
        public MiDb_B(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Muchos a Muchos M:N
            modelBuilder.Entity<ClienteVehiculo>().HasKey( cv => new {cv.ClienteId, cv.VehiculoId } );

            modelBuilder.Entity<ClienteVehiculo>()
                            .HasOne(cv => cv.Cliente)
                            .WithMany(clt => clt.ClienteVehiculos)
                            .HasForeignKey(cv => cv.ClienteId);

            modelBuilder.Entity<ClienteVehiculo>()
                            .HasOne(cv => cv.Vehiculo)
                            .WithMany(vh => vh.ClientesAutorizados)
                            .HasForeignKey(cv => cv.VehiculoId);
            #endregion

            //modelBuilder.Entity<Persona>().HasKey(p => p.Id);

            modelBuilder.Entity<IdentityUser<int>>().ToTable("Personas");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("PersonasRoles");

            modelBuilder.Entity<Estancia>().Property(e => e.Monto).HasColumnType("decimal(18,2)");

        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<ClienteVehiculo> ClienteVehiculos { get; set; }

        public DbSet<Rol> MisRoles { get; set; }
    }
}
