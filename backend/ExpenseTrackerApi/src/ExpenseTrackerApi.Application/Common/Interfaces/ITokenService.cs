using ExpenseTrackerApi.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace ExpenseTrackerApi.Application.Common.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
