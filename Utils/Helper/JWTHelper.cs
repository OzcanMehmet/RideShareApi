using System.Text;
using System.Threading.Tasks;
using RideShare.Helpers;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace RideShare.Utils.Helper
{
    public static class HelperJwt
    {
        public static IServiceCollection UseJWT(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration Configuration)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings").Get<AppSettings>().Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.RequireHttpsMetadata = false;
                op.SaveToken = true;
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });
            return services;
        }
    }
}