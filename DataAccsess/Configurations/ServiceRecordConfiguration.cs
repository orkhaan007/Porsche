using Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ServiceRecordConfiguration : IEntityTypeConfiguration<ServiceRecord>
{
    public void Configure(EntityTypeBuilder<ServiceRecord> builder)
    {
        builder.HasOne(sr => sr.Car)
               .WithMany()
               .HasForeignKey(sr => sr.CarId);

        builder.HasData(
            new ServiceRecord { Id = 1, CarId = 1, ServiceDate = DateTime.Now, ServiceType = "Oil Change", Description = "Regular oil change", Cost = 50 },
            new ServiceRecord { Id = 2, CarId = 1, ServiceDate = DateTime.Now.AddDays(-30), ServiceType = "Tire Rotation", Description = "Tire rotation service", Cost = 30 },
            new ServiceRecord { Id = 3, CarId = 2, ServiceDate = DateTime.Now.AddDays(-60), ServiceType = "Brake Inspection", Description = "Brake inspection service", Cost = 80 }
        );
    }
}