namespace CurrencyExchange.Business.Abstract;

public interface IWorker
{
    Task RunAsync(string[] args);
}