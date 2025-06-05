using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Whisx.User.API.Middlewares;

namespace Whisx.User.API.Extensions;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        return services
            .RegisterSwagger()
            .AddExceptionHandler<ExceptionHandlingMiddleware>()
            .AddProblemDetails();
    }

    private static IServiceCollection RegisterSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Whisx User API",
                Version = "v1",
                Description = "Whisx User API which provides base user operations",
                Contact = new OpenApiContact
                {
                    Name = "Daniil Ushkan",
                    Email = "ushkndn@gmail.com",
                    Url = new Uri("https://github.com/ushkdn/Whisx")
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            x.IncludeXmlComments(xmlPath);
        });
        return services;
    }
}