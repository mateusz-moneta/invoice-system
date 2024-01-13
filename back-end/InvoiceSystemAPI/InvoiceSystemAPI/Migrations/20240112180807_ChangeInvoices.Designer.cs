﻿// <auto-generated />
using System;
using InvoiceSystemAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InvoiceSystemAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240112180807_ChangeInvoices")]
    partial class ChangeInvoices
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("InvoiceSystemAPI.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Buyer_Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Buyer_City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Buyer_Id")
                        .HasColumnType("integer");

                    b.Property<string>("Buyer_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Buyer_Zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Invoice_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Invoice_Id")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Is_Paid")
                        .HasColumnType("boolean");

                    b.Property<string>("Issuer_Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Issuer_City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Issuer_Id")
                        .HasColumnType("integer");

                    b.Property<string>("Issuer_Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Issuer_Zip")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Payment_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Status_Id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Transaction_Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("InvoiceSystemAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TaxNumber")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InvoiceSystemAPI.Models.Invoice", b =>
                {
                    b.HasOne("InvoiceSystemAPI.Models.User", null)
                        .WithMany("Invoices")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("InvoiceSystemAPI.Models.User", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
