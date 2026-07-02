using ExpenseTrackerApi.Domain.Entities;
using ExpenseTrackerApi.Infrastructure.Persistence.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseTrackerApi.Infrastructure.Persistence.Configuration;

public class CategoryConfiguration : BaseEntityConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder); // ← Id, CreatedAt, UpdatedAt

        builder.ToTable("Categories");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.Color)
            .IsRequired()
            .HasMaxLength(7);

        builder.Property(c => c.IsDefault)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(c => c.UserId)
            .IsRequired(false);

        builder.HasIndex(c => new { c.UserId, c.Name })
            .IsUnique()
            .HasFilter("[UserId] IS NOT NULL");

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasData(
        // --- Rendszer kategóriák (IsDefault = true, UserId = null) ---
        new Category { Id = catFood, Name = "Élelmiszer", Color = "#4CAF50", IsDefault = true, UserId = null, CreatedAt = seedDate },
        new Category { Id = catTransport, Name = "Közlekedés", Color = "#2196F3", IsDefault = true, UserId = null, CreatedAt = seedDate },
        new Category { Id = catEntertain, Name = "Szórakozás", Color = "#9C27B0", IsDefault = true, UserId = null, CreatedAt = seedDate },
        new Category { Id = catBills, Name = "Számlák", Color = "#F44336", IsDefault = true, UserId = null, CreatedAt = seedDate },
        new Category { Id = catHealth, Name = "Egészség", Color = "#FF9800", IsDefault = true, UserId = null, CreatedAt = seedDate },
        new Category { Id = catOther, Name = "Egyéb", Color = "#607D8B", IsDefault = true, UserId = null, CreatedAt = seedDate },
        // --- User1 egyéni kategória ---
        new Category { Id = catSport, Name = "Sport", Color = "#00BCD4", IsDefault = false, UserId = userId1, CreatedAt = seedDate },

        // --- User2 egyéni kategória ---
        new Category { Id = catTravel, Name = "Utazás", Color = "#FF5722", IsDefault = false, UserId = userId2, CreatedAt = seedDate }

        );
    }
}
