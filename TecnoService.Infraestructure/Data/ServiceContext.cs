using Microsoft.EntityFrameworkCore;
using TecnoService.Core.Models;

namespace TecnoService.Infraestructure.Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }


        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Dispositivo> Dispositivos { get; set; }

        public DbSet<Persona> Personas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Trabajador> Trabajadores { get; set; }

        public DbSet<InDis> Ingreso { get; set; }

        public DbSet<Factura> Facturas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelB)
        {
            modelB.Entity<Cliente>()
                .HasOne(c => c.Persona)
                .WithOne(p => p.Cliente)
                .HasForeignKey<Cliente>(c => c.IDPersona)
                .OnDelete(DeleteBehavior.Restrict);

            modelB.Entity<Trabajador>()
                .HasOne(t => t.Persona)
                .WithOne(p => p.Trabajador)
                .HasForeignKey<Trabajador>(t => t.IDPersona)
                .OnDelete(DeleteBehavior.Restrict);

            modelB.Entity<Dispositivo>()
                .HasOne(d => d.Marca)
                .WithMany(m => m.Dispositivos)
                .HasForeignKey(d => d.IDMarca)
                .OnDelete(DeleteBehavior.Restrict);

            modelB.Entity<InDis>()
                .HasOne(i => i.Cliente)
                .WithMany(c => c.Ingreso)
                .HasForeignKey(i => i.IDCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelB.Entity<InDis>()
                .HasOne(i => i.Dispositivo)
                .WithMany(d => d.Ingreso)
                .HasForeignKey(i => i.IDDispositivo)
                .OnDelete(DeleteBehavior.Restrict);

            modelB.Entity<Factura>()
                .HasOne(f => f.ingreso)
                .WithOne(i => i.Factura)
                .HasForeignKey<Factura>(f => f.IDInDis)
                .OnDelete(DeleteBehavior.Restrict);

            modelB.Entity<Factura>()
                .HasOne(f => f.Trabajador)
                .WithMany(t => t.Facturas)
                .HasForeignKey(f => f.IDTrabajador)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelB);
        }

    }
}
