// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pablo_Burgos_Proyecto_Final.DAL;

#nullable disable

namespace Pablo_Burgos_Proyecto_Final.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("Pablo_Burgos_Proyecto_Final.Entidades.Compras", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadProductos")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("DescripcionSuplidor")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaDeCompra")
                        .HasColumnType("TEXT");

                    b.Property<int>("SuplidoresId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("precioTotal")
                        .HasColumnType("REAL");

                    b.HasKey("CompraId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("Pablo_Burgos_Proyecto_Final.Entidades.ComprasDetalles", b =>
                {
                    b.Property<int>("ComprasDetallesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompraId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("PrecioUnidad")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ComprasDetallesId");

                    b.HasIndex("CompraId");

                    b.ToTable("ComprasDetalles");
                });

            modelBuilder.Entity("Pablo_Burgos_Proyecto_Final.Entidades.Dispositivos", b =>
                {
                    b.Property<int>("DispositivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SistemaOperativo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DispositivoId");

                    b.ToTable("Dispositivos");

                    b.HasData(
                        new
                        {
                            DispositivoId = 1,
                            Marca = "ZTE",
                            Modelo = "546Z",
                            SistemaOperativo = "Android"
                        },
                        new
                        {
                            DispositivoId = 2,
                            Marca = "Iphone",
                            Modelo = "X",
                            SistemaOperativo = "IOS"
                        },
                        new
                        {
                            DispositivoId = 3,
                            Marca = "Alcatel",
                            Modelo = "Lite",
                            SistemaOperativo = "Android"
                        });
                });

            modelBuilder.Entity("Pablo_Burgos_Proyecto_Final.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<int>("DispositivoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<int>("Ganancia")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Itbis")
                        .HasColumnType("REAL");

                    b.Property<float>("PrecioConIbisGanancia")
                        .HasColumnType("REAL");

                    b.Property<float>("PrecioConItbis")
                        .HasColumnType("REAL");

                    b.Property<float>("TotalInventario")
                        .HasColumnType("REAL");

                    b.Property<string>("descripcionDispositivo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Pablo_Burgos_Proyecto_Final.Entidades.Suplidores", b =>
                {
                    b.Property<int>("SuplidoresId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Compania")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaDeCreacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Representante")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.HasKey("SuplidoresId");

                    b.ToTable("Suplidores");
                });

            modelBuilder.Entity("Pablo_Burgos_Proyecto_Final.Entidades.ComprasDetalles", b =>
                {
                    b.HasOne("Pablo_Burgos_Proyecto_Final.Entidades.Compras", null)
                        .WithMany("ComprasDetalles")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pablo_Burgos_Proyecto_Final.Entidades.Compras", b =>
                {
                    b.Navigation("ComprasDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
