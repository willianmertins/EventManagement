using EventManagement.Application.DTOs;

namespace EventManagement.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthReponse> RegisterUserAsync(RegisterUserRequest request);
        Task<AuthReponse> LoginAsync(LoginRequest request);
    }
}
