using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace iTestApi.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(config.GetSection("Jwt:Key").Value)
        );

        services
            .AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    // ValidIssuer = config.GetSection("Jwt:Issuer").Value,
                    ValidateAudience = false,
                    // ValidAudience = config.GetSection("Jwt:Audience").Value,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey
                };
            });

        return services;
    }
}