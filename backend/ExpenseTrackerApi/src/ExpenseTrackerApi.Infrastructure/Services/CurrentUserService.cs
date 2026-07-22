using ExpenseTrackerApi.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ExpenseTrackerApi.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            var claim = _httpContextAccessor.HttpContext?.User.Claims
              .First().Value;

            return Guid.TryParse(claim, out var id)
                ? id
                : throw new UnauthorizedAccessException("Nem azonosított felhasználó.");
        }
    }

    public string HashPassword(string rawPassword)
    {
        // A workFactor (cost) alapértelmezetten 11-12, ez ma a biztonságos/optimális
        return BCrypt.Net.BCrypt.HashPassword(rawPassword, workFactor: 12);
    }

    public bool VerifyPassword(string rawPassword, string storedHashFromDb)
    {
        // A Verify automatikusan kiolvassa a sót a tárolt hash-ből
        return BCrypt.Net.BCrypt.Verify(rawPassword, storedHashFromDb);
    }
}
