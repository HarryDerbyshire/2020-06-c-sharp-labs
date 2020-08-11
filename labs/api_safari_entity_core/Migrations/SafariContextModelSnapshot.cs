﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api_safari_entity_core.Models;

namespace api_safari_entity_core.Migrations
{
    [DbContext(typeof(SafariContext))]
    partial class SafariContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("api_safari_entity_core.Models.Animal", b =>
                {
                    b.Property<int>("AnimalId")
                        .HasColumnName("animalId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnimalName")
                        .HasColumnName("animalName")
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("TypeId")
                        .HasColumnName("typeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AnimalId");

                    b.HasIndex("TypeId");

                    b.ToTable("animals");
                });

            modelBuilder.Entity("api_safari_entity_core.Models.AnimalType", b =>
                {
                    b.Property<int>("TypeId")
                        .HasColumnName("typeId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("NumberOfLegs")
                        .HasColumnName("numberOfLegs")
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .HasColumnName("typeName")
                        .HasColumnType("varchar(40)");

                    b.HasKey("TypeId");

                    b.ToTable("animal_types");
                });

            modelBuilder.Entity("api_safari_entity_core.Models.Animal", b =>
                {
                    b.HasOne("api_safari_entity_core.Models.AnimalType", "Type")
                        .WithMany("Animals")
                        .HasForeignKey("TypeId");
                });
#pragma warning restore 612, 618
        }
    }
}