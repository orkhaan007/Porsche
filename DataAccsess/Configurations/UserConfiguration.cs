using Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(u => u.Cars)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId);

        builder.HasData(
            new User
            {
                Id = 1,
                Salutation = "Mr.",
                Title = "Engineer",
                FirstName = "John",
                MiddleInitial = "D",
                LastName = "Doe",
                Suffix = "",
                Email = "john@example.com",
                Password = "password123",
                IsLoggedIn = false
            },
            new User
            {
                Id = 2,
                Salutation = "Ms.",
                Title = "Doctor",
                FirstName = "Jane",
                MiddleInitial = "A",
                LastName = "Smith",
                Suffix = "",
                Email = "jane@example.com",
                Password = "password456",
                IsLoggedIn = false
            }
        );
    }
}