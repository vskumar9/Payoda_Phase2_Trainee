﻿// <auto-generated />
using System;
using API_JWT_Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_JWT_Application.Migrations
{
    [DbContext(typeof(API_JWT_DbContext))]
    [Migration("20240906045125_Add Users Table")]
    partial class AddUsersTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API_JWT_Application.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorName = "Sanjeev",
                            Price = 200m,
                            Title = "My Life"
                        },
                        new
                        {
                            BookId = 2,
                            AuthorName = "Sanjay",
                            Price = 300m,
                            Title = "Beauty beast"
                        },
                        new
                        {
                            BookId = 3,
                            AuthorName = "San ray",
                            Price = 500m,
                            Title = "See It Once"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
