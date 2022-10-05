namespace CurrencyExchange.Business.Abstract;

public interface IWorker
{
    public Task RunAsync(string[] args);
}