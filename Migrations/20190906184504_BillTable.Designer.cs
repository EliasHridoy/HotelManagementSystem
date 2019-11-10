﻿// <auto-generated />
using System;
using HotelManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelManagementSystem.Migrations
{
    [DbContext(typeof(HotelContext))]
    [Migration("20190906184504_BillTable")]
    partial class BillTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelManagementSystem.Models.DepartmentViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("DepartmentTable");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.EmployeeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("GenderId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNo")
                        .IsRequired();

                    b.Property<float>("Salary");

                    b.Property<bool>("delete");

                    b.HasKey("Id");

                    b.ToTable("EmployeeTable");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.GenderViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Gender");

                    b.HasKey("Id");

                    b.ToTable("GenderTable");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.GuestsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<int>("GenderId");

                    b.Property<string>("NICno")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("PhoneNo")
                        .IsRequired();

                    b.Property<bool>("delete");

                    b.HasKey("Id");

                    b.ToTable("GuestTable");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<int>("EmployeeId");

                    b.Property<int>("GuestId");

                    b.Property<float>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("ReservationCode");

                    b.Property<int>("ServiceId");

                    b.Property<bool>("paid");

                    b.HasKey("Id");

                    b.ToTable("OrderTable");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.ReserveModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adults");

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<int>("Children");

                    b.Property<bool>("ConfirmChekout");

                    b.Property<int>("GuestId");

                    b.Property<int>("NoOfNights");

                    b.Property<int>("ReservationCode");

                    b.Property<int>("RoomId");

                    b.Property<bool>("delete");

                    b.HasKey("Id");

                    b.ToTable("ReserveTable");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.RoomModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingNo");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("RoomTypeId");

                    b.Property<bool>("StatusId");

                    b.Property<bool>("delete");

                    b.HasKey("Id");

                    b.ToTable("RoomTable");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.RoomTypeViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Adults");

                    b.Property<int>("Children");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<float>("SinglePrice");

                    b.Property<float>("StandardPrice");

                    b.HasKey("Id");

                    b.ToTable("RoomTypeTable");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.ServiceCatagoryViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ServiceCatagoryTable");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.ServiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<float>("Price");

                    b.Property<int>("ServiceCategoryId");

                    b.Property<bool>("delete");

                    b.HasKey("Id");

                    b.ToTable("ServiceTable");
                });

            modelBuilder.Entity("HotelManagementSystem.Models.ViewModel.BillViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GuestId");

                    b.Property<bool>("Paid");

                    b.Property<int>("ReservationCode");

                    b.Property<double>("TotalBill");

                    b.HasKey("Id");

                    b.ToTable("BillTable");
                });
#pragma warning restore 612, 618
        }
    }
}
