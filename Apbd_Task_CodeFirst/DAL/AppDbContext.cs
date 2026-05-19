using System.Reflection;
using Apbd_Task_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Apbd_Task_CodeFirst.DAL;

public class AppDbContext : DbContext
{
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    public DbSet<PCComponents> PCComponents { get; set; }
    public DbSet<PCs> PCs { get; set; }
    public DbSet<Components> Components { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=task7;user=sa;password=YourStrong!123;trustServerCertificate=true");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<ComponentManufacturers>().HasData(
            new ComponentManufacturers
                { Id = 1, Abbreviation = "APL", FullName = "Apple", FoundationDate = new DateOnly(1976, 4, 1) },
            new ComponentManufacturers
                { Id = 2, Abbreviation = "INT", FullName = "Intel", FoundationDate = new DateOnly(1968, 7, 18) },
            new ComponentManufacturers
                { Id = 3, Abbreviation = "NVD", FullName = "Nvidia", FoundationDate = new DateOnly(1993, 4, 5) },
            new ComponentManufacturers
            {
                Id = 4, Abbreviation = "AMD", FullName = "Advanced Micro Devices",
                FoundationDate = new DateOnly(1969, 5, 1)
            },
            new ComponentManufacturers
            {
                Id = 5, Abbreviation = "SSG", FullName = "Samsung Electronics",
                FoundationDate = new DateOnly(1969, 1, 13)
            }
        );

        modelBuilder.Entity<ComponentTypes>().HasData(
            new ComponentTypes { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentTypes { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentTypes { Id = 3, Abbreviation = "RAM", Name = "Memory" },
            new ComponentTypes { Id = 4, Abbreviation = "SSD", Name = "Solid State Drive" },
            new ComponentTypes { Id = 5, Abbreviation = "MB", Name = "Motherboard" }
        );

        modelBuilder.Entity<Components>().HasData(
            new Components
            {
                Code = "CPU0000001", Name = "Intel i7", Description = "Processor", ComponentManufacturerId = 2,
                ComponentTypeId = 1
            },
            new Components
            {
                Code = "GPU0000001", Name = "RTX 4070", Description = "Graphics card", ComponentManufacturerId = 3,
                ComponentTypeId = 2
            },
            new Components
            {
                Code = "RAM0000001", Name = "16GB RAM", Description = "Memory module", ComponentManufacturerId = 1,
                ComponentTypeId = 3
            },
            new Components
            {
                Code = "CPU0000002", Name = "Ryzen 7", Description = "Processor", ComponentManufacturerId = 4,
                ComponentTypeId = 1
            },
            new Components
            {
                Code = "GPU0000002", Name = "Radeon RX", Description = "Graphics card", ComponentManufacturerId = 4,
                ComponentTypeId = 2
            },
            new Components
            {
                Code = "SSD0000001", Name = "Samsung SSD", Description = "Storage drive", ComponentManufacturerId = 5,
                ComponentTypeId = 4
            },
            new Components
            {
                Code = "SSD0000002", Name = "Apple SSD", Description = "Storage drive", ComponentManufacturerId = 1,
                ComponentTypeId = 4
            },
            new Components
            {
                Code = "MB00000001", Name = "Intel Board", Description = "Motherboard", ComponentManufacturerId = 2,
                ComponentTypeId = 5
            }
        );

        modelBuilder.Entity<PCs>().HasData(
            new PCs
            {
                Id = 1, Name = "Office PC", Weight = 4.5f, Warranty = 24, CreatedAt = new DateTime(2024, 1, 10),
                Stock = 10
            },
            new PCs
            {
                Id = 2, Name = "Gaming PC", Weight = 8.2f, Warranty = 36, CreatedAt = new DateTime(2024, 2, 15),
                Stock = 5
            },
            new PCs
            {
                Id = 3, Name = "Mini PC", Weight = 2.1f, Warranty = 12, CreatedAt = new DateTime(2024, 3, 20),
                Stock = 20
            },
            new PCs
            {
                Id = 4, Name = "Workstation", Weight = 11.4f, Warranty = 36, CreatedAt = new DateTime(2024, 4, 12),
                Stock = 3
            },
            new PCs
            {
                Id = 5, Name = "Creator PC", Weight = 7.6f, Warranty = 24, CreatedAt = new DateTime(2024, 5, 8),
                Stock = 7
            }
        );

        modelBuilder.Entity<PCComponents>().HasData(
            new PCComponents { PcId = 1, ComponentCode = "CPU0000001", Amount = 1 },
            new PCComponents { PcId = 1, ComponentCode = "RAM0000001", Amount = 2 },
            new PCComponents { PcId = 1, ComponentCode = "SSD0000001", Amount = 1 },
            new PCComponents { PcId = 2, ComponentCode = "CPU0000002", Amount = 1 },
            new PCComponents { PcId = 2, ComponentCode = "GPU0000001", Amount = 1 },
            new PCComponents { PcId = 2, ComponentCode = "RAM0000001", Amount = 2 },
            new PCComponents { PcId = 2, ComponentCode = "SSD0000001", Amount = 1 },
            new PCComponents { PcId = 3, ComponentCode = "RAM0000001", Amount = 1 },
            new PCComponents { PcId = 3, ComponentCode = "SSD0000002", Amount = 1 },
            new PCComponents { PcId = 4, ComponentCode = "CPU0000001", Amount = 2 },
            new PCComponents { PcId = 4, ComponentCode = "GPU0000002", Amount = 2 },
            new PCComponents { PcId = 4, ComponentCode = "MB00000001", Amount = 1 },
            new PCComponents { PcId = 5, ComponentCode = "CPU0000002", Amount = 1 },
            new PCComponents { PcId = 5, ComponentCode = "GPU0000001", Amount = 1 },
            new PCComponents { PcId = 5, ComponentCode = "SSD0000001", Amount = 2 }
        );
    }
}