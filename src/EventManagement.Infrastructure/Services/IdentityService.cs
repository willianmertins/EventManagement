using EventManagement.Application.DTOs;
using EventManagement.Application.Interfaces;
using EventManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EventManagement.Infrastructure.Services
{
    public class IdentityService(UserManager<ApplicationUser> userManager, IJwtTokenGenerator tokenGenerator)
        : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;

        public async Task<AuthReponse> LoginAsync(LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Email);
            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return new AuthReponse(false, string.Empty, ["Invalid email or password."]);
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Email, user.Email!),
                new(ClaimTypes.Name, user.UserName!)
            };

            var token = _tokenGenerator.GenerateToken(claims);
            return new AuthReponse(true, token, []);
        }

        public async Task<AuthReponse> RegisterUserAsync(RegisterUserRequest request)
        {
            if (await _userManager.FindByEmailAsync(request.Email) is not null)
            {
                return new AuthReponse(false, string.Empty, ["Email already in use."]);
            }

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email
            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return new AuthReponse(false, string.Empty, [.. result.Errors.Select(e => e.Description)]);
        
            return await LoginAsync(new LoginRequest(request.Email, request.Password));
        }
    }
}
