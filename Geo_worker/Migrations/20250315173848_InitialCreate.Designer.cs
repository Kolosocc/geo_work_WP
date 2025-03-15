﻿// <auto-generated />
using System;
using Geo_worker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Geo_worker.Migrations
{
    [DbContext(typeof(GeoContext))]
    [Migration("20250315173848_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Geo_worker.Data.AccessLevel", b =>
                {
                    b.Property<int>("ID_AccessLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_AccessLevel"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_AccessLevel");

                    b.ToTable("AccessLevels");
                });

            modelBuilder.Entity("Geo_worker.Data.AreaCoordinate", b =>
                {
                    b.Property<int>("ID_Record")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Record"));

                    b.Property<int>("ID_Square")
                        .HasColumnType("int");

                    b.Property<int>("SquareID_Square")
                        .HasColumnType("int");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("ID_Record");

                    b.HasIndex("SquareID_Square");

                    b.ToTable("AreaCoordinates");
                });

            modelBuilder.Entity("Geo_worker.Data.Customer", b =>
                {
                    b.Property<int>("ID_Customer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Customer"));

                    b.Property<int>("CustomerTypeID_CustomerType")
                        .HasColumnType("int");

                    b.Property<int>("ID_Type")
                        .HasColumnType("int");

                    b.HasKey("ID_Customer");

                    b.HasIndex("CustomerTypeID_CustomerType");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Geo_worker.Data.CustomerType", b =>
                {
                    b.Property<int>("ID_CustomerType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_CustomerType"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_CustomerType");

                    b.ToTable("CustomerTypes");
                });

            modelBuilder.Entity("Geo_worker.Data.Employee", b =>
                {
                    b.Property<int>("ID_Employee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Employee"));

                    b.Property<int>("ID_Position")
                        .HasColumnType("int");

                    b.Property<string>("Passport")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PositionID_Position")
                        .HasColumnType("int");

                    b.HasKey("ID_Employee");

                    b.HasIndex("Passport")
                        .IsUnique();

                    b.HasIndex("PositionID_Position");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Geo_worker.Data.Equipment", b =>
                {
                    b.Property<int>("ID_Equipment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Equipment"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID_Equipment");

                    b.HasIndex("SerialNumber")
                        .IsUnique();

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("Geo_worker.Data.Picket", b =>
                {
                    b.Property<int>("ID_Picket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Picket"));

                    b.Property<int>("ID_Profile")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Picket");

                    b.HasIndex("ID_Profile");

                    b.ToTable("Pickets");
                });

            modelBuilder.Entity("Geo_worker.Data.PicketCoordinate", b =>
                {
                    b.Property<int>("ID_Record")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Record"));

                    b.Property<int>("ID_Picket")
                        .HasColumnType("int");

                    b.Property<int>("PicketID_Picket")
                        .HasColumnType("int");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("ID_Record");

                    b.HasIndex("PicketID_Picket");

                    b.ToTable("PicketCoordinates");
                });

            modelBuilder.Entity("Geo_worker.Data.Point", b =>
                {
                    b.Property<int>("ID_Point")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Point"));

                    b.Property<double>("Amendments")
                        .HasColumnType("float");

                    b.Property<DateTime>("Datetime")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentID_Equipment")
                        .HasColumnType("int");

                    b.Property<int>("ID_Equipment")
                        .HasColumnType("int");

                    b.Property<int>("ID_Operator")
                        .HasColumnType("int");

                    b.Property<int>("ID_Picket")
                        .HasColumnType("int");

                    b.Property<int>("OperatorID_Employee")
                        .HasColumnType("int");

                    b.Property<double>("SignalAnomaly")
                        .HasColumnType("float");

                    b.Property<double>("TransitioAmplitude")
                        .HasColumnType("float");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("ID_Point");

                    b.HasIndex("EquipmentID_Equipment");

                    b.HasIndex("ID_Picket");

                    b.HasIndex("OperatorID_Employee");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("Geo_worker.Data.Position", b =>
                {
                    b.Property<int>("ID_Position")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Position"));

                    b.Property<int>("AccessLevelID_AccessLevel")
                        .HasColumnType("int");

                    b.Property<int>("ID_AccessLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("ID_Position");

                    b.HasIndex("AccessLevelID_AccessLevel");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Geo_worker.Data.Profile", b =>
                {
                    b.Property<int>("ID_Profile")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Profile"));

                    b.Property<int>("ID_Square")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SquareID_Square")
                        .HasColumnType("int");

                    b.HasKey("ID_Profile");

                    b.HasIndex("SquareID_Square");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Geo_worker.Data.ProfileCoordinate", b =>
                {
                    b.Property<int>("ID_Record")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Record"));

                    b.Property<int>("ID_Profile")
                        .HasColumnType("int");

                    b.Property<int>("ProfileID_Profile")
                        .HasColumnType("int");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("ID_Record");

                    b.HasIndex("ProfileID_Profile");

                    b.ToTable("ProfileCoordinates");
                });

            modelBuilder.Entity("Geo_worker.Data.Project", b =>
                {
                    b.Property<int>("ID_Project")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Project"));

                    b.Property<int>("CustomerID_Customer")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeID_Employee")
                        .HasColumnType("int");

                    b.Property<int>("ID_Customer")
                        .HasColumnType("int");

                    b.Property<int>("ID_Employee")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Project");

                    b.HasIndex("CustomerID_Customer");

                    b.HasIndex("EmployeeID_Employee");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Geo_worker.Data.Report", b =>
                {
                    b.Property<int>("ID_Report")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Report"));

                    b.Property<int>("ID_Employee")
                        .HasColumnType("int");

                    b.Property<int>("ID_Project")
                        .HasColumnType("int");

                    b.Property<string>("ReportFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Report");

                    b.HasIndex("ID_Employee");

                    b.HasIndex("ID_Project");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Geo_worker.Data.Square", b =>
                {
                    b.Property<int>("ID_Square")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_Square"));

                    b.Property<int>("Alitude")
                        .HasColumnType("int");

                    b.Property<int>("ID_Project")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectID_Project")
                        .HasColumnType("int");

                    b.HasKey("ID_Square");

                    b.HasIndex("ProjectID_Project");

                    b.ToTable("Squares");
                });

            modelBuilder.Entity("Geo_worker.Data.AreaCoordinate", b =>
                {
                    b.HasOne("Geo_worker.Data.Square", "Square")
                        .WithMany()
                        .HasForeignKey("SquareID_Square")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Square");
                });

            modelBuilder.Entity("Geo_worker.Data.Customer", b =>
                {
                    b.HasOne("Geo_worker.Data.CustomerType", "CustomerType")
                        .WithMany()
                        .HasForeignKey("CustomerTypeID_CustomerType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomerType");
                });

            modelBuilder.Entity("Geo_worker.Data.Employee", b =>
                {
                    b.HasOne("Geo_worker.Data.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID_Position")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Geo_worker.Data.Picket", b =>
                {
                    b.HasOne("Geo_worker.Data.Profile", "Profile")
                        .WithMany("Pickets")
                        .HasForeignKey("ID_Profile")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Geo_worker.Data.PicketCoordinate", b =>
                {
                    b.HasOne("Geo_worker.Data.Picket", "Picket")
                        .WithMany()
                        .HasForeignKey("PicketID_Picket")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Picket");
                });

            modelBuilder.Entity("Geo_worker.Data.Point", b =>
                {
                    b.HasOne("Geo_worker.Data.Equipment", "Equipment")
                        .WithMany()
                        .HasForeignKey("EquipmentID_Equipment")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geo_worker.Data.Picket", "Picket")
                        .WithMany()
                        .HasForeignKey("ID_Picket")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geo_worker.Data.Employee", "Operator")
                        .WithMany()
                        .HasForeignKey("OperatorID_Employee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Equipment");

                    b.Navigation("Operator");

                    b.Navigation("Picket");
                });

            modelBuilder.Entity("Geo_worker.Data.Position", b =>
                {
                    b.HasOne("Geo_worker.Data.AccessLevel", "AccessLevel")
                        .WithMany()
                        .HasForeignKey("AccessLevelID_AccessLevel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccessLevel");
                });

            modelBuilder.Entity("Geo_worker.Data.Profile", b =>
                {
                    b.HasOne("Geo_worker.Data.Square", "Square")
                        .WithMany()
                        .HasForeignKey("SquareID_Square")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Square");
                });

            modelBuilder.Entity("Geo_worker.Data.ProfileCoordinate", b =>
                {
                    b.HasOne("Geo_worker.Data.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileID_Profile")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Geo_worker.Data.Project", b =>
                {
                    b.HasOne("Geo_worker.Data.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID_Customer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Geo_worker.Data.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID_Employee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Geo_worker.Data.Report", b =>
                {
                    b.HasOne("Geo_worker.Data.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("ID_Employee")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Geo_worker.Data.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ID_Project")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Geo_worker.Data.Square", b =>
                {
                    b.HasOne("Geo_worker.Data.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectID_Project")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Geo_worker.Data.Profile", b =>
                {
                    b.Navigation("Pickets");
                });
#pragma warning restore 612, 618
        }
    }
}
