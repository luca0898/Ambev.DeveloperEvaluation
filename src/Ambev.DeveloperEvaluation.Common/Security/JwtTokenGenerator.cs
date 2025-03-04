using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ambev.DeveloperEvaluation.Common.Security;

public class JwtTokenGenerator(IConfiguration _configuration) : IJwtTokenGenerator
{
    public string GenerateToken(IUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecret = _configuration["Jwt:SecretKey"];
        _ = jwtSecret ?? throw new KeyNotFoundException("Jwt:SecretKey has not found");

        var key = Encoding.ASCII.GetBytes(jwtSecret);

        var claims = new[]
        {
           new Claim(ClaimTypes.NameIdentifier, user.Id),
           new Claim(ClaimTypes.Name, user.Username),
           new Claim(ClaimTypes.Role, user.Role)
        };

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        });

        return tokenHandler.WriteToken(token);
    }
}