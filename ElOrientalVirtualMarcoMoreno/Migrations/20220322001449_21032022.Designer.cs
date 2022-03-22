﻿// <auto-generated />
using System;
using ElOrientalVirtualMarcoMoreno.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ElOrientalVirtualMarcoMoreno.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220322001449_21032022")]
    partial class _21032022
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ElOrientalVirtualMarcoMoreno.Models.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ElOrientalVirtualMarcoMoreno.Models.Files", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Filedb")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ElOrientalVirtualMarcoMoreno.Models.ModuloVirtual", b =>
                {
                    b.Property<int>("IdModulo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionModulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPropietario")
                        .HasColumnType("int");

                    b.HasKey("IdModulo");

                    b.HasIndex("IdPropietario");

                    b.ToTable("ModuloVirtual");
                });

            modelBuilder.Entity("ElOrientalVirtualMarcoMoreno.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescripcionProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<double>("PrecioProducto")
                        .HasColumnType("float");

                    b.Property<string>("RutaProductoImagen")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("IdProducto");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("ElOrientalVirtualMarcoMoreno.Models.Propietario", b =>
                {
                    b.Property<int>("IdPropietario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaCeacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombrePropietario")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdPropietario");

                    b.ToTable("Propietario");
                });

            modelBuilder.Entity("ElOrientalVirtualMarcoMoreno.Models.ModuloVirtual", b =>
                {
                    b.HasOne("ElOrientalVirtualMarcoMoreno.Models.Propietario", "Propietario")
                        .WithMany()
                        .HasForeignKey("IdPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ElOrientalVirtualMarcoMoreno.Models.Producto", b =>
                {
                    b.HasOne("ElOrientalVirtualMarcoMoreno.Models.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
