using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Whisx.Shared.Configurations;

public static class AppsettingsFilesLoader
{
    public static IConfigurationBuilder AddAppsettingsFiles(this IConfigurationBuilder configurationBuilder, IHostEnvironment environment)
    {
        return configurationBuilder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.Logger.json", optional: false, reloadOnChange: true);
    }
}