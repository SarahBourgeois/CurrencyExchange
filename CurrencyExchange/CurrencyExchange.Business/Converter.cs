using CurrencyExchange.Business.helper;

namespace CurrencyExchange.Business;

using UI.consoleUI;
using UI.constant;
using Abstract;
using CurrencyExchange.Repository.Abstract.Dto;
using Microsoft.Extensions.Logging;

public class Converter : IConverter
{
    // > DFS : Depth First Search better alogrithm to use
    // https://www.koderdojo.com/blog/depth-first-search-algorithm-in-csharp-and-net-core   
    // --------------------------------------
    
    private readonly ILogger<IConverter> _logger;

    public Converter(ILogger<IConverter> logger) =>_logger = logger;

    private static decimal _amount;
    private Dictionary<string?, List<string?>> _graph;

    /// <summary>
    /// Build graph for all rates
    /// </summary>
    /// <param name="exchangeRateList"></param>
    private void ConstructGraph(List<ExchangeRateInfoDto> exchangeRateList)
    {
        if (_graph != null)
            return;

        _graph = new Dictionary<string?, List<string?>>();

        foreach (var rate in exchangeRateList.Where(rate => rate.BaseCurrency != null && rate.TargetCurrency != null))
        {
            if (!_graph.ContainsKey(rate.BaseCurrency))
                _graph[rate.BaseCurrency] = new List<string?>();
            if (!_graph.ContainsKey(rate.TargetCurrency))
                _graph[rate.TargetCurrency] = new List<string?>();

            _graph[rate.BaseCurrency].Add(rate.TargetCurrency);
            _graph[rate.TargetCurrency].Add(rate.BaseCurrency);
        }
    }

    /// <summary>
    /// Allow to through the graph
    /// </summary>
    /// <param name="baseCode"></param>
    /// <param name="targetCode"></param>
    /// <param name="exhangeRateList"></param>
    /// <returns></returns>
    private decimal Rate(string baseCode, string targetCode, List<ExchangeRateInfoDto> exhangeRateList)
    {
        if (_graph[baseCode].Contains(targetCode))
        {
            return GetRelevantRate(baseCode, targetCode, exhangeRateList);
        }
        // check if the can is convertible to the target
        foreach (var code in _graph[baseCode])
        {
            var rate = Rate(code, targetCode, exhangeRateList);
            if (rate != 0) // combine with returned rate
                return rate * GetRelevantRate(baseCode, code, exhangeRateList);
        }

        return 0; // the baseCurrency is not convertible to the targetCurrency
    }
    
    /// <summary>
    /// Get relevant rate from the list
    /// </summary>
    /// <param name="baseCode"></param>
    /// <param name="targetCode"></param>
    /// <param name="exhangeRateList"></param>
    /// <returns></returns>
    public decimal GetRelevantRate(string? baseCode, string? targetCode, List<ExchangeRateInfoDto> exhangeRateList)
    {
        var rate = exhangeRateList.SingleOrDefault(r => r.BaseCurrency == baseCode && r.TargetCurrency == targetCode);
        var rateInvert = exhangeRateList.SingleOrDefault(r => r.BaseCurrency == targetCode && r.TargetCurrency == baseCode);

        if (rate == null)
            return _amount *= ConverterRules.RoundDecimal(1 / rateInvert!.ExchangeRate);
        
        return _amount *= ConverterRules.RoundDecimal(rate.ExchangeRate);
    }

    /// <summary>
    /// Main method to convert currency from one to another 
    /// </summary>
    /// <param name="initialData"></param>
    /// <param name="exchangeRateList"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<int> ConvertCurrencyExchangeAsync(CurrencyDto? initialData, List<ExchangeRateInfoDto> exchangeRateList)
    {
        try {
            _logger.LogDebug("Currency conversion started");

            if (initialData == null)
            {
                _logger.LogError("Initial data is null");
                throw new ArgumentNullException(nameof(initialData));
            }

            _amount = initialData.Amount;
            var baseCode = initialData.FromCurrency;
            var targetCode = initialData.ToCurrency;

            ConstructGraph(exchangeRateList);
            Rate(baseCode, targetCode, exchangeRateList);

            _logger.LogDebug("Currency conversion finished");

            return ConverterRules.RoundInt(_amount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            UiManagement.DisplayErrors(ErrorMessage.ConvertCurrencyError);
            throw;
        }
    }
}