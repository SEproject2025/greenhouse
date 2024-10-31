using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using greenhouse.Entities;
using greenhouse.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthController(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        if (loginModel == null || string.IsNullOrEmpty(loginModel.Email) || string.IsNullOrEmpty(loginModel.Password))
        {
            return BadRequest("Invalid login attempt.");
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, loginModel.Email)
            // Add other claims if needed
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, isPersistent: true, lockoutOnFailure: false);
        if (result.Succeeded)
        {
            return Ok();
        }
        else
        {
            return Unauthorized("Invalid login attempt.");
        }
    }
}

// Create a LoginModel class in your project
public class LoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}
