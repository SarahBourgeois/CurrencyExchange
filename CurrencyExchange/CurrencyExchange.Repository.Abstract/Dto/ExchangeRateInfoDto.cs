namespace CurrencyExchange.Repository.Abstract.Dto;

public class ExchangeRateInfoDto
{
    public string? BaseCurrency { get; init; }
    public string? TargetCurrency { get; init; }
    public decimal ExchangeRate { get; init; }
}