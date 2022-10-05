namespace CurrencyExchange.UI.consoleUI;

using constant;
using Repository.Abstract.Dto;

public static class UiManagement
{
    /// <summary>
    /// Display the main title of the application
    /// </summary>
    public static void DisplayGreetingTitle()
    {

        Console.WriteLine(" ██╗     ██╗   ██╗ ██████╗ ██████╗ █████╗      ██████╗██╗   ██╗██████╗ ██████╗ ███████╗███╗   ██╗ ██████╗██╗   ██╗)");
        Console.WriteLine(" ██║     ██║   ██║██╔════╝██╔════╝██╔══██╗    ██╔════╝██║   ██║██╔══██╗██╔══██╗██╔════╝████╗  ██║██╔════╝╚██╗ ██╔╝");
        Console.WriteLine(" ██║     ██║   ██║██║     ██║     ███████║    ██║     ██║   ██║██████╔╝██████╔╝█████╗  ██╔██╗ ██║██║      ╚████╔╝ ");
        Console.WriteLine("  ██║     ██║   ██║██║     ██║     ██╔══██║    ██║     ██║   ██║██╔══██╗██╔══██╗██╔══╝  ██║╚██╗██║██║       ╚██╔╝  ");
        Console.WriteLine(" ███████╗╚██████╔╝╚██████╗╚██████╗██║  ██║    ╚██████╗╚██████╔╝██║  ██║██║  ██║███████╗██║ ╚████║╚██████╗   ██║   ");
        Console.WriteLine(" ╚══════╝ ╚═════╝  ╚═════╝ ╚═════╝╚═╝  ╚═╝     ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝   ╚═╝   ");
        Console.WriteLine("");
        Console.WriteLine(" ██████╗ ██████╗ ███████╗███████╗███████╗███████╗██████╗ ███████╗██████╗ ███████╗██████╗ ███████╗███████╗██████╗ ");
        Console.WriteLine("");
        Console.WriteLine(Display.GreetingText);

    }

    /// <summary>
    /// Display the information from file
    /// </summary>
    /// <param name="currencyDto"></param>
    public static void DisplayCurrencyExchangeExcpectation(CurrencyDto currencyDto)
    {
        Console.WriteLine("You want to convert : ");
        Console.WriteLine($"{currencyDto.FromCurrency} to {currencyDto.ToCurrency}");
        Console.WriteLine($"This exchange is for an amount of : {currencyDto.Amount}");
        Console.WriteLine("Please, if it's not correct, change the information from you file input");
    }

    /// <summary>
    /// display result of the conversion
    /// </summary>
    /// <param name="result"></param>
    /// <param name="currencyDto"></param>
    public static void DisplayResult(int result, CurrencyDto currencyDto)
    {
        Console.WriteLine($"The result of your conversion from {currencyDto.FromCurrency} to {currencyDto.ToCurrency} is : {result} !!! ");
    }

    public static void QuitApplication()
    {
        Console.WriteLine("Process is now finished.");
        Console.WriteLine("Press any key to quit the application");
        Console.ReadKey();
    }
}