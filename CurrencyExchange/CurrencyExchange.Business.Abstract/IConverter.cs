namespace CurrencyExchange.Business.Abstract;

using CurrencyExchange.Repository.Abstract.Dto;

public interface IConverter
{
    Task<int> ConvertCurrencyExchangeAsync(CurrencyDto? initialData, List<ExchangeRateInfoDto> exchangeRateList);
}