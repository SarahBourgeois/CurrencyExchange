namespace CurrencyExchange.Business;

using System.Diagnostics.CodeAnalysis;
using Abstract;
using Microsoft.Extensions.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class StartupExtension
{
    public static void AddBusiness(this IServiceCollection services)
    {
        services.AddScoped<IWorker, Worker>();
        services.AddScoped<IConverter, Converter>();
    }
}