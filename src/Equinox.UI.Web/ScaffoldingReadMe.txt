// Added support for ASP.NET Core Identity to the project.
// This feature enables user management, including authentication,
// authorization, and user data protection.
//
// To set up and configure ASP.NET Core Identity, refer to the official
// Microsoft documentation at the following link:
// https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-5.0&tabs=visual-studio
//
// The documentation covers various aspects of Identity setup, such as:
// 1. Adding Identity services
// 2. Configuring Identity options
// 3. Setting up user interface for user management

services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Configure Identity options here
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();
