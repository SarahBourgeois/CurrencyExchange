namespace CurrencyExchange.Repository.Abstract.Dto;

public class CurrencyDto
{
    public string? FromCurrency { get; init; }
    public string? ToCurrency { get; init; }
    public decimal Amount { get; init; }
}