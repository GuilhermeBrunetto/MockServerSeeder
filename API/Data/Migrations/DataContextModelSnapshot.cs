﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("API.Entities.Acordo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contrato")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("GraoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Moeda")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Variacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GraoId");

                    b.ToTable("Acordos");
                });

            modelBuilder.Entity("API.Entities.Grao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Graos");
                });

            modelBuilder.Entity("API.Entities.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("API.Entities.Territorio", b =>
                {
                    b.Property<int>("TerritorioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bolsa")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("TerritorioId");

                    b.ToTable("Territorios");
                });

            modelBuilder.Entity("API.Entities.TerritorioProduto", b =>
                {
                    b.Property<int>("TerritorioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TerritorioId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("TerritorioProduto");
                });

            modelBuilder.Entity("API.Entities.Acordo", b =>
                {
                    b.HasOne("API.Entities.Grao", "Grao")
                        .WithMany("Acordos")
                        .HasForeignKey("GraoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grao");
                });

            modelBuilder.Entity("API.Entities.Grao", b =>
                {
                    b.HasOne("API.Entities.Produto", null)
                        .WithMany("Graos")
                        .HasForeignKey("ProdutoId");
                });

            modelBuilder.Entity("API.Entities.TerritorioProduto", b =>
                {
                    b.HasOne("API.Entities.Territorio", "Territorio")
                        .WithMany("Produtos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Produto", "Produto")
                        .WithMany("Territorios")
                        .HasForeignKey("TerritorioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Territorio");
                });

            modelBuilder.Entity("API.Entities.Grao", b =>
                {
                    b.Navigation("Acordos");
                });

            modelBuilder.Entity("API.Entities.Produto", b =>
                {
                    b.Navigation("Graos");

                    b.Navigation("Territorios");
                });

            modelBuilder.Entity("API.Entities.Territorio", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
