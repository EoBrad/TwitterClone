using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace TwitterClone.Services.Configuration;

public static class AddJwtAuthenticationConfiguration
{
    public static void AddJwtSecurity(this IServiceCollection service)
    {
        service.AddAuthorization();
        service.AddAuthentication(x => 
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt => 
        {
            opt.TokenValidationParameters = new TokenValidationParameters() 
            {
                ValidateActor = false,
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("b300e09abfe7da79b8a4578ad58914ee16ded32b")),
            };
        });
    }
}
