using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace Equinox.UI.Web.Areas.Identity.Pages.Account
{
    // The RegisterModel class represents the model for the registration page.
    [AllowAnonymous] // This attribute allows unauthenticated users to access this page.
    public class RegisterModel : PageModel
    {
        // Dependency injection is used to provide the necessary services.
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        // The constructor initializes the services.
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        // The InputModel class represents the input model for the registration form.
        public InputModel Input { get; set; }

        // The ReturnUrl property holds the URL to return to after registration.
        public string ReturnUrl { get; set; }

        // The ExternalLogins property holds the list of available external login providers.
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        // The InputModel class contains the properties for email, password, and confirmation password.
        public class InputModel
        {
            // The Email property is required, must be a valid email address, and is displayed with the label "Email".
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            // The Password property is required, must be at least 6 characters long, and is displayed with the label "Password".
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            // The ConfirmPassword property is required, must match the Password property, and is displayed with the label "Confirm password".
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        // The OnGetAsync method initializes the page with the return URL and external login providers.
        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        // The OnPostAsync method handles the form submission.
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            // The ModelState.IsValid property checks if the model state is valid.
            if (ModelState.IsValid)
            {
                // Create a new user with the provided email.
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };

                // The CreateAsync method creates the user with the provided password.
                var result = await _userManager.CreateAsync(user, Input.Password);

                // If the creation was successful, sign the user in and redirect to the return URL.
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    // Add a claim for writing customer data.
                    await _userManager.AddClaimAsync(user, new Claim("Customers", "Write"));

                    // Generate an email confirmation token and send a confirmation email.
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    // If email confirmation is required, redirect to the confirmation page.
                    // Otherwise, sign the user in and redirect to the return URL.
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }

                // If the creation was not successful, add the errors to the model state and redisplay the form.
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay the form.
            return Page();
