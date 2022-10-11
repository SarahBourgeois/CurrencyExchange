using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CurrencyExchange.Repository.Abstract.Dto;

[ExcludeFromCodeCoverage]
public class ExchangeRateInfoDto
{
    public string? BaseCurrency { get; init; }
    public string? TargetCurrency { get; init; }
    public decimal ExchangeRate { get; init; }
}