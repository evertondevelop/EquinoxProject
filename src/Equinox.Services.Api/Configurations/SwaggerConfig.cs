using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Equinox.Services.Api.Configurations
{
    /// <summary>
    /// This class contains extension methods for configuring Swagger for the Equinox API.
    /// </summary>
    public static class SwaggerConfig
    {
        /// <summary>
        /// Adds Swagger services to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add Swagger services to.</param>
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                // Configures the Swagger document for the Equinox API.
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Equinox Project",
                    Description = "Equinox API Swagger surface",
                    Contact = new OpenApiContact { Name = "Eduardo Pires", Email = "contato@eduardopires.net.br", Url = new Uri("http://www.eduardopires.net.br") },
                    License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://github.com/EduardoPires/EquinoxProject/blob/master/LICENSE") }
                });

                // Configures the security definition for the Swagger document.
                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Input the JWT like: Bearer {your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                // Configures the security requirement for the Swagger document.
                s.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });
        }

        /// <summary>
        /// Configures Swagger middleware for the specified IApplicationBuilder.
        /// </summary>
        /// <param name="app">The IApplicationBuilder to configure Swagger middleware for.</param>
        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            // Enables Swagger middleware to serve Swagger documents.
            app.UseSwagger();

            // Configures Swagger UI middleware to display Swagger documents.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });
        }
    }
}
