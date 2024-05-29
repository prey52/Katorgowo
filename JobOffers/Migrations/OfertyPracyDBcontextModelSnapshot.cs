﻿// <auto-generated />
using System;
using JobOffers.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace OfertyPracy.Migrations
{
    [DbContext(typeof(OfertyPracyDBcontext))]
    partial class OfertyPracyDBcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobOffers.Models.OfertyPracyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataDodania")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPublikacji")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataWaznosci")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRekrutera")
                        .HasColumnType("int");

                    b.Property<string>("Kategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RodzajUmowy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tytuł")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wymagania")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WymiarPracy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wynagrodzenie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OfertyPracy");
                });

            modelBuilder.Entity("OfertyPracy.Database.Benefity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OfertaPracyId")
                        .HasColumnType("int");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfertaPracyId");

                    b.ToTable("Benefity");
                });

            modelBuilder.Entity("OfertyPracy.Database.Benefity", b =>
                {
                    b.HasOne("JobOffers.Models.OfertyPracyModel", "OfertaPracy")
                        .WithMany("Benefity")
                        .HasForeignKey("OfertaPracyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OfertaPracy");
                });

            modelBuilder.Entity("JobOffers.Models.OfertyPracyModel", b =>
                {
                    b.Navigation("Benefity");
                });
#pragma warning restore 612, 618
        }
    }
}
