using Microsoft.EntityFrameworkCore;
using Oferton.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oferton.Repositories.EFCore.DataContext
{
    public class OfertonContext : DbContext
    {
        public OfertonContext(DbContextOptions<OfertonContext> options) :
            base(options)
        { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>()
            //    .Property(c => c.nCalificacion)
            //    .HasMaxLength(9);

            //modelBuilder.Entity<Order>()
            //.HasKey(od => new { od.nIdProducto, od.nIdCliente });

            modelBuilder.Entity<Customer>()
                .HasKey(od => new { od.nIdCliente });

            modelBuilder.Entity<Product>()
                .HasKey(od => new { od.nIdProducto });

            modelBuilder.Entity<Order>()
                .HasKey(od => new { od.nIdOrden });

            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.nIdCliente);

            modelBuilder.Entity<Order>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(o => o.nIdProducto);

            modelBuilder.Entity<Product>()
                .HasData(
                new Product
                {
                    nIdProducto = 1,
                    sNombreProducto = "AUDIFONOS SKULLCANDY",
                    sDescripcion = "Marca: JBL;Modelo: TUNE 750BTNC;Tipo: Audifonos Bluetooth; Peso: 220gr.;Resistente al agua: No",
                    nCalificacion = 8,
                    nPrecio = 430,
                    nStock = 5,
                    sRutaImagen = "assets/images/items/9.jpg"
                }
                );

        }

    }
}
