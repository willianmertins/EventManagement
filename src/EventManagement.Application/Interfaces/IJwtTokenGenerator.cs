using System.Security.Claims;

namespace EventManagement.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(IEnumerable<Claim> claims);
    }
}
