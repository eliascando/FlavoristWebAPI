using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;
using System.Text;

namespace Infraestructure.Authorization.Jwt
{
    public static class JwtConfig
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    Debug.WriteLine($"Secret: {configuration["Jwt:Secret"]}");
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";
                                var result = JsonConvert.SerializeObject(new { error = "Token Expired", message = "The token has expired." });
                                return context.Response.WriteAsync(result);
                            }
                            else
                            {
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";
                                var result = JsonConvert.SerializeObject(new { error = "Invalid Token", message = "The token is invalid." });
                                return context.Response.WriteAsync(result);
                            }
                        },
                        OnChallenge = context =>
                        {
                            // Si no hay token en la solicitud
                            if (!context.Request.Headers.ContainsKey("Authorization"))
                            {
                                context.HandleResponse();
                                context.Response.StatusCode = 401;
                                context.Response.ContentType = "application/json";
                                var result = JsonConvert.SerializeObject(new { error = "No Token", message = "No token was provided." });
                                return context.Response.WriteAsync(result);
                            }

                            context.HandleResponse();
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                            var defaultResult = JsonConvert.SerializeObject(new { error = "Unauthorized", message = "Missing, invalid or expired token" });
                            return context.Response.WriteAsync(defaultResult);
                        },
                        OnTokenValidated = context =>
                        {
                            var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
                            if (claimsIdentity != null)
                            {
                                foreach (var claim in claimsIdentity.Claims)
                                {
                                    Debug.WriteLine($"Claim Type: {claim.Type} - Claim Value: {claim.Value}");
                                }
                            }

                            return Task.CompletedTask;
                        },
                    };
                });
            return services;
        }
    }
}
