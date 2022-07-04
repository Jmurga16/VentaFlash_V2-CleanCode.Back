﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oferton.Repositories.EFCore.DataContext;

namespace Oferton.Repositories.EFCore.Migrations
{
    [DbContext(typeof(OfertonContext))]
    [Migration("20220704122558_InitialCreateProduction")]
    partial class InitialCreateProduction
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Oferton.Entities.POCOEntities.Customer", b =>
                {
                    b.Property<int>("nIdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("sCorreo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sDireccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sNombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nIdCliente");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Oferton.Entities.POCOEntities.Order", b =>
                {
                    b.Property<int>("nIdOrden")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("bEstado")
                        .HasColumnType("bit");

                    b.Property<int>("nIdCliente")
                        .HasColumnType("int");

                    b.Property<int>("nIdProducto")
                        .HasColumnType("int");

                    b.HasKey("nIdOrden");

                    b.HasIndex("nIdCliente");

                    b.HasIndex("nIdProducto");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Oferton.Entities.POCOEntities.Product", b =>
                {
                    b.Property<int>("nIdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("nCalificacion")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("nPrecio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("nStock")
                        .HasColumnType("int");

                    b.Property<string>("sDescripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sNombreProducto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sRutaImagen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("nIdProducto");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            nIdProducto = 1,
                            nCalificacion = 8m,
                            nPrecio = 430m,
                            nStock = 5,
                            sDescripcion = "Marca: JBL;Modelo: TUNE 750BTNC;Tipo: Audifonos Bluetooth; Peso: 220gr.;Resistente al agua: No",
                            sNombreProducto = "AUDIFONOS SKULLCANDY",
                            sRutaImagen = "assets/images/items/9.jpg"
                        });
                });

            modelBuilder.Entity("Oferton.Entities.POCOEntities.Order", b =>
                {
                    b.HasOne("Oferton.Entities.POCOEntities.Customer", null)
                        .WithMany()
                        .HasForeignKey("nIdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oferton.Entities.POCOEntities.Product", null)
                        .WithMany()
                        .HasForeignKey("nIdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
