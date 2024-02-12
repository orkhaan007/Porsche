using Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InsurancePolicyConfiguration : IEntityTypeConfiguration<InsurancePolicy>
{
    public void Configure(EntityTypeBuilder<InsurancePolicy> builder)
    {
        builder.HasOne(ip => ip.Car)
               .WithMany()
               .HasForeignKey(ip => ip.CarId);

        builder.HasData(
            new InsurancePolicy { Id = 1, CarId = 1, InsuranceCompany = "ABC Insurance", StartDate = DateTime.Now.AddYears(-1), EndDate = DateTime.Now.AddYears(1), Premium = 500 },
            new InsurancePolicy { Id = 2, CarId = 2, InsuranceCompany = "XYZ Insurance", StartDate = DateTime.Now.AddMonths(-6), EndDate = DateTime.Now.AddMonths(6), Premium = 600 }
        );
    }
}