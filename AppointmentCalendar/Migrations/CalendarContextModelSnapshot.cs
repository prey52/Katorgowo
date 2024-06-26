﻿// <auto-generated />
using System;
using AppointmentCalendar.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppointmentCalendar.Migrations
{
    [DbContext(typeof(CalendarContext))]
    partial class CalendarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppointmentCalendar.Models.SpotkaniaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdAplikacji")
                        .HasColumnType("int");

                    b.Property<int>("IdWydarzenia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Spotkania");
                });

            modelBuilder.Entity("AppointmentCalendar.Models.WydarzeniaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Data")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("End")
                        .HasColumnType("time");

                    b.Property<int>("IdRekrutera")
                        .HasColumnType("int");

                    b.Property<TimeOnly>("Start")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Wydarzenia");
                });
#pragma warning restore 612, 618
        }
    }
}
