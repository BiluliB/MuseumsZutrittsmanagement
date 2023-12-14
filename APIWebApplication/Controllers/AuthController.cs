using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    // Beispiel für hartcodierte Anmeldeinformationen
    private const string ValidUsername = "testuser";
    private const string ValidPassword = "testpass";

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

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
