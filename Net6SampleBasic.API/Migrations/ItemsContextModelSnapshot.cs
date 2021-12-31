﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Net6SampleBasic.API.DbContexts;

#nullable disable

namespace Net6SampleBasic.API.Migrations
{
    [DbContext(typeof(ItemsContext))]
    partial class ItemsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Net6SampleBasic.API.Entities.Inventory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationTag")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Inventories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"),
                            LocationTag = "34-A",
                            Name = "locationA"
                        },
                        new
                        {
                            Id = new Guid("ca2abc8e-1bdc-4887-8f97-215fe050f22f"),
                            LocationTag = "18-H",
                            Name = "locationB"
                        },
                        new
                        {
                            Id = new Guid("d097a599-4619-4473-ae86-d353c3069597"),
                            LocationTag = "1-B",
                            Name = "locationB"
                        });
                });

            modelBuilder.Entity("Net6SampleBasic.API.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("AccessionRecord")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("InventoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Value")
                        .HasMaxLength(50)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("InventoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6978cc16-5f5a-4020-bb79-4cc4dcc36b72"),
                            AccessionRecord = new DateTimeOffset(new DateTime(2019, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(188), new TimeSpan(0, 3, 0, 0, 0)),
                            Category = "Mechanic",
                            Description = "Fancy Machine",
                            InventoryId = new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"),
                            Value = 10m
                        },
                        new
                        {
                            Id = new Guid("4fa3169e-0779-45cc-9139-dc4ee92cbd5f"),
                            AccessionRecord = new DateTimeOffset(new DateTime(2016, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(215), new TimeSpan(0, 3, 0, 0, 0)),
                            Category = "Mechanic",
                            Description = "Ordinary Machine",
                            InventoryId = new Guid("5ab77607-42e8-4a25-b47a-db8983a652e8"),
                            Value = 10m
                        },
                        new
                        {
                            Id = new Guid("3675f42d-9bbb-488f-bd36-c7e6411c87d5"),
                            AccessionRecord = new DateTimeOffset(new DateTime(2015, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(219), new TimeSpan(0, 3, 0, 0, 0)),
                            Category = "Electronic",
                            Description = "ComputerA",
                            InventoryId = new Guid("ca2abc8e-1bdc-4887-8f97-215fe050f22f"),
                            Value = 10m
                        },
                        new
                        {
                            Id = new Guid("ea3a236e-fda4-4e3f-ae1d-3bd3a535a177"),
                            AccessionRecord = new DateTimeOffset(new DateTime(2020, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(221), new TimeSpan(0, 3, 0, 0, 0)),
                            Category = "Electronic",
                            Description = "ComputerB",
                            InventoryId = new Guid("ca2abc8e-1bdc-4887-8f97-215fe050f22f"),
                            Value = 10m
                        },
                        new
                        {
                            Id = new Guid("270ed53a-053b-442a-9302-716959d0a51a"),
                            AccessionRecord = new DateTimeOffset(new DateTime(2016, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(224), new TimeSpan(0, 3, 0, 0, 0)),
                            Category = "Office Supplies",
                            Description = "Desk",
                            InventoryId = new Guid("d097a599-4619-4473-ae86-d353c3069597"),
                            Value = 10m
                        },
                        new
                        {
                            Id = new Guid("b1ee8f72-0cc0-4cd9-bcc6-11183cf24da8"),
                            AccessionRecord = new DateTimeOffset(new DateTime(2016, 12, 25, 22, 40, 41, 921, DateTimeKind.Unspecified).AddTicks(226), new TimeSpan(0, 3, 0, 0, 0)),
                            Category = "Office Supplies",
                            Description = "Chair",
                            InventoryId = new Guid("d097a599-4619-4473-ae86-d353c3069597"),
                            Value = 10m
                        });
                });

            modelBuilder.Entity("Net6SampleBasic.API.Entities.Item", b =>
                {
                    b.HasOne("Net6SampleBasic.API.Entities.Inventory", "Inventory")
                        .WithMany("Items")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("Net6SampleBasic.API.Entities.Inventory", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}