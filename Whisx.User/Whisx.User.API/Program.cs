using Serilog;
using Whisx.Logger;
using Whisx.Shared.Configurations;
using Whisx.User.API.Extensions;
using Whisx.User.Application.Extensions;

namespace Whisx.User.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.AddEnvFiles("whisx.user.api.env");

        var logger = SerilogFactory.CreateLogger(builder.Services, builder.Configuration);

        builder.Host.UseSerilog(logger);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddPresentationLayer();
        builder.Services.AddApplicationLayer();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.RoutePrefix = string.Empty;
                x.SwaggerEndpoint("/swagger/v1/swagger.json", string.Empty);
            });
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseSerilogRequestLogging();

        app.UseExceptionHandler();

        app.MapControllers();

        app.Run();
    }
}