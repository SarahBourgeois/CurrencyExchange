namespace CurrencyExchange;

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

[ExcludeFromCodeCoverage]
public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        BuildConfiguration(builder);

        // Serilog logger configuration from appsettings.json
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Build())
            .Enrich.FromLogContext()
            .WriteTo.Console(theme: SystemConsoleTheme.Colored)
            .CreateLogger();

        // host builder configuration and configures services for dependancy injection
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((context, services) =>
            {
                var startup = new Startup();
                startup.ConfigureServices(services);
            })
            .UseSerilog()
            .Build();

        var svc = ActivatorUtilities.CreateInstance<Worker>(host.Services);
        await svc.RunAsync(args);
    }

    private static void BuildConfiguration(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile(
                $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json",
                optional: true);
    }
}