using System.Text;
using DrinkDispenser.Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DrinkDispenser.WebApi.Extensions;

public static class ApiExtensions
{
    public static void AddApiAuthentication(this IServiceCollection services,

        IConfiguration configuration)
    {
        var _jwtOptions = configuration.GetSection("JwtOptions").Get<JwtOptions>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_jwtOptions!.Secret))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["yum-yum"];
                        return Task.CompletedTask;
                    }
                };
            });

        services.AddAuthorization();
    }
}