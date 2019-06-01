using AutoMapper;
using CRM.API.Models;
using CRM.API.Services;
using CRM.API.ViewModels.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
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
            logger.LogInformation("Someone tries to login.");

            logger.LogDebug("ModelState.IsValid: " + ModelState.IsValid);

            if (ModelState.IsValid)
            {
                // Retrieve user by email or username
                User currentUser = await userManager.FindByEmailAsync(model.EmailOrUsername) ?? await userManager.FindByNameAsync(model.EmailOrUsername);

                // If no user is found by email or username, just return unauthorized and give nothing away of existing user info
                if (currentUser == null)
                {
                    return Unauthorized();
                }

                // Log the user in by password
                var result = await signInManager.PasswordSignInAsync(currentUser, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    logger.LogInformation("User " + currentUser.UserName + " logged in.");

                    // Retrieve roles of user
                    currentUser.Roles = (List<string>)await userManager.GetRolesAsync(currentUser);

                    // Set claims of user
                    List<Claim> claims = new List<Claim>() {
                        new Claim(JwtRegisteredClaimNames.NameId, currentUser.Id),
                        new Claim(JwtRegisteredClaimNames.UniqueName, currentUser.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, currentUser.Email),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.CurrentCulture))
                    };
                    if (!string.IsNullOrEmpty(currentUser.FirstName))
                    {
                        claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, currentUser.FirstName));
                    }
                    if (!string.IsNullOrEmpty(currentUser.LastName))
                    {
                        claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, currentUser.LastName));
                    }

                    // Add roles as claims
                    foreach (var role in currentUser.Roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }

                    // Authentication successful => Generate jwt token
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(configuration.GetSection("Authentication").GetValue<string>("Secret"));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.UtcNow.AddMinutes(double.Parse(configuration.GetSection("Authentication").GetValue<string>("TokenExpiresInMinutes"))),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)    
                    };

                    // Return user with token
                    return Ok(new AuthenticatedVM()
                    {
                        User = mapper.Map<User, UserVM>(currentUser),
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
        [Route("me")]
        public async Task<IActionResult> Me()
        {
            User currentUser = await userManager.GetUserAsync(User);

            // Retrieve roles of user
            currentUser.Roles = (List<string>)await userManager.GetRolesAsync(currentUser);

            return Ok(mapper.Map<User, UserVM>(currentUser));
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Lockout()
        {
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        [Authorize(Roles = "Admin")]
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

                    // When self registering and login at the same time
                    // Need to add JWT logic if adding
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