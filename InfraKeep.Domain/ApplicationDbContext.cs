using InfraKeep.Domain.Brands;
using InfraKeep.Domain.Categories;
using InfraKeep.Domain.Employees;
using InfraKeep.Domain.EquipmentTemplates;
using InfraKeep.Domain.Locations;
using InfraKeep.Domain.Models;
using InfraKeep.Domain.Roles;
using InfraKeep.Domain.TechnicalEquipments;
using InfraKeep.Domain.TypeEquipments;
using InfraKeep.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfraKeep.Domain
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<TypeEquipment> TypeEquipments { get; set; }
        public DbSet<EquipmentTemplate> EquipmentTemplates { get; set; }
        public DbSet<TechnicalEquipment> TechnicalEquipments { get; set; }
    }
}