using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Library.Services.BookAPI.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder builder)
        {
            // configure api settings
            var secret = builder.Configuration.GetValue<string>("ApiSettings:Secret");
            var audience = builder.Configuration.GetValue<string>("ApiSettings:Audience");
            var issuer = builder.Configuration.GetValue<string>("ApiSettings:Issuer");

            // create key
            var key = Encoding.UTF8.GetBytes(secret);

            // add Authentication with JwtBearer
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience
                };
            });

            return builder;
        }
    }
}
