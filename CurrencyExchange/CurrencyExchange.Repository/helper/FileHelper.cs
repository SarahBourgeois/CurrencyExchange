using CurrencyExchange.UI.consoleUI;
using CurrencyExchange.UI.constant;

namespace CurrencyExchange.Repository.helper;

public static class FileHelper
{
    public static void CheckValidityOfFileValues(string[] subs)
    {
        if (subs[0].Length != 3 || subs[1].Length != 3 || subs[2] == "0")
        {
            UiManagement.DisplayErrors(ErrorMessage.FileException);
            throw new Exception();
        }
    }
}