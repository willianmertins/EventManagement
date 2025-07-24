using EventManagement.Application.DTOs;
using EventManagement.Application.Interfaces;

namespace EventManagement.Application.UseCases
{
    public class LoginUserUseCase(IIdentityService identityService)
    {
        private readonly IIdentityService _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));

        public async Task<AuthReponse> ExecuteAsync(LoginRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request), "Login request cannot be null.");

            return await _identityService.LoginAsync(request);
        }
    }
}
