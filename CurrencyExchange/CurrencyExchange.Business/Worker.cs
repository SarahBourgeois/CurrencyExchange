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
        _logger.LogInformation("ProcessConversion started");

        UiManagement.DisplayGreetingTitle();
        
        try
        {
            if (args.Length is 0 or > 1)
                args = new[] 
                {
                    UiManagement.PushUserFiles() ?? // ask for input file
                    throw new Exception()
                };
            
            if (args.Length is 0 or > 1)
            {
                UiManagement.DisplayErrors(ErrorMessage.ArgumentException);
                throw new Exception();
            }

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

            int result = await _converter.ConvertCurrencyExchangeAsync(currencyDtoToConvert, exchangeRateList);

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