namespace CurrencyExchange;

using System.Diagnostics.CodeAnalysis;
using Business;
using Microsoft.Extensions.DependencyInjection;
using Repository;

[ExcludeFromCodeCoverage]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // add services here from StartupExtension
        services.AddRepository();
        services.AddBusiness();
    }
}
