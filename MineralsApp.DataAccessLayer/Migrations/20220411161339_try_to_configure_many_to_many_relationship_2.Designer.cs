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
    [Migration("20220411161339_try_to_configure_many_to_many_relationship_2")]
    partial class try_to_configure_many_to_many_relationship_2
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

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Mineral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("mineral_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("PathToImage")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("path_to_image");

                    b.HasKey("Id");

                    b.ToTable("mineral");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Ore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ore_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("ore");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Publication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("publication_id");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("creation_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("publication");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.PublicationDescribesMineral", b =>
                {
                    b.Property<int>("MineralId")
                        .HasColumnType("int")
                        .HasColumnName("mineral_id");

                    b.Property<int>("PublicationId")
                        .HasColumnType("int")
                        .HasColumnName("publication_id");

                    b.HasKey("MineralId", "PublicationId");

                    b.HasIndex("PublicationId");

                    b.ToTable("publication_describes_mineral");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Researcher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("researcher_id");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("last_name");

                    b.Property<string>("Patronymic")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("patronymic");

                    b.HasKey("Id");

                    b.ToTable("researcher");
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

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.PublicationDescribesMineral", b =>
                {
                    b.HasOne("MineralsApp.DataAccessLayer.Entities.Mineral", "Mineral")
                        .WithMany("PublicationDescribesMineral")
                        .HasForeignKey("MineralId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MineralsApp.DataAccessLayer.Entities.Publication", "Publication")
                        .WithMany("PublicationDescribesMineral")
                        .HasForeignKey("PublicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mineral");

                    b.Navigation("Publication");
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

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Mineral", b =>
                {
                    b.Navigation("PublicationDescribesMineral");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Publication", b =>
                {
                    b.Navigation("PublicationDescribesMineral");
                });

            modelBuilder.Entity("MineralsApp.DataAccessLayer.Entities.Territory", b =>
                {
                    b.Navigation("Fields");
                });
#pragma warning restore 612, 618
        }
    }
}
