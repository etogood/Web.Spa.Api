using Web.Spa.Api.Domain;

namespace Web.Spa.Api.Services;

public interface IUserService
{
    Task<User> CreateAsync(string username, string email, string password, CancellationToken ct);
    Task<User?> FindByEmailAsync(string email, CancellationToken ct);
}
