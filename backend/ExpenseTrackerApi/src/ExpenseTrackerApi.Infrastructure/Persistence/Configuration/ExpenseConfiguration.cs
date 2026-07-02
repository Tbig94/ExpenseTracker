using ExpenseTrackerApi.Domain.Entities;
using ExpenseTrackerApi.Infrastructure.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ExpenseTrackerApi.Infrastructure.Persistence.Configuration;

public class ExpenseConfiguration : BaseEntityConfiguration<Expense>
{
    public override void Configure(EntityTypeBuilder<Expense> builder)
    {
        base.Configure(builder); // ← Id, CreatedAt, UpdatedAt

        builder.ToTable("Expenses");

        builder.Property(e => e.Amount)
            .IsRequired()
            .HasPrecision(18, 2); // max 18 jegy, 2 tizedes

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(e => e.Date)
            .IsRequired();

        // User kapcsolat – ha a user törlődik, törlődnek a kiadásai is
        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Category kapcsolat – kategória törlését megakadályozzuk, ha van kiadás
        builder.HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Index a leggyakoribb szűrésekhez
        builder.HasIndex(e => new { e.UserId, e.Date });
        builder.HasIndex(e => new { e.UserId, e.CategoryId });

        builder.HasData(
            // --- User1 – 2026 június (múlt hónap) ---
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000001"), UserId = userId1, CategoryId = catFood, Amount = 12500, Description = "Heti bevásárlás", Date = new DateTime(2026, 6, 3, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000002"), UserId = userId1, CategoryId = catFood, Amount = 8300, Description = "Piaci vásárlás", Date = new DateTime(2026, 6, 10, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000003"), UserId = userId1, CategoryId = catTransport, Amount = 9500, Description = "Havi bérlet", Date = new DateTime(2026, 6, 1, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000004"), UserId = userId1, CategoryId = catEntertain, Amount = 4990, Description = "Netflix előfizetés", Date = new DateTime(2026, 6, 5, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000005"), UserId = userId1, CategoryId = catBills, Amount = 22000, Description = "Villanyszámla", Date = new DateTime(2026, 6, 8, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000006"), UserId = userId1, CategoryId = catHealth, Amount = 6500, Description = "Gyógyszerek", Date = new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000007"), UserId = userId1, CategoryId = catSport, Amount = 15000, Description = "Edzőterem bérlet", Date = new DateTime(2026, 6, 1, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000008"), UserId = userId1, CategoryId = catOther, Amount = 3200, Description = "Tollak, füzetek", Date = new DateTime(2026, 6, 20, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },

            // --- User1 – 2026 július (aktuális hónap) ---
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000009"), UserId = userId1, CategoryId = catFood, Amount = 14200, Description = "Heti bevásárlás", Date = new DateTime(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000010"), UserId = userId1, CategoryId = catFood, Amount = 5600, Description = "Étterem", Date = new DateTime(2026, 7, 5, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000011"), UserId = userId1, CategoryId = catTransport, Amount = 9500, Description = "Havi bérlet", Date = new DateTime(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000012"), UserId = userId1, CategoryId = catTransport, Amount = 4200, Description = "Taxi", Date = new DateTime(2026, 7, 3, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000013"), UserId = userId1, CategoryId = catBills, Amount = 18500, Description = "Gázszámla", Date = new DateTime(2026, 7, 2, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000014"), UserId = userId1, CategoryId = catEntertain, Amount = 12000, Description = "Koncertjegy", Date = new DateTime(2026, 7, 4, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0001-000000000015"), UserId = userId1, CategoryId = catSport, Amount = 15000, Description = "Edzőterem bérlet", Date = new DateTime(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },

            // --- User2 – 2026 június ---
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0002-000000000001"), UserId = userId2, CategoryId = catFood, Amount = 9800, Description = "Heti bevásárlás", Date = new DateTime(2026, 6, 2, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0002-000000000002"), UserId = userId2, CategoryId = catTravel, Amount = 85000, Description = "Repülőjegy", Date = new DateTime(2026, 6, 12, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0002-000000000003"), UserId = userId2, CategoryId = catTravel, Amount = 42000, Description = "Szállás", Date = new DateTime(2026, 6, 12, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0002-000000000004"), UserId = userId2, CategoryId = catHealth, Amount = 15000, Description = "Fogorvos", Date = new DateTime(2026, 6, 18, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0002-000000000005"), UserId = userId2, CategoryId = catBills, Amount = 19500, Description = "Villanyszámla", Date = new DateTime(2026, 6, 5, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },

            // --- User2 – 2026 július ---
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0002-000000000006"), UserId = userId2, CategoryId = catFood, Amount = 11200, Description = "Heti bevásárlás", Date = new DateTime(2026, 7, 1, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0002-000000000007"), UserId = userId2, CategoryId = catEntertain, Amount = 8900, Description = "Mozi + vacsora", Date = new DateTime(2026, 7, 2, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0002-000000000008"), UserId = userId2, CategoryId = catTravel, Amount = 32000, Description = "Hétvégi kirándulás", Date = new DateTime(2026, 7, 5, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate },
            new Expense { Id = Guid.Parse("eeeeeeee-0000-0000-0002-000000000009"), UserId = userId2, CategoryId = catOther, Amount = 4500, Description = "Könyvek", Date = new DateTime(2026, 7, 3, 0, 0, 0, DateTimeKind.Utc), CreatedAt = seedDate }
        );

    }
}