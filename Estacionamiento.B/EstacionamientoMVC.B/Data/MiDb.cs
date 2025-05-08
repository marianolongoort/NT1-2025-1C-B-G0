using EstacionamientoMVC.B.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EstacionamientoMVC.B.Data
{
    public class MiDb : DbContext
    {
        public MiDb(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Muchos a Muchos M:N
            modelBuilder.Entity<ClienteVehiculo>().HasKey( cv => new {cv.ClienteId, cv.VehiculoId } );

            modelBuilder.Entity<ClienteVehiculo>()
                            .HasOne(cv => cv.Cliente)
                            .WithMany(clt => clt.ClientesVehiculos)
                            .HasForeignKey(cv => cv.ClienteId);

            modelBuilder.Entity<ClienteVehiculo>()
                            .HasOne(cv => cv.Vehiculo)
                            .WithMany(vh => vh.ClientesVehiculos)
                            .HasForeignKey(cv => cv.VehiculoId);
            #endregion

            //modelBuilder.Entity<Persona>().HasKey(p => p.Id);

        }
        public DbSet<Persona> Personas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }


    }
}
