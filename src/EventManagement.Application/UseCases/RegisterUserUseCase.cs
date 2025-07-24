using EventManagement.Application.DTOs;
using EventManagement.Application.Interfaces;

namespace EventManagement.Application.UseCases
{
    public class RegisterUserUseCase(IIdentityService identityService)
    {
        private readonly IIdentityService _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));

        public async Task<AuthReponse> ExecuteAsync(RegisterUserRequest request) => await _identityService.RegisterUserAsync(request);
    }
}