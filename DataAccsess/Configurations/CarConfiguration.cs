using Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasOne(c => c.User)
               .WithMany(u => u.Cars)
               .HasForeignKey(c => c.UserId);

        builder.HasData(
            new Car
            {
                Id = 1,
                Model = "718",
                TotalPrice = 50000,
                Color = "Red",
                Wheel = "Alloy",
                WheelColor = "Silver",
                InteriorLeather = "Black",
                Seats = "Leather",
                LightsAndVision = true,
                ExteriorDecalsAndLogos = false,
                ExteriorPackages = true,
                AssistanceSystems = true,
                InteriorComfort = true,
                AudioAndCommunication = true,
                UserId = 1
            },
            new Car
            {
                Id = 2,
                Model = "911",
                TotalPrice = 60000,
                Color = "Blue",
                Wheel = "Steel",
                WheelColor = "Black",
                InteriorLeather = "Beige",
                Seats = "Cloth",
                LightsAndVision = true,
                ExteriorDecalsAndLogos = true,
                ExteriorPackages = false,
                AssistanceSystems = false,
                InteriorComfort = true,
                AudioAndCommunication = true,
                UserId = 2
            }
        );;
    }
}