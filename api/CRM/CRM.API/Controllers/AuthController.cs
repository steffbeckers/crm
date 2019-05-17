using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CRM.API.DAL;
using CRM.API.Models;
using CRM.API.Services;
using CRM.API.ViewModels.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CRM.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IdentityContext identityContext;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IEmailSender emailSender;
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;

        public AuthController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IEmailSender emailSender,
            ILogger<AuthController> logger,
            IConfiguration configuration,
            IMapper mapper)
        {
            this.identityContext = new IdentityContext();
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.logger = logger;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    logger.LogInformation("User logged in.");

                    // Retrieve user
                    User user = await userManager.FindByNameAsync(model.Username);

                    // Set claims of user
                    List<Claim> claims = new List<Claim>() {
                        new Claim(ClaimTypes.NameIdentifier, user.Id)
                    };

                    // Retrieve roles of user
                    var userRoleIds = this.identityContext.UserRoles.Where(ur => ur.UserId == user.Id).Select(ur => ur.RoleId).ToList();
                    List<IdentityRole> userRoles = new List<IdentityRole>();
                    foreach (string roleId in userRoleIds)
                    {
                        IdentityRole role = await this.identityContext.Roles.FindAsync(roleId);
                        userRoles.Add(role);

                        // Add role as claim
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    }
                    user.Roles = userRoles.Select(ur => ur.NormalizedName).ToArray();

                    // Authentication successful => Generate jwt token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(configuration.GetSection("Authentication").GetValue<string>("Secret"));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };

                    // Return user with token
                    return Ok(new AuthenticatedVM()
                    {
                        User = mapper.Map<User, UserVM>(user),
                        Token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor))
                    });
                }
                //if (result.RequiresTwoFactor)
                //{
                //    logger.LogInformation("Requires two factor.");
                //    return RedirectToAction(nameof(LoginWith2fa), new { returnUrl, model.RememberMe });
                //}
                if (result.IsLockedOut)
                {
                    logger.LogWarning("User account locked out.");
                    return RedirectToAction(nameof(Lockout));
                }
                else
                {
                    logger.LogWarning("Invalid login attempt.");
                    return Unauthorized();
                }
            }

            // If we got this far, something failed
            return BadRequest();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register([FromBody] RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username, Email = model.Email };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    logger.LogInformation("User created a new account with password.");

                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);

                    //await signInManager.SignInAsync(user, isPersistent: false);

                    return Ok();
                }

                AddErrors(result);
            }

            // If we got this far, something failed
            return BadRequest();
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            logger.LogInformation("User logged out.");

            return Ok();
        }

        [HttpGet]
        [Route("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return BadRequest();
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new ApplicationException($"Unable to load user with ID '{userId}'.");
            }

            var result = await userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return Ok();
            }

            AddErrors(result);

            // If we got this far, something failed
            return BadRequest();
        }

        [HttpPost]
        [Route("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return Ok();
                }

                // For more information on how to enable account confirmation and password reset please
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                // In startup: options.SignIn.RequireConfirmedEmail = true;

                var code = await userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.ResetPasswordCallbackLink(user.Id, code, Request.Scheme);

                await emailSender.SendEmailAsync(model.Email, "Reset Password",
                   $"Please reset your password by clicking here: <a href='{callbackUrl}'>link</a>");

                return Ok();
            }

            // If we got this far, something failed
            return BadRequest();
        }

        [HttpPost]
        [Route("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    return BadRequest();
                }

                var result = await userManager.ResetPasswordAsync(user, model.Code, model.Password);
                if (result.Succeeded)
                {
                    return Ok();
                }

                AddErrors(result);
            }

            return BadRequest();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        #endregion
    }
}