namespace CurrencyExchange.Business.Abstract;

using CurrencyExchange.Repository.Abstract.Dto;

public interface IConverter
{
    Task<int> ConvertCurrencyExchangeAsync(CurrencyDto? initalData, List<ExchangeRateInfoDto> exchangeRateList);
}