using CurrencyExchange.UI.constant;

namespace CurrencyExchange.Business;

using Abstract;
using CurrencyExchange.Repository.Abstract;
using CurrencyExchange.Repository.Abstract.Dto;
using Microsoft.Extensions.Logging;
using UI.consoleUI;

public class Worker : IWorker
{
    private readonly ILogger<IWorker> _logger;
    private readonly IFileRepository _fileRepository;
    private readonly IConverter _converter;

    public Worker(ILogger<IWorker> logger, IFileRepository fileRepository, IConverter converter)
    {
        _logger = logger;
        _fileRepository = fileRepository;
        _converter = converter;
    }

    public async Task RunAsync(string[] args)
    {
        try
        {
            if (args.Length is 0 or > 1)
            {
                _logger.LogCritical("Invalid number of arguments.");
                UiManagement.DisplayErrors(ErrorMessage.ArgumentException);
                throw new Exception();
            }

            _logger.LogInformation("ProcessConversion started");

            UiManagement.DisplayGreetingTitle();

            Dictionary<CurrencyDto, List<ExchangeRateInfoDto>> parsedExchangeRateData =
                await _fileRepository.ParseFileAsync(args[0]);

            CurrencyDto? currencyDtoToConvert = parsedExchangeRateData.Keys.FirstOrDefault();
            var exchangeRateList = parsedExchangeRateData.Values.FirstOrDefault();

            if (currencyDtoToConvert is null || exchangeRateList is null)
            {
                _logger.LogCritical("Invalid input data");
                UiManagement.DisplayErrors(ErrorMessage.InvalidInputData);
                throw new Exception();
            }

            UiManagement.DisplayCurrencyExchangeExcpectation(currencyDtoToConvert);

            var result = await _converter.ConvertCurrencyExchangeAsync(currencyDtoToConvert, exchangeRateList);

            UiManagement.DisplayResult(result, currencyDtoToConvert);

            _logger.LogDebug("ProcessConversion finished");
            
            UiManagement.QuitApplication();
        }
        catch (Exception e)
        {
            _logger.LogCritical(e, "ProcessConversion failed");
            UiManagement.DisplayErrors(ErrorMessage.ProcessConversionFailed);
            throw new Exception();
        }
    }
}