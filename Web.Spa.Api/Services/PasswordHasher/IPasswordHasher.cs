namespace Web.Spa.Api.Services.PasswordHasher;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string hash);
}