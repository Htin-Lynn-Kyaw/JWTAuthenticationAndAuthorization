using JWTAuthentication_Authorization.Models;
using JWTAuthentication_Authorization.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication_Authorization.Controllers
{
    public class CustomAccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService = new AuthService();
        private readonly ILogger<CustomAccountController> _logger;

        public CustomAccountController(
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

        [HttpGet]
        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost("CustomLogin")]
        public async Task<IActionResult> CustomLogin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var returnUrl = ViewData["ReturnUrl"];
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
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
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
