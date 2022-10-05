namespace CurrencyExchange.Repository;

using Abstract;
using Abstract.Dto;
using Microsoft.Extensions.Logging;

public class FileRepository : IFileRepository
{
    private readonly ILogger<IFileRepository> _logger;

    public FileRepository(ILogger<IFileRepository> logger) => _logger = logger;

    /// <summary>
    /// Allow to parse the file content from the file input provide in parameter
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>Dictionary of CurrencyDto and List of ExchangeRateInfoDto></returns>
    /// <exception cref="FileNotFoundException"></exception>
    /// <exception cref="ParsingException"></exception>
    public Task<Dictionary<CurrencyDto, List<ExchangeRateInfoDto>>> ParseFileAsync(string filePath)
    {
        _logger.LogDebug("process to parse file", filePath);

        if (!File.Exists(filePath))
        {
            _logger.LogCritical("File not found", filePath);
            throw new FileNotFoundException();
        }

        var relevantDeviceDataFromFile = new Dictionary<CurrencyDto, List<ExchangeRateInfoDto>>();
        var conversionInfoList = new List<ExchangeRateInfoDto>();

        try
        {
            // take device conversion information
            var deviceInfoFromFile = File.ReadLines(filePath).First();
            CurrencyDto currency = MapDeviceToConvert(NormalizeFileContent(deviceInfoFromFile));

            // take number of conversion value we have from file 
            int.TryParse(File.ReadLines(filePath).Skip(1).Take(2).First(), out var numberOfConversion);

            // take only conversion values info to iterate
            var conversionInfoFromFile = File.ReadLines(filePath).Skip(2).Take(numberOfConversion);
            conversionInfoList.AddRange(conversionInfoFromFile.Select(line => NormalizeFileContent(line)).Select(exchangeLine => MapConversionInfo(exchangeLine)));

            relevantDeviceDataFromFile.Add(currency, conversionInfoList);

            return Task.FromResult(relevantDeviceDataFromFile);
        }
        catch (Exception e)
        {
            _logger.LogCritical("Error while parsing file", e);
            throw new FileLoadException();
        }
    }

    private static string[] NormalizeFileContent(string fileLine) => fileLine.Split(';');

    private static CurrencyDto MapDeviceToConvert(string[] subs)
    {
        return new CurrencyDto
        {
            FromCurrency = subs[0],
            Amount = decimal.Parse(subs[1]),
            ToCurrency = subs[2]
        };
    }

    private static ExchangeRateInfoDto MapConversionInfo(string[] subs)
    {
        return new ExchangeRateInfoDto
        {
            BaseCurrency = subs[0],
            ExchangeRate = decimal.Parse(subs[2]),
            TargetCurrency = subs[1]
        };
    }
}