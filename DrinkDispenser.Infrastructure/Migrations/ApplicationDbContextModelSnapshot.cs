﻿// <auto-generated />
using System;
using DrinkDispenser.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DrinkDispenser.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DrinkDispenser.Domain.Coins.Coin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean");

                    b.Property<int>("Nominal")
                        .HasColumnType("integer");

                    b.Property<Guid>("VendingMachineId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VendingMachineId");

                    b.ToTable("Coins");
                });

            modelBuilder.Entity("DrinkDispenser.Domain.Drinks.Drink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("VendingMachineId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("VendingMachineId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("DrinkDispenser.Domain.VendingMachines.VendingMachine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<int>("CountDrinks")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("VendingMachines");
                });

            modelBuilder.Entity("DrinkDispenser.Domain.Coins.Coin", b =>
                {
                    b.HasOne("DrinkDispenser.Domain.VendingMachines.VendingMachine", "VendingMachine")
                        .WithMany("Coins")
                        .HasForeignKey("VendingMachineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("VendingMachine");
                });

            modelBuilder.Entity("DrinkDispenser.Domain.Drinks.Drink", b =>
                {
                    b.HasOne("DrinkDispenser.Domain.VendingMachines.VendingMachine", "VendingMachine")
                        .WithMany("Drinks")
                        .HasForeignKey("VendingMachineId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("VendingMachine");
                });

            modelBuilder.Entity("DrinkDispenser.Domain.VendingMachines.VendingMachine", b =>
                {
                    b.Navigation("Coins");

                    b.Navigation("Drinks");
                });
#pragma warning restore 612, 618
        }
    }
}
