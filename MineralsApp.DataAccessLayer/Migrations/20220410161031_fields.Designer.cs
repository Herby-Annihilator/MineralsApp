﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MineralsApp.DataAccessLayer.DbContexts;

namespace MineralsApp.DataAccessLayer.Migrations
{
    [DbContext(typeof(MySqlDbContext))]
    [Migration("20220410161031_fields")]
    partial class fields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("country");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("field_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<int?>("TerritoryId")
                        .HasColumnType("int")
                        .HasColumnName("territory_id");

                    b.HasKey("Id");

                    b.HasIndex("TerritoryId");

                    b.ToTable("field");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Territory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("territory_id");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("territory");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Field", b =>
                {
                    b.HasOne("MineralsApp.DataAccessLayer.Entities.Territory", "Territory")
                        .WithMany("Fields")
                        .HasForeignKey("TerritoryId");

                    b.Navigation("Territory");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Territory", b =>
                {
                    b.HasOne("MineralsApp.DataAccessLayer.Entities.Country", "Country")
                        .WithMany("Territories")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Country", b =>
                {
                    b.Navigation("Territories");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Territory", b =>
                {
                    b.Navigation("Fields");
                });
#pragma warning restore 612, 618
        }
    }
}