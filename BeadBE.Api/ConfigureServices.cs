using BeadBE.Api.Common;
using BeadBE.Api.Common.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Text.Json.Serialization;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddPresentation (this IServiceCollection services)
    {
        services.AddMappings();

        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, BeadProblemDetailsFactory>();

        services.AddLocalization(o => { o.ResourcesPath = "Resources"; });
        services.AddControllersWithViews()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();

        return services;
    }
}
