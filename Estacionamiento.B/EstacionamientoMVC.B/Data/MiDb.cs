using EstacionamientoMVC.B.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EstacionamientoMVC.B.Data
{
    public class MiDb : DbContext
    {
        public MiDb(DbContextOptions options) : base(options) { }


        public DbSet<Persona> Personas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Telefono> Telefonos { get; set; }


    }
}
