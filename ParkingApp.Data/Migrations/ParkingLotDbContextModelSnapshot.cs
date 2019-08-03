﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkingApp.Data;

namespace ParkingApp.Data.Migrations
{
    [DbContext(typeof(ParkingLotDbContext))]
    partial class ParkingLotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkingApp.DAL.ParkingLevelModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsFull");

                    b.Property<int>("Level");

                    b.Property<int>("ParkingId");

                    b.HasKey("Id");

                    b.HasIndex("Level")
                        .IsUnique();

                    b.HasIndex("ParkingId");

                    b.ToTable("ParkingLevels");
                });

            modelBuilder.Entity("ParkingApp.DAL.ParkingLotModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ParkingLots");
                });

            modelBuilder.Entity("ParkingApp.DAL.ParkingSpaceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsTaken");

                    b.Property<int>("ParkingLevelId");

                    b.Property<int>("SpaceNumber");

                    b.HasKey("Id");

                    b.HasIndex("ParkingLevelId");

                    b.ToTable("ParkingSpaces");
                });

            modelBuilder.Entity("ParkingApp.DAL.ParkingLevelModel", b =>
                {
                    b.HasOne("ParkingApp.DAL.ParkingLotModel", "ParkingLot")
                        .WithMany("ParkingLevels")
                        .HasForeignKey("ParkingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ParkingApp.DAL.ParkingSpaceModel", b =>
                {
                    b.HasOne("ParkingApp.DAL.ParkingLevelModel", "ParkingLevel")
                        .WithMany("ParkingSlots")
                        .HasForeignKey("ParkingLevelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
