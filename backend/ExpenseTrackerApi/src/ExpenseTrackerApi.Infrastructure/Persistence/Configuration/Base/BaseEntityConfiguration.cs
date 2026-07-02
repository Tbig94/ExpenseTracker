using ExpenseTrackerApi.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpenseTrackerApi.Infrastructure.Persistence.Configuration.Base;

public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    // =====================
    // GUID konstansok
    // =====================

    // Users
    public Guid userId1 = Guid.Parse("aaaaaaaa-0000-0000-0000-000000000001");
    public Guid userId2 = Guid.Parse("aaaaaaaa-0000-0000-0000-000000000002");

    // Categories (default)
    public Guid catFood = Guid.Parse("cccccccc-0000-0000-0000-000000000001");
    public Guid catTransport = Guid.Parse("cccccccc-0000-0000-0000-000000000002");
    public Guid catEntertain = Guid.Parse("cccccccc-0000-0000-0000-000000000003");
    public Guid catBills = Guid.Parse("cccccccc-0000-0000-0000-000000000004");
    public Guid catHealth = Guid.Parse("cccccccc-0000-0000-0000-000000000005");
    public Guid catOther = Guid.Parse("cccccccc-0000-0000-0000-000000000006");

    // Categories (egyéni – user1)
    public Guid catSport = Guid.Parse("cccccccc-0000-0000-0000-000000000007");
    // Categories (egyéni – user2)
    public Guid catTravel = Guid.Parse("cccccccc-0000-0000-0000-000000000008");

    // Seed dátum
    public DateTime seedDate = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .ValueGeneratedNever();

        builder.Property(e => e.CreatedAt)
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .IsRequired(false);
    }
}
