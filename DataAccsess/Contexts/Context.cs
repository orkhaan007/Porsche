#nullable disable
using Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace DataAccess.Contexts;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var ConStr = new ConfigurationManager()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("DefaultConnection");

        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(ConStr);
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<Car> Cars { get; set; }
    public virtual DbSet<InsurancePolicy> InsurancePolicies { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<Sale> Sales { get; set; }
    public virtual DbSet<ServiceRecord> ServiceRecords { get; set; }
    public virtual DbSet<User> Users { get; set; }
}
