using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DrinkDispenser.Application.Common.Authentication;
using DrinkDispenser.Domain.User;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DrinkDispenser.Infrastructure.Authentication;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;
    public JwtProvider(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }
    public string GenerateToken(User user)
    {
        Claim[] claims = [new Claim(ClaimTypes.Name, user.UserName), new Claim(ClaimTypes.Email, user.Email)];

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret)),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
        (
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddHours(_options.ExpressionInHours)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}