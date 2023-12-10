using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TwitterClone.Models;

namespace TwitterClone.Services;

public class Jwt
{
    static byte[] Key = Encoding.ASCII.GetBytes("b300e09abfe7da79b8a4578ad58914ee16ded32b");

    public static string GenerateToken(User user)
    {
        var tokenConfig = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
             new Claim("Email", user.Email),
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenGenerator = tokenHandler.CreateToken(tokenConfig);
        var token = tokenHandler.WriteToken(tokenGenerator);

        return token;
    }
}
