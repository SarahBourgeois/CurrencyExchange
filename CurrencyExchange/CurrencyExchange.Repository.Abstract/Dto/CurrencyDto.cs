using System.Diagnostics.CodeAnalysis;

namespace CurrencyExchange.Repository.Abstract.Dto;

using System.ComponentModel.DataAnnotations;

[ExcludeFromCodeCoverage]
public class CurrencyDto
{
    public string? FromCurrency { get; init; }
    public string? ToCurrency { get; init; }
    public decimal Amount { get; init; }
}