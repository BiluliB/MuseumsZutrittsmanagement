using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    /// <summary>
    /// The valid username for authentication. This is a hardcoded example.
    /// </summary>
    private const string ValidUsername = "testuser";

    /// <summary>
    /// The valid password for authentication. This is a hardcoded example.
    /// </summary>
    private const string ValidPassword = "testpass";

    /// <summary>
    /// Authenticates a user based on the provided login credentials.
    /// </summary>
    /// <param name="login">The login credentials.</param>
    /// <returns>An IActionResult indicating success or failure of authentication.</returns>
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel login)
    {
        if (login.Username == ValidUsername && login.Password == ValidPassword)
        {
            return Ok("Anmeldung erfolgreich");
        }
        else
        {
            return Unauthorized("Ungültige Anmeldeinformationen");
        }
    }
}

/// <summary>
/// Represents the login credentials for a user.
/// </summary>
public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
