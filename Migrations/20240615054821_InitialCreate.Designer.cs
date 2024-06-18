﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepairShopV2.Data;

#nullable disable

namespace RepairShopV2.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240615054821_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RepairShopV2.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("RepairShopV2.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientCompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientCompanyId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RepairShopV2.Models.ClientCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClientCompanies");
                });

            modelBuilder.Entity("RepairShopV2.Models.ClientVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientCompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleMakeId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleModelId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientCompanyId");

                    b.HasIndex("ClientId");

                    b.HasIndex("VehicleMakeId");

                    b.HasIndex("VehicleModelId");

                    b.ToTable("ClientVehicles");
                });

            modelBuilder.Entity("RepairShopV2.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("RepairShopV2.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("LaborHours")
                        .HasColumnType("time");

                    b.Property<decimal>("LaborPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ServiceCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServiceCategoryId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("RepairShopV2.Models.ServiceCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ServiceCategories");
                });

            modelBuilder.Entity("RepairShopV2.Models.SparePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("SupplierId");

                    b.ToTable("SpareParts");
                });

            modelBuilder.Entity("RepairShopV2.Models.SparePartStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SparePartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SparePartId");

                    b.ToTable("SparePartStorages");
                });

            modelBuilder.Entity("RepairShopV2.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("RepairShopV2.Models.VehicleMake", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleMakes");
                });

            modelBuilder.Entity("RepairShopV2.Models.VehicleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleMakeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleMakeId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("RepairShopV2.Models.Client", b =>
                {
                    b.HasOne("RepairShopV2.Models.ClientCompany", "ClientCompany")
                        .WithMany("Clients")
                        .HasForeignKey("ClientCompanyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ClientCompany");
                });

            modelBuilder.Entity("RepairShopV2.Models.ClientVehicle", b =>
                {
                    b.HasOne("RepairShopV2.Models.ClientCompany", "ClientCompany")
                        .WithMany()
                        .HasForeignKey("ClientCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RepairShopV2.Models.Client", "Client")
                        .WithMany("ClientVehicles")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RepairShopV2.Models.VehicleMake", "VehicleMake")
                        .WithMany("ClientVehicles")
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RepairShopV2.Models.VehicleModel", "VehicleModel")
                        .WithMany("ClientVehicles")
                        .HasForeignKey("VehicleModelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("ClientCompany");

                    b.Navigation("VehicleMake");

                    b.Navigation("VehicleModel");
                });

            modelBuilder.Entity("RepairShopV2.Models.Service", b =>
                {
                    b.HasOne("RepairShopV2.Models.ServiceCategory", "ServiceCategory")
                        .WithMany("Services")
                        .HasForeignKey("ServiceCategoryId");

                    b.Navigation("ServiceCategory");
                });

            modelBuilder.Entity("RepairShopV2.Models.SparePart", b =>
                {
                    b.HasOne("RepairShopV2.Models.Category", "Category")
                        .WithMany("SpareParts")
                        .HasForeignKey("CategoryId");

                    b.HasOne("RepairShopV2.Models.Manufacturer", "Manufacturer")
                        .WithMany("SpareParts")
                        .HasForeignKey("ManufacturerId");

                    b.HasOne("RepairShopV2.Models.Service", "Service")
                        .WithMany("SpareParts")
                        .HasForeignKey("ServiceId");

                    b.HasOne("RepairShopV2.Models.Supplier", "Supplier")
                        .WithMany("SpareParts")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");

                    b.Navigation("Service");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("RepairShopV2.Models.SparePartStorage", b =>
                {
                    b.HasOne("RepairShopV2.Models.SparePart", "SparePart")
                        .WithMany("SparePartStorages")
                        .HasForeignKey("SparePartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SparePart");
                });

            modelBuilder.Entity("RepairShopV2.Models.VehicleModel", b =>
                {
                    b.HasOne("RepairShopV2.Models.VehicleMake", "VehicleMake")
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VehicleMake");
                });

            modelBuilder.Entity("RepairShopV2.Models.Category", b =>
                {
                    b.Navigation("SpareParts");
                });

            modelBuilder.Entity("RepairShopV2.Models.Client", b =>
                {
                    b.Navigation("ClientVehicles");
                });

            modelBuilder.Entity("RepairShopV2.Models.ClientCompany", b =>
                {
                    b.Navigation("Clients");
                });

            modelBuilder.Entity("RepairShopV2.Models.Manufacturer", b =>
                {
                    b.Navigation("SpareParts");
                });

            modelBuilder.Entity("RepairShopV2.Models.Service", b =>
                {
                    b.Navigation("SpareParts");
                });

            modelBuilder.Entity("RepairShopV2.Models.ServiceCategory", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("RepairShopV2.Models.SparePart", b =>
                {
                    b.Navigation("SparePartStorages");
                });

            modelBuilder.Entity("RepairShopV2.Models.Supplier", b =>
                {
                    b.Navigation("SpareParts");
                });

            modelBuilder.Entity("RepairShopV2.Models.VehicleMake", b =>
                {
                    b.Navigation("ClientVehicles");

                    b.Navigation("VehicleModels");
                });

            modelBuilder.Entity("RepairShopV2.Models.VehicleModel", b =>
                {
                    b.Navigation("ClientVehicles");
                });
#pragma warning restore 612, 618
        }
    }
}