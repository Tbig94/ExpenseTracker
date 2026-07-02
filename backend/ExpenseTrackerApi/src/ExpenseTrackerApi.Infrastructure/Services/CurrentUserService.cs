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
            //var claim = _httpContextAccessor.HttpContext?.User.Claims
            //  .First().Value;

            //return Guid.TryParse(claim, out var id)
            //  ? id
            //      : throw new UnauthorizedAccessException("Nem azonosított felhasználó.");
            return new Guid("AAAAAAAA-0000-0000-0000-000000000001");
        }
    }
}
