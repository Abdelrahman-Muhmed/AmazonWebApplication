﻿// <auto-generated />
using System;
using Amazon_EF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Amazon_EF.Data
{
    [DbContext(typeof(StoreContext))]
    [Migration("20240820035644_EditeDBSetName")]
    partial class EditeDBSetName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Amazon_Core.Model.OrderModel.DeliveryMethod", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("DeliveryTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("cost")
                        .HasColumnType("decimal(12,2)");

                    b.Property<string>("shortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("DeliveryMethods");
                });

            modelBuilder.Entity("Amazon_Core.Model.OrderModel.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("ByerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("dateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("deliveryMethodId")
                        .HasColumnType("int");

                    b.Property<string>("orderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("paymentIntedId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("subTotal")
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("id");

                    b.HasIndex("deliveryMethodId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Amazon_Core.Model.OrderModel.orderItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("Orderid")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(12,2)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Orderid");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Amazon_Core.Model.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18 , 2)");

                    b.HasKey("id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Amazon_Core.Model.ProductBrand", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ProductBrand");
                });

            modelBuilder.Entity("Amazon_Core.Model.ProductCategory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("Amazon_Core.Model.OrderModel.Order", b =>
                {
                    b.HasOne("Amazon_Core.Model.OrderModel.DeliveryMethod", "deliveryMethod")
                        .WithMany()
                        .HasForeignKey("deliveryMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Amazon_Core.Model.OrderModel.Adress", "shippingAdress", b1 =>
                        {
                            b1.Property<int>("Orderid")
                                .HasColumnType("int");

                            b1.Property<string>("city")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("firstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("lastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Orderid");

                            b1.ToTable("Order");

                            b1.WithOwner()
                                .HasForeignKey("Orderid");
                        });

                    b.Navigation("deliveryMethod");

                    b.Navigation("shippingAdress")
                        .IsRequired();
                });

            modelBuilder.Entity("Amazon_Core.Model.OrderModel.orderItem", b =>
                {
                    b.HasOne("Amazon_Core.Model.OrderModel.Order", null)
                        .WithMany("orderItem")
                        .HasForeignKey("Orderid");

                    b.OwnsOne("Amazon_Core.Model.OrderModel.productItemOreder", "productItemOreder", b1 =>
                        {
                            b1.Property<int>("orderItemid")
                                .HasColumnType("int");

                            b1.Property<int>("orderid")
                                .HasColumnType("int");

                            b1.Property<string>("picturelUrl")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("productId")
                                .HasColumnType("int");

                            b1.Property<string>("productName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("orderItemid");

                            b1.HasIndex("orderid");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("orderItemid");

                            b1.HasOne("Amazon_Core.Model.OrderModel.Order", "order")
                                .WithMany()
                                .HasForeignKey("orderid")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired();

                            b1.Navigation("order");
                        });

                    b.Navigation("productItemOreder")
                        .IsRequired();
                });

            modelBuilder.Entity("Amazon_Core.Model.Product", b =>
                {
                    b.HasOne("Amazon_Core.Model.ProductBrand", "ProductBrand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Amazon_Core.Model.ProductCategory", "CategoryName")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryName");

                    b.Navigation("ProductBrand");
                });

            modelBuilder.Entity("Amazon_Core.Model.OrderModel.Order", b =>
                {
                    b.Navigation("orderItem");
                });
#pragma warning restore 612, 618
        }
    }
}