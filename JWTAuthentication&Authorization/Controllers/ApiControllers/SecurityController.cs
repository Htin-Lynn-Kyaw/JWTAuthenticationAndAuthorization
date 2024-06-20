using JWTAuthentication_Authorization.Models;
using JWTAuthentication_Authorization.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication_Authorization.Controllers.ApiControllers;

[Route("api/[controller]")]
[ApiController]
public class SecurityController : ControllerBase
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly AuthService _authService = new AuthService();
    private readonly ILogger<CustomAccountController> _logger;

    public SecurityController(
        ILogger<CustomAccountController> logger,
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration)
    {
        _logger = logger;
        _signInManager = signInManager;
        _userManager = userManager;
        _configuration = configuration;
    }

    [HttpPost("CustomLogin")]
    public async Task<IActionResult> CustomLogin([FromBody] LoginViewModel model)
    {
        if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
        {
            return BadRequest(new { message = "Email and password are required." });
        }

        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
        bool a =_signInManager.IsSignedIn(User);
        if (result.Succeeded)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            string token = string.Empty;

            if (user is not null)
            {
                token = _authService.GenerateToken(user);
            }
            return Ok(new { token });
        }
        if (result.RequiresTwoFactor)
        {
            return Unauthorized(new
            {
                message = "Two-factor authentication required.",
                redirectUrl = Url.Page("/Identity/Account/LoginWith2fa", new { ReturnUrl = "/", model.RememberMe })
            });
        }
        if (result.IsLockedOut)
        {
            _logger.LogWarning("User account locked out.");
            return new ObjectResult(new
            {
                message = "User account locked out.",
                redirectUrl = Url.Page("/Identity/Account/Lockout")
            })
            {
                StatusCode = StatusCodes.Status403Forbidden
            };
        }
        else
        {
            return BadRequest(new { message = "Invalid login attempt." });
        }
    }
}
