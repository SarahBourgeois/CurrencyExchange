namespace CurrencyExchange.Repository;

using System.Diagnostics.CodeAnalysis;
using CurrencyExchange.Repository.Abstract;
using Microsoft.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class StartupExtension
{
    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IFileRepository, FileRepository>();
    }
}