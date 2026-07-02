using ExpenseTrackerApi.Domain.Entities;
using ExpenseTrackerApi.Infrastructure.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ExpenseTrackerApi.Infrastructure.Persistence.Configuration;

public class BudgetConfiguration : BaseEntityConfiguration<Budget>
{
    public override void Configure(EntityTypeBuilder<Budget> builder)
    {
        base.Configure(builder); // ← Id, CreatedAt, UpdatedAt

        builder.ToTable("Budgets");

        builder.Property(b => b.LimitAmount)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(b => b.Month)
            .IsRequired();

        builder.Property(b => b.Year)
            .IsRequired();

        // User kapcsolat – ha a user törlődik, törlődnek a büdzsék is
        builder.HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Category kapcsolat – kategória törlését megakadályozzuk, ha van büdzsé
        builder.HasOne(b => b.Category)
            .WithMany()
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Unique: user + kategória + hónap + év kombinációja egyedi
        builder.HasIndex(b => new { b.UserId, b.CategoryId, b.Month, b.Year })
            .IsUnique();

        builder.HasData(

        // --- User1 – 2026 július ---
        // Élelmiszer: limit 30000, elköltve ~19800 → NearLimit
        new Budget { Id = Guid.Parse("bbbbbbbb-0000-0000-0001-000000000001"), UserId = userId1, CategoryId = catFood, LimitAmount = 30000, Month = 7, Year = 2026, CreatedAt = seedDate },
        // Közlekedés: limit 12000, elköltve 13700 → Exceeded
        new Budget { Id = Guid.Parse("bbbbbbbb-0000-0000-0001-000000000002"), UserId = userId1, CategoryId = catTransport, LimitAmount = 12000, Month = 7, Year = 2026, CreatedAt = seedDate },
        // Számlák: limit 25000, elköltve 18500 → Normal
        new Budget { Id = Guid.Parse("bbbbbbbb-0000-0000-0001-000000000003"), UserId = userId1, CategoryId = catBills, LimitAmount = 25000, Month = 7, Year = 2026, CreatedAt = seedDate },
        // Szórakozás: limit 10000, elköltve 12000 → Exceeded
        new Budget { Id = Guid.Parse("bbbbbbbb-0000-0000-0001-000000000004"), UserId = userId1, CategoryId = catEntertain, LimitAmount = 10000, Month = 7, Year = 2026, CreatedAt = seedDate },
        // Sport: limit 20000, elköltve 15000 → Normal
        new Budget { Id = Guid.Parse("bbbbbbbb-0000-0000-0001-000000000005"), UserId = userId1, CategoryId = catSport, LimitAmount = 20000, Month = 7, Year = 2026, CreatedAt = seedDate },

        // --- User1 – 2026 június (múlt hónap, összehasonlításhoz) ---
        new Budget { Id = Guid.Parse("bbbbbbbb-0000-0000-0001-000000000006"), UserId = userId1, CategoryId = catFood, LimitAmount = 30000, Month = 6, Year = 2026, CreatedAt = seedDate },
        new Budget { Id = Guid.Parse("bbbbbbbb-0000-0000-0001-000000000007"), UserId = userId1, CategoryId = catTransport, LimitAmount = 12000, Month = 6, Year = 2026, CreatedAt = seedDate },
        new Budget { Id = Guid.Parse("bbbbbbbb-0000-0000-0001-000000000008"), UserId = userId1, CategoryId = catBills, LimitAmount = 25000, Month = 6, Year = 2026, CreatedAt = seedDate },

        // --- User2 – 2026 július ---
        // Élelmiszer: limit 20000, elköltve 11200 → Normal
        new Budget { Id = Guid.Parse("bbbbbbbb-0000-0000-0002-000000000001"), UserId = userId2, CategoryId = catFood, LimitAmount = 20000, Month = 7, Year = 2026, CreatedAt = seedDate },
        // Utazás: limit 30000, elköltve 32000 → Exceeded
        new Budget { Id = Guid.Parse("bbbbbbbb-0000-0000-0002-000000000002"), UserId = userId2, CategoryId = catTravel, LimitAmount = 30000, Month = 7, Year = 2026, CreatedAt = seedDate },
        // Szórakozás: limit 10000, elköltve 8900 → NearLimit
        new Budget { Id = Guid.Parse("bbbbbbbb-0000-0000-0002-000000000003"), UserId = userId2, CategoryId = catEntertain, LimitAmount = 10000, Month = 7, Year = 2026, CreatedAt = seedDate }
    );

    }
}
