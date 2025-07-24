namespace EventManagement.Application.DTOs
{
    public record RegisterUserRequest(string Email, string Password);
    public record LoginRequest(string Email, string Password);
    public record AuthReponse(bool Succeeded, string Token, string[] Errors);
}
