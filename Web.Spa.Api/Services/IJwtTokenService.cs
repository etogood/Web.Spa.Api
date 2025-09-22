using Web.Spa.Api.Contracts.Responses;
using Web.Spa.Api.Domain;

namespace Web.Spa.Api.Services;

public interface IJwtTokenService
{
    AuthResponse CreateToken(User user);
}
