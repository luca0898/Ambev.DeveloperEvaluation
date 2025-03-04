using System;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20241209203836_Initial")]
    partial class Initial
    {
        
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.BranchAggregate.Entities.Branch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Branchs", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities.CartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("CartId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.CategoryAggregate.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("ExternalId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities.ProductRating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Rate")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductRatings");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities.Sale", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid?>("BranchId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCancelled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("SaleNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SaleNumber")
                        .IsUnique();

                    b.ToTable("Sales", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities.SaleItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasMaxLength(20)
                        .HasColumnType("integer");

                    b.Property<Guid>("SaleId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TotalItemAmount");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleId");

                    b.ToTable("SaleItems", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime?>("UpdatedAt")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities.Cart", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities.CartItem", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities.Cart", "Cart")
                        .WithMany("Products")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cart");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate.Entities.Customer", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities.Product", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Models.CategoryAggregate.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities.ProductRating", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities.Product", null)
                        .WithOne("Rating")
                        .HasForeignKey("Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities.ProductRating", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities.Sale", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Models.BranchAggregate.Entities.Branch", null)
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Models.CustomerAggregate.Entities.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities.SaleItem", b =>
                {
                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities.Sale", "Sale")
                        .WithMany("Items")
                        .HasForeignKey("SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Entities.User", b =>
                {
                    b.OwnsOne("Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common.AddressDto", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<int>("Number")
                                .HasColumnType("integer");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("character varying(200)");

                            b1.Property<string>("Zipcode")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("character varying(20)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");

                            b1.OwnsOne("Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common.GeolocationDto", "Geolocation", b2 =>
                                {
                                    b2.Property<Guid>("AddressDtoUserId")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Lat")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("character varying(50)");

                                    b2.Property<string>("Long")
                                        .IsRequired()
                                        .HasMaxLength(50)
                                        .HasColumnType("character varying(50)");

                                    b2.HasKey("AddressDtoUserId");

                                    b2.ToTable("Users");

                                    b2.WithOwner()
                                        .HasForeignKey("AddressDtoUserId");
                                });

                            b1.Navigation("Geolocation")
                                .IsRequired();
                        });

                    b.OwnsOne("Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common.NameDto", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid");

                            b1.Property<string>("Firstname")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.Property<string>("Lastname")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("character varying(50)");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.CartDomain.Entities.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.CategoryAggregate.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.ProductAggregate.Entities.Product", b =>
                {
                    b.Navigation("Rating")
                        .IsRequired();
                });

            modelBuilder.Entity("Ambev.DeveloperEvaluation.Domain.Models.SaleDomain.Entities.Sale", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
