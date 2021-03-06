// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositorio.Context;

namespace Repositorio.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20220219235919_EmptyDatabase")]
    partial class EmptyDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("Dominio.Advogado.Advogado", b =>
                {
                    b.Property<byte[]>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<bool>("Ativo")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Endereco")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senioridade")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Advogados");
                });
#pragma warning restore 612, 618
        }
    }
}
