using ExpenseTrackerApi.Domain.Entities;
using ExpenseTrackerApi.Infrastructure.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseTrackerApi.Infrastructure.Persistence.Configuration;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder); // ← Id, CreatedAt, UpdatedAt

        builder.ToTable("Users");

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.HasIndex(u => u.Email)
            .IsUnique(); // két user nem regisztrálhat ugyanazzal az email-lel

        builder.Property(u => u.PasswordHash)
            .IsRequired();

        builder.HasData(
            new User
            {
                Id = userId1,
                Name = "Nagy Tamás",
                Email = "kiss.peter@example.com",
                PasswordHash = "AQAAAAIAAYagAAAAEHashedPasswordPlaceholder1==",
                CreatedAt = seedDate
            },
            new User
            {
                Id = userId2,
                Name = "Kiss Anna",
                Email = "nagy.anna@example.com",
                PasswordHash = "AQAAAAIAAYagAAAAEHashedPasswordPlaceholder2==",
                CreatedAt = seedDate
            });
    }
}
