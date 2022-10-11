namespace CurrencyExchange.Test.modelMock;

using System;
using System.Collections.Generic;
using Repository.Abstract.Dto;

public static class DtoMockTest
{
    public static CurrencyDto GetCurrencyDto()
    {
        return new CurrencyDto()
        {
            Amount = 550,
            FromCurrency = "EUR",
            ToCurrency = "JPY",
        };
    }
    
    public static List<ExchangeRateInfoDto> GetExchangeRateInfoDto()
    {
        return new List<ExchangeRateInfoDto>()
        {
            new()
            {
                BaseCurrency = "AUD",
                ExchangeRate = Convert.ToDecimal(0.9661),
                TargetCurrency = "CHF"
            },
            new()
            {
                BaseCurrency = "JPY",
                ExchangeRate = Convert.ToDecimal(13.1151),
                TargetCurrency = "KRW"
            },            new()
            {
                BaseCurrency = "EUR",
                ExchangeRate = Convert.ToDecimal(1.2053),
                TargetCurrency = "CHF"
            },            new()
            {
                BaseCurrency = "AUD",
                ExchangeRate = Convert.ToDecimal(86.0305),
                TargetCurrency = "JPY"
            },            new()
            {
                BaseCurrency = "EUR",
                ExchangeRate = Convert.ToDecimal(1.2989),
                TargetCurrency = "USD"
            },            new()
            {
                BaseCurrency = "JPY",
                ExchangeRate = Convert.ToDecimal(0.6571),
                TargetCurrency = "INR"
            },
        };
    }
}