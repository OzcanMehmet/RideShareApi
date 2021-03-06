﻿// <auto-generated />
using System;
using RideShare.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RideShare.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20200715165926_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdessoRideShare.Model.TravelGuest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GuestId")
                        .HasColumnType("int");

                    b.Property<int?>("PlanId")
                        .HasColumnType("int");

                    b.Property<int>("RezervedSeatCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("PlanId");

                    b.ToTable("TravelGuest");
                });

            modelBuilder.Entity("AdessoRideShare.Model.TravelPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("SeatCount")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Valid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("TravelPlan");
                });

            modelBuilder.Entity("AdessoRideShare.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AdessoRideShare.Model.TravelGuest", b =>
                {
                    b.HasOne("AdessoRideShare.Model.User", "Guest")
                        .WithMany()
                        .HasForeignKey("GuestId");

                    b.HasOne("AdessoRideShare.Model.TravelPlan", "Plan")
                        .WithMany("TravelGuest")
                        .HasForeignKey("PlanId");
                });

            modelBuilder.Entity("AdessoRideShare.Model.TravelPlan", b =>
                {
                    b.HasOne("AdessoRideShare.Model.User", "Owner")
                        .WithMany("TravelPlans")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
