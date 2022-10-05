namespace CurrencyExchange.Business;

using Abstract;
using CurrencyExchange.Repository.Abstract.Dto;
using Microsoft.Extensions.Logging;

public class Converter : IConverter
{
    private readonly ILogger<IConverter> _logger;

    public Converter(ILogger<IConverter> logger)
    {
        _logger = logger;
    }

    private static decimal _amount;
    private Dictionary<string, List<string>> _graph;

    /// <summary>
    /// Build graph for all rates
    /// </summary>
    /// <param name="exchangeRateList"></param>
    private void ConstructGraph(List<ExchangeRateInfoDto> exchangeRateList)
    {
        if (_graph != null)
            return;

        _graph = new Dictionary<string, List<string>>();

        foreach (var rate in exchangeRateList.Where(rate => rate.BaseCurrency != null && rate.TargetCurrency != null))
        {
            if (!_graph.ContainsKey(rate.BaseCurrency))
                _graph[rate.BaseCurrency] = new List<string>();
            if (!_graph.ContainsKey(rate.TargetCurrency))
                _graph[rate.TargetCurrency] = new List<string>();

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
    private decimal Rate(string? baseCode, string? targetCode, List<ExchangeRateInfoDto> exhangeRateList)
    {
        if (_graph[baseCode].Contains(targetCode))
        {
            return GetKnownRate(baseCode, targetCode, exhangeRateList);
        }
        // check if the can is convertible to the target
        foreach (var code in _graph[baseCode])
        {

            var rate = Rate(code, targetCode, exhangeRateList);
            if (rate != 0) // combine with returned rate
                return rate * GetKnownRate(baseCode, code, exhangeRateList);

        }

        return 0; // the baseCurrency is not convertible to the targetCurrency
    }
    public decimal GetKnownRate(string? baseCode, string? targetCode, List<ExchangeRateInfoDto> exhangeRateList)
    {
        var rate = exhangeRateList.SingleOrDefault(fr => fr.BaseCurrency == baseCode && fr.TargetCurrency == targetCode);
        var rate_invert = exhangeRateList.SingleOrDefault(fr => fr.BaseCurrency == targetCode && fr.TargetCurrency == baseCode);

        if (rate == null)
        {
            return _amount *= (1 / rate_invert.ExchangeRate);
        }
        return _amount *= rate.ExchangeRate;
    }

    public async Task<int> ConvertCurrencyExchangeAsync(CurrencyDto? initialData, List<ExchangeRateInfoDto> exchangeRateList)
    {
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


        return (int)Math.Floor(_amount);
    }

}