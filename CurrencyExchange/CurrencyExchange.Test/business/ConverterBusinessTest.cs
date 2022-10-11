using CurrencyExchange.Business;
using CurrencyExchange.Business.Abstract;
using CurrencyExchange.Test.modelMock;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace CurrencyExchange.Test.business;

public class ConverterBusinessTest
{
    [Fact]
    public void ConvertCurrency_ThenReturnRightValue()
    {
        var currencyDtoMock = DtoMockTest.GetCurrencyDto();
        var exchangeListDtoMock = DtoMockTest.GetExchangeRateInfoDto();
        var logger = new Mock<ILogger<IConverter>>();

        // arrange
        var converterBusiness = new Converter(logger.Object);

        // act
        int result = converterBusiness.ConvertCurrencyExchangeAsync(currencyDtoMock, exchangeListDtoMock).Result;

        // assert
        Assert.Equal(55128, result);
        
    }
}