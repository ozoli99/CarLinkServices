﻿// <auto-generated />
using System;
using CarLinkServices.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarLinkServices.Web.Migrations
{
    [DbContext(typeof(CarLinkServicesDbContext))]
    partial class CarLinkServicesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarLinkServices.Web.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GuestId")
                        .HasColumnType("int");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("bit");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.CarService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("CarServices");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.CarServiceImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarServiceId")
                        .HasColumnType("int");

                    b.Property<byte[]>("ImageLarge")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("ImageSmall")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarServiceId");

                    b.ToTable("CarServiceImages");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CarPlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("UserPassword")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarServiceId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.Appointment", b =>
                {
                    b.HasOne("CarLinkServices.Web.Models.Guest", null)
                        .WithMany("Appointments")
                        .HasForeignKey("GuestId");

                    b.HasOne("CarLinkServices.Web.Models.Service", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.CarService", b =>
                {
                    b.HasOne("CarLinkServices.Web.Models.City", "City")
                        .WithMany("CarServices")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.CarServiceImage", b =>
                {
                    b.HasOne("CarLinkServices.Web.Models.CarService", "CarService")
                        .WithMany()
                        .HasForeignKey("CarServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarService");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.Service", b =>
                {
                    b.HasOne("CarLinkServices.Web.Models.CarService", "CarService")
                        .WithMany("Services")
                        .HasForeignKey("CarServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarService");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.CarService", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.City", b =>
                {
                    b.Navigation("CarServices");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.Guest", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("CarLinkServices.Web.Models.Service", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
