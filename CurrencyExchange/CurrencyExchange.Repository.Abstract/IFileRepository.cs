namespace CurrencyExchange.Repository.Abstract;

using CurrencyExchange.Repository.Abstract.Dto;

public interface IFileRepository
{
    Task<Dictionary<CurrencyDto, List<ExchangeRateInfoDto>>> ParseFileAsync(string file);
}