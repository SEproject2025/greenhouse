﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using greenhouse.Data;

#nullable disable

namespace greenhouse.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241108171802_AddPlantImage")]
    partial class AddPlantImage
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("greenhouse.Entities.Plants", b =>
                {
                    b.Property<int>("PLANT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("IMAGE_DATA")
                        .HasColumnType("longblob");

                    b.Property<string>("IS_PRIVATE")
                        .HasColumnType("longtext");

                    b.Property<string>("PLANT_NAME")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("USER_ID")
                        .HasColumnType("longtext");

                    b.HasKey("PLANT_ID");

                    b.ToTable("Plant");
                });
#pragma warning restore 612, 618
        }
    }
}