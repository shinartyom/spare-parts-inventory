﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAD_00019330.Data;

#nullable disable

namespace WAD_00019330.Data.Migrations
{
    [DbContext(typeof(GeneralDBContext))]
    partial class GeneralDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WAD_00019330.Models.SpareCategory", b =>
                {
                    b.Property<int>("SpareCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpareCategoryId"), 1L, 1);

                    b.Property<string>("SpareCategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpareCategoryId");

                    b.ToTable("SpareCategories");
                });

            modelBuilder.Entity("WAD_00019330.Models.SparePart", b =>
                {
                    b.Property<int>("SparePartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SparePartId"), 1L, 1);

                    b.Property<int?>("SparePartCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("SparePartName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("SparePartPrice")
                        .IsRequired()
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SparePartQuantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("SparePartId");

                    b.HasIndex("SparePartCategoryID");

                    b.ToTable("SpareParts");
                });

            modelBuilder.Entity("WAD_00019330.Models.SparePart", b =>
                {
                    b.HasOne("WAD_00019330.Models.SpareCategory", "SpareCategory")
                        .WithMany()
                        .HasForeignKey("SparePartCategoryID");

                    b.Navigation("SpareCategory");
                });
#pragma warning restore 612, 618
        }
    }
}