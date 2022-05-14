using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Vulder.School.IntegrationTests.Fixtures;

public static class FakeJwtTokenGenerator
{
    public static string GetToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.PrimarySid, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, "example@example.com"),
                new Claim(ClaimTypes.Role, "0")
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Issuer = "https://localhost:7064",
            Audience = "https://localhost:7064",
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("5/uz/woZ35g67OtxkcDdOg==")
                ),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}