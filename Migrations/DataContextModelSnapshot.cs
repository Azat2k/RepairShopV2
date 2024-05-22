﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RepairShopV2.Data;

#nullable disable

namespace RepairShopV2.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("Id");

                    b.ToTable("Services");
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

            modelBuilder.Entity("RepairShopV2.Models.SparePart", b =>
                {
                    b.HasOne("RepairShopV2.Models.Category", "Category")
                        .WithMany("SpareParts")
                        .HasForeignKey("CategoryId");

                    b.HasOne("RepairShopV2.Models.Service", "Service")
                        .WithMany("SpareParts")
                        .HasForeignKey("ServiceId");

                    b.HasOne("RepairShopV2.Models.Supplier", "Supplier")
                        .WithMany("SpareParts")
                        .HasForeignKey("SupplierId");

                    b.Navigation("Category");

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

            modelBuilder.Entity("RepairShopV2.Models.Category", b =>
                {
                    b.Navigation("SpareParts");
                });

            modelBuilder.Entity("RepairShopV2.Models.Service", b =>
                {
                    b.Navigation("SpareParts");
                });

            modelBuilder.Entity("RepairShopV2.Models.SparePart", b =>
                {
                    b.Navigation("SparePartStorages");
                });

            modelBuilder.Entity("RepairShopV2.Models.Supplier", b =>
                {
                    b.Navigation("SpareParts");
                });
#pragma warning restore 612, 618
        }
    }
}
