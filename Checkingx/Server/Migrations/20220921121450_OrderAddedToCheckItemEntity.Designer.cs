﻿// <auto-generated />
using System;
using Checkingx.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Checkingx.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220921121450_OrderAddedToCheckItemEntity")]
    partial class OrderAddedToCheckItemEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("Checkingx.Shared.Checking", b =>
                {
                    b.Property<int>("CheckingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CheckDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("CheckItemId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ReviewDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CheckingId");

                    b.HasIndex("CheckItemId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Checking");
                });

            modelBuilder.Entity("Checkingx.Shared.CheckItem", b =>
                {
                    b.Property<int>("CheckItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Create")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderNo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("TEXT");

                    b.HasKey("CheckItemId");

                    b.ToTable("CheckItems");

                    b.HasData(
                        new
                        {
                            CheckItemId = 1,
                            Category = "SLAB",
                            Create = new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7680),
                            OrderNo = 0,
                            Priority = 3,
                            Title = "Ensure slab follows outline of ground floor."
                        },
                        new
                        {
                            CheckItemId = 2,
                            Category = "SLAB",
                            Create = new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7710),
                            OrderNo = 0,
                            Priority = 2,
                            Title = "Batten line is not shown on slab."
                        },
                        new
                        {
                            CheckItemId = 3,
                            Category = "SLAB",
                            Create = new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7712),
                            OrderNo = 0,
                            Priority = 3,
                            Title = "All load bearing walls are indicated."
                        },
                        new
                        {
                            CheckItemId = 4,
                            Category = "ROOF",
                            Create = new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7714),
                            OrderNo = 0,
                            Priority = 1,
                            Title = "All internal and external walls dimensioned and dimensions are accurate."
                        },
                        new
                        {
                            CheckItemId = 5,
                            Category = "PANELS",
                            Create = new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7716),
                            OrderNo = 0,
                            Priority = 1,
                            Title = "Cross dimensions are shown."
                        },
                        new
                        {
                            CheckItemId = 6,
                            Category = "PANELS",
                            Create = new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7718),
                            OrderNo = 0,
                            Priority = 2,
                            Title = "Point load symbols shown and dimensioned. Point loads are split for joinery"
                        },
                        new
                        {
                            CheckItemId = 7,
                            Category = "PANELS",
                            Create = new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7719),
                            OrderNo = 0,
                            Priority = 3,
                            Title = "All point loads end up on a sufficient beam or a load bearing wall."
                        },
                        new
                        {
                            CheckItemId = 8,
                            Category = "FLOOR",
                            Create = new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7721),
                            OrderNo = 0,
                            Priority = 1,
                            Title = "Portal panel shoes shown and dimensioned. Note added to ensure coursing blocks are left out where the shoe is positioned."
                        },
                        new
                        {
                            CheckItemId = 9,
                            Category = "FLOOR",
                            Create = new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7722),
                            OrderNo = 0,
                            Priority = 1,
                            Title = "Slab edge distance and spacing between bolts connecting portal frames/steel posts are correct."
                        },
                        new
                        {
                            CheckItemId = 10,
                            Category = "PANELS",
                            Create = new DateTime(2022, 9, 21, 14, 14, 49, 894, DateTimeKind.Local).AddTicks(7724),
                            OrderNo = 0,
                            Priority = 2,
                            Title = "If step in slab level appears, it is clearly indicated and detail is added."
                        });
                });

            modelBuilder.Entity("Checkingx.Shared.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CheckingId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CheckingId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Checkingx.Shared.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CheckingPriority")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Create")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Update")
                        .HasColumnType("TEXT");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Checkingx.Shared.Checking", b =>
                {
                    b.HasOne("Checkingx.Shared.CheckItem", "CheckItem")
                        .WithMany()
                        .HasForeignKey("CheckItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Checkingx.Shared.Project", "Project")
                        .WithMany("Checking")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckItem");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Checkingx.Shared.Image", b =>
                {
                    b.HasOne("Checkingx.Shared.Checking", null)
                        .WithMany("Images")
                        .HasForeignKey("CheckingId");
                });

            modelBuilder.Entity("Checkingx.Shared.Checking", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Checkingx.Shared.Project", b =>
                {
                    b.Navigation("Checking");
                });
#pragma warning restore 612, 618
        }
    }
}
