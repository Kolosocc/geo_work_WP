using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Geo_worker.Data
{
    public class GeoContext : DbContext
    {
        public DbSet<AccessLevel> AccessLevels { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Picket> Pickets { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<AreaCoordinate> AreaCoordinates { get; set; }
        public DbSet<ProfileCoordinate> ProfileCoordinates { get; set; }
        public DbSet<PicketCoordinate> PicketCoordinates { get; set; }
        public DbSet<Report> Reports { get; set; }

        // Параметрический конструктор для поддержки EF
        public GeoContext(DbContextOptions<GeoContext> options) : base(options) { }

        // Параметрless конструктор для поддержки миграций
        public GeoContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GNMLSRG\\SQLEXPRESS;Database=GEO;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Указываем первичные ключи для всех сущностей
            modelBuilder.Entity<AccessLevel>().HasKey(a => a.ID_AccessLevel);
            modelBuilder.Entity<Position>().HasKey(p => p.ID_Position);
            modelBuilder.Entity<Employee>().HasKey(e => e.ID_Employee);
            modelBuilder.Entity<CustomerType>().HasKey(c => c.ID_CustomerType);
            modelBuilder.Entity<Customer>().HasKey(c => c.ID_Customer);
            modelBuilder.Entity<Equipment>().HasKey(e => e.ID_Equipment);
            modelBuilder.Entity<Project>().HasKey(p => p.ID_Project);
            modelBuilder.Entity<Square>().HasKey(s => s.ID_Square);
            modelBuilder.Entity<Profile>().HasKey(p => p.ID_Profile);
            modelBuilder.Entity<Picket>().HasKey(p => p.ID_Picket);
            modelBuilder.Entity<Point>().HasKey(p => p.ID_Point);
            modelBuilder.Entity<AreaCoordinate>().HasKey(a => a.ID_Record);
            modelBuilder.Entity<ProfileCoordinate>().HasKey(p => p.ID_Record);
            modelBuilder.Entity<PicketCoordinate>().HasKey(p => p.ID_Record);
            modelBuilder.Entity<Report>().HasKey(r => r.ID_Report);

            modelBuilder.Entity<Employee>().HasIndex(e => e.Passport).IsUnique();
            modelBuilder.Entity<Equipment>().HasIndex(e => e.SerialNumber).IsUnique();

            modelBuilder.Entity<Picket>()
                .HasOne(p => p.Profile)
                .WithMany(pr => pr.Pickets)
                .HasForeignKey(p => p.ID_Profile)
                .OnDelete(DeleteBehavior.Restrict); // Здесь меняем каскад на Restrict

            modelBuilder.Entity<Point>()
                .HasOne(p => p.Picket)
                .WithMany()
                .HasForeignKey(p => p.ID_Picket)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Project)
                .WithMany()
                .HasForeignKey(r => r.ID_Project)
                .OnDelete(DeleteBehavior.Restrict); // Здесь меняем каскад на Restrict

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Employee)
                .WithMany()
                .HasForeignKey(r => r.ID_Employee)
                .OnDelete(DeleteBehavior.Restrict); // Для Employee тоже Restrictade);
        }

    }

    public class AccessLevel
    {
        public int ID_AccessLevel { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Position
    {
        public int ID_Position { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int ID_AccessLevel { get; set; }
        public AccessLevel AccessLevel { get; set; }
    }

    public class Employee
    {
        public int ID_Employee { get; set; }
        public string Passport { get; set; }
        public int ID_Position { get; set; }
        public Position Position { get; set; }
    }

    public class CustomerType
    {
        public int ID_CustomerType { get; set; }
        public string Description { get; set; }
    }

    public class Customer
    {
        public int ID_Customer { get; set; }
        public int ID_Type { get; set; }
        public CustomerType CustomerType { get; set; }
    }

    public class Equipment
    {
        public int ID_Equipment { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
    }

    public class Project
    {
        public int ID_Project { get; set; }
        public string Name { get; set; }
        public int ID_Customer { get; set; }
        public Customer Customer { get; set; }
        public int ID_Employee { get; set; }
        public Employee Employee { get; set; }
    }

    public class Square
    {
        public int ID_Square { get; set; }
        public string Name { get; set; }
        public int Alitude { get; set; }
        public int ID_Project { get; set; }
        public Project Project { get; set; }
    }

    public class Profile
    {
        public int ID_Profile { get; set; }
        public string Name { get; set; }
        public int ID_Square { get; set; }
        public Square Square { get; set; }
        public List<Picket> Pickets { get; set; }
    }

    public class Picket
    {
        public int ID_Picket { get; set; }
        public string Name { get; set; }
        public int ID_Profile { get; set; }
        public Profile Profile { get; set; }
    }

    public class Point
    {
        public int ID_Point { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double TransitioAmplitude { get; set; }
        public double SignalAnomaly { get; set; }
        public double Amendments { get; set; }
        public DateTime Datetime { get; set; }
        public int ID_Operator { get; set; }
        public Employee Operator { get; set; }
        public int ID_Equipment { get; set; }
        public Equipment Equipment { get; set; }
        public int ID_Picket { get; set; }
        public Picket Picket { get; set; }
    }

    public class AreaCoordinate
    {
        public int ID_Record { get; set; }
        public int ID_Square { get; set; }
        public Square Square { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class ProfileCoordinate
    {
        public int ID_Record { get; set; }
        public int ID_Profile { get; set; }
        public Profile Profile { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class PicketCoordinate
    {
        public int ID_Record { get; set; }
        public int ID_Picket { get; set; }
        public Picket Picket { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Report
    {
        public int ID_Report { get; set; }
        public int ID_Employee { get; set; }
        public Employee Employee { get; set; }
        public int ID_Project { get; set; }
        public Project Project { get; set; }
        public string ReportFile { get; set; }
    }
}
