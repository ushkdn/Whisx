using DotNetEnv;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Whisx.Shared.Configurations;

public static class DotEnvLoader
{
    public static IHostBuilder AddEnvFiles(this IHostBuilder hostBuilder, string envFileName)
    {
        hostBuilder.ConfigureAppConfiguration
        (
            (hostingContext, config) =>
            {
                config.ParseAndLoadDotEnvFiles(envFileName);
            }
        );

        return hostBuilder;
    }

    private static IConfigurationBuilder ParseAndLoadDotEnvFiles(this IConfigurationBuilder configurationBuilder, string envFileName)
    {
        var projectPath = Directory.GetCurrentDirectory();
        var envFilePath = Path.Combine(projectPath, envFileName);

        if (File.Exists(envFilePath))
        {
            Env.Load(envFilePath);
        }
        else
        {
            throw new FileNotFoundException("Unable to find configuration file with environment variables (.env) via specified path");
        }

        configurationBuilder.AddEnvironmentVariables();

        return configurationBuilder;
    }
}