using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using QuickSnapWeb.API.Accounts;
using QuickSnapWeb.API.Pictures;
using QuickSnapWeb.API.Providers;
using System.Text;

namespace QuickSnapWeb.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTransient<IDateTimeProvider, DateTimeProvider>()
            .AddTransient<IRandomNumberProvider, RandomNumberProvider>()
            .AddTransient<IAccountService, AccountService>()
            .AddSingleton<IMemoryCache, MemoryCache>()
            .AddTransient<IHttpContextAccessor, HttpContextAccessor>()
            .AddTransient<IPicturesService, PicturesService>()
            .AddTransient<IHashProvider, HashProvider>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });

        builder.Services.AddControllers();

        var authenticationBuilder = builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        });

        authenticationBuilder.AddJwtBearer(options =>
        {
            var secret = "SuperDuperSecretKeyThatIsSoLongYouWillNeverGuessItBwahaha64Characters!";

            options.RequireHttpsMetadata = true;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "localhost",
                ValidAudience = "QuickSnap",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                ClockSkew = TimeSpan.Zero,
            };
        });

        var app = builder.Build();
        app.UseCors("AllowAll");
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
