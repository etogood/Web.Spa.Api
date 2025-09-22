namespace Web.Spa.Api.Contracts.Responses;

public class AuthResponse
{
    public required string Token { get; init; }
    public required DateTime ExpiresAtUtc { get; init; }
}
