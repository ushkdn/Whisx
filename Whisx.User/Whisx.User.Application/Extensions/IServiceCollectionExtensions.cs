using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Whisx.User.Application.Common.Behaviors;
using Whisx.User.Application.Common.Interfaces;

namespace Whisx.User.Application.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        return services
            .RegisterValidation()
            .RegisterMediatr()
            .RegisterMapping();
    }

    private static IServiceCollection RegisterValidation(this IServiceCollection services)
    {
        return services.AddValidatorsFromAssemblyContaining<IApplicationAssemblyMarker>();
    }

    private static IServiceCollection RegisterMediatr(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<IApplicationAssemblyMarker>();
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        return services;
    }

    private static IServiceCollection RegisterMapping(this IServiceCollection services)
    {
        services.AddMapster();
        return services;
    }
}