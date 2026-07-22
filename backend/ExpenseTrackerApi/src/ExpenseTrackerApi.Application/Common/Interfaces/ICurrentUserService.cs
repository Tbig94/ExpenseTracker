namespace ExpenseTrackerApi.Application.Common.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }


    string HashPassword(string password);

    bool VerifyPassword(string rawPassword, string storedHashFromDb);
}
