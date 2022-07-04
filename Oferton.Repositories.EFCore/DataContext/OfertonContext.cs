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
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Use the entity name instead of the Context.DbSet<T> name
                // refs https://docs.microsoft.com/en-us/ef/core/modeling/entity-types?tabs=fluent-api#table-name
                modelBuilder.Entity(entityType.ClrType).ToTable(entityType.ClrType.Name);
            }

            modelBuilder.Entity<Customer>(b =>
            {
                b.HasKey(e => e.nIdCliente);
                b.Property(e => e.nIdCliente).ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<Product>(b =>
            {
                b.HasKey(e => e.nIdProducto);
                b.Property(e => e.nIdProducto).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Order>(b =>
            {
                b.HasKey(e => e.nIdOrden);
                b.Property(e => e.nIdOrden).ValueGeneratedOnAdd();
            });

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
