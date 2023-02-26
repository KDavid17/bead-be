using BeadBE.Api.Common.Errors;
using BeadBE.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddPresentation (this IServiceCollection services)
    {
        services.AddMappings();

        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, BeadProblemDetailsFactory>();

        return services;
    }
}
