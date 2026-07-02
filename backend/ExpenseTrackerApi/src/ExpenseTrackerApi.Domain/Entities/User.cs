using ExpenseTrackerApi.Domain.Common;

namespace ExpenseTrackerApi.Domain.Entities;

public class User : BaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;

    public User() { }

    public User(string name, string email, string passwordHash)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PasswordHash = passwordHash;
        CreatedAt = DateTime.UtcNow;
    }
}
