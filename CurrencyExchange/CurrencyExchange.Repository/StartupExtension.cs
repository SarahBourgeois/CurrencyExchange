namespace CurrencyExchange.Repository;

using System.Diagnostics.CodeAnalysis;
using Abstract;
using Microsoft.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class StartupExtension
{
    public static void AddRepository(this IServiceCollection services)
    {
        // automapper configuration
        services.AddScoped<IFileRepository, FileRepository>();
    }
}