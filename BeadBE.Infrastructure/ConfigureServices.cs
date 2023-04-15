using BeadBE.Application.Common.Interfaces.Authentication;
using BeadBE.Application.Common.Interfaces.Persistence;
using BeadBE.Application.Common.Interfaces.Services;
using BeadBE.Infrastructure.Authentication;
using BeadBE.Infrastructure.Database;
using BeadBE.Infrastructure.Persistence;
using BeadBE.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;

namespace BeadBE.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();

        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));

        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.SectionName));

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))
                };

                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";

                        var title = "You are not authorized to view this resource!";
                        var status = StatusCodes.Status401Unauthorized;
                        var result = JsonSerializer.Serialize(new { status, title });

                        return context.Response.WriteAsync(result);
                    }
                };
            });

        services.AddDbContext<BeadContext>((serviceProvider, dbContextOptionsBuilder) =>
        {
            DatabaseOptions? databaseOptions = serviceProvider.GetService<IOptions<DatabaseOptions>>().Value;

            dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"), sqlServerAction =>
            {
                sqlServerAction.EnableRetryOnFailure(databaseOptions.MaxRetryCount);
                sqlServerAction.CommandTimeout(databaseOptions.CommandTimeout);
            });

            dbContextOptionsBuilder.EnableDetailedErrors(databaseOptions.EnableDatailedErrors);
            dbContextOptionsBuilder.EnableSensitiveDataLogging(databaseOptions.EnableSensitiveDataLogging);
        });

        services.AddHttpContextAccessor();

        services.AddSingleton<IJwtGenerator, JwtGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IHashService, HashService>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
