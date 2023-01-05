﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sanpaolo.Data;

namespace sanpaolo.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220824155845_Banca")]
    partial class Banca
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("sanpaolo.Models.Banca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sede")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banca");
                });

            modelBuilder.Entity("sanpaolo.Models.Conto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NConto")
                        .HasColumnType("int");

                    b.Property<float>("Saldo")
                        .HasColumnType("real");

                    b.Property<int>("SalvadanaioId")
                        .HasColumnType("int");

                    b.Property<int>("UtenteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalvadanaioId")
                        .IsUnique();

                    b.HasIndex("UtenteId")
                        .IsUnique();

                    b.ToTable("Conti");
                });

            modelBuilder.Entity("sanpaolo.Models.Salvadanaio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("AmmontareObbiettivo")
                        .HasColumnType("real");

                    b.Property<DateTime>("DataCreazione")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataScadenza")
                        .HasColumnType("datetime2");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SaldoAttuale")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Salvadanaio");
                });

            modelBuilder.Entity("sanpaolo.Models.Utente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BancaId")
                        .HasColumnType("int");

                    b.Property<string>("Cap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodiceFiscale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cognome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comune")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataDiNascita")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazionalita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroCartaIdentita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Paese")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Provincia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Regione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ruolo")
                        .HasColumnType("int");

                    b.Property<string>("Via")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BancaId");

                    b.ToTable("Utenti");
                });

            modelBuilder.Entity("sanpaolo.Models.Conto", b =>
                {
                    b.HasOne("sanpaolo.Models.Salvadanaio", "Salvadanaio")
                        .WithOne("Conto")
                        .HasForeignKey("sanpaolo.Models.Conto", "SalvadanaioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sanpaolo.Models.Utente", "Utente")
                        .WithOne("Conto")
                        .HasForeignKey("sanpaolo.Models.Conto", "UtenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sanpaolo.Models.Utente", b =>
                {
                    b.HasOne("sanpaolo.Models.Banca", "Banca")
                        .WithMany("Contisti")
                        .HasForeignKey("BancaId");
                });
#pragma warning restore 612, 618
        }
    }
}
