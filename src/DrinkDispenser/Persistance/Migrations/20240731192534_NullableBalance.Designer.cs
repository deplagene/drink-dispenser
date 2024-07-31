﻿// <auto-generated />
using System;
using System.Collections.Generic;
using DrinkDispenser.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DrinkDispenser.Persistance.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240731192534_NullableBalance")]
    partial class NullableBalance
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("DrinkDispenser.Domain.Entities.Coin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("VendingMachineId")
                        .HasColumnType("TEXT");

                    b.ComplexProperty<Dictionary<string, object>>("Nominal", "DrinkDispenser.Domain.Entities.Coin.Nominal#Nominal", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<int>("Value")
                                .HasColumnType("INTEGER");
                        });

                    b.HasKey("Id");

                    b.HasIndex("VendingMachineId");

                    b.ToTable("Coins");
                });

            modelBuilder.Entity("DrinkDispenser.Domain.Entities.Drink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("VendingMachineId")
                        .HasColumnType("TEXT");

                    b.ComplexProperty<Dictionary<string, object>>("Price", "DrinkDispenser.Domain.Entities.Drink.Price#Price", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<decimal>("Value")
                                .HasColumnType("TEXT");
                        });

                    b.HasKey("Id");

                    b.HasIndex("VendingMachineId");

                    b.ToTable("Drinks");
                });

            modelBuilder.Entity("DrinkDispenser.Domain.Entities.VendingMachine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<int>("CountOfAvailableDrinks")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("VendingMachines");
                });

            modelBuilder.Entity("DrinkDispenser.Domain.Entities.Coin", b =>
                {
                    b.HasOne("DrinkDispenser.Domain.Entities.VendingMachine", "VendingMachine")
                        .WithMany("Coins")
                        .HasForeignKey("VendingMachineId");

                    b.Navigation("VendingMachine");
                });

            modelBuilder.Entity("DrinkDispenser.Domain.Entities.Drink", b =>
                {
                    b.HasOne("DrinkDispenser.Domain.Entities.VendingMachine", "VendingMachine")
                        .WithMany("Drinks")
                        .HasForeignKey("VendingMachineId");

                    b.Navigation("VendingMachine");
                });

            modelBuilder.Entity("DrinkDispenser.Domain.Entities.VendingMachine", b =>
                {
                    b.Navigation("Coins");

                    b.Navigation("Drinks");
                });
#pragma warning restore 612, 618
        }
    }
}
