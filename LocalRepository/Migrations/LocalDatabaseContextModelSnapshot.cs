﻿// <auto-generated />
using System;
using LocalRepository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocalRepository.Migrations
{
    [DbContext(typeof(LocalDatabaseContext))]
    partial class LocalDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Models.InventoryItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cost")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sku")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("InventoryItems");
                });

            modelBuilder.Entity("Models.ReceiptHeader", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<double>("SubTotal")
                        .HasColumnType("REAL");

                    b.Property<double>("Total")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalTax")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("ReceiptHeaders");
                });

            modelBuilder.Entity("Models.ReceiptPayment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AmountPaid")
                        .HasColumnType("REAL");

                    b.Property<int>("PaymentType")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ReceiptHeaderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ReceiptHeaderId");

                    b.ToTable("ReceiptPayment");
                });

            modelBuilder.Entity("Models.SaleItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Cost")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ReceiptHeaderId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sku")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ReceiptHeaderId");

                    b.ToTable("SalesItems");
                });

            modelBuilder.Entity("Models.ReceiptPayment", b =>
                {
                    b.HasOne("Models.ReceiptHeader", null)
                        .WithMany("ReceiptPayments")
                        .HasForeignKey("ReceiptHeaderId");
                });

            modelBuilder.Entity("Models.SaleItem", b =>
                {
                    b.HasOne("Models.ReceiptHeader", null)
                        .WithMany("ReceiptItems")
                        .HasForeignKey("ReceiptHeaderId");
                });
#pragma warning restore 612, 618
        }
    }
}
