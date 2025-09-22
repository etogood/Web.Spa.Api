using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Spa.Api.Contracts.Requests;
using Web.Spa.Api.Contracts.Responses;
using Web.Spa.Api.Services;
using Web.Spa.Api.Services.PasswordHasher;

namespace Web.Spa.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IUserService users, IJwtTokenService jwt) : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Register([FromBody] RegisterRequest req, CancellationToken ct)
    {
        try
        {
            var user = await users.CreateAsync(req.Username, req.Email, req.Password, ct);
            var token = jwt.CreateToken(user);
            return CreatedAtAction(nameof(Me), new { }, token);
        }
        catch (InvalidOperationException)
        {
            return Conflict(new { message = "Username or email already taken" });
        }
    }

    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest req,
        [FromServices] IPasswordHasher hasher,
        CancellationToken ct
    )
    {
        var user = await users.FindByEmailAsync(req.Email, ct);
        if (user is null)
            return Unauthorized(new { message = "Invalid email or password" });

        var ok = hasher.Verify(req.Password, user.PasswordHash);
        if (!ok)
            return Unauthorized(new { message = "Invalid email or password" });

        var token = jwt.CreateToken(user);
        return Ok(token);
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        return Ok(
            new
            {
                id = User.FindFirst("sub")?.Value,
                username = User.Identity?.Name ?? User.FindFirst("unique_name")?.Value,
                email = User.FindFirst("email")?.Value,
            }
        );
    }
}
