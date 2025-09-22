using Microsoft.EntityFrameworkCore;
using Web.Spa.Api.Domain;
using Web.Spa.Api.Infrastructure;
using Web.Spa.Api.Services.PasswordHasher;

namespace Web.Spa.Api.Services;

public class UserService(AppDbContext db, IPasswordHasher hasher) : IUserService
{
    public async Task<User> CreateAsync(
        string username,
        string email,
        string password,
        CancellationToken ct
    )
    {
        var exists = await db.Users.AnyAsync(u => u.Email == email || u.Username == username, ct);
        if (exists)
            throw new InvalidOperationException("User with same username or email already exists");
        if (password.Length < 8)
            throw new InvalidOperationException("Password has to be at least 8 symbols");

        var user = new User
        {
            Username = username.Trim(),
            Email = email.Trim().ToLowerInvariant(),
            PasswordHash = hasher.Hash(password),
        };
        db.Users.Add(user);
        await db.SaveChangesAsync(ct);
        return user;
    }

    public Task<User?> FindByEmailAsync(string email, CancellationToken ct) =>
        db.Users.FirstOrDefaultAsync(u => u.Email == email.ToLower(), ct);
}
