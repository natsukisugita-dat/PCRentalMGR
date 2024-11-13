﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PCRentalMGR.Migrations
{
    [DbContext(typeof(PCRentalMGRContext))]
    [Migration("20241009072007_AddDeviceIdToRentals")]
    partial class AddDeviceIdToRentals
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PCRentalMGR.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Asset_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Capacity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Failure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gpu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Maker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Memory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Os")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Store")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("delete_flag")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("edit_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("limit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("register_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("remaker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("PCRentalMGR.Models.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Asset_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Canrental")
                        .HasColumnType("bit");

                    b.Property<int?>("DeviceId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InventryDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Maker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Os")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Overday")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RenewDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentalLimit")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentalStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Store")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("PCRentalMGR.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Account_level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Employee_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Mail_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_kana")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Register_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Retire_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tel_no")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Update_date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
