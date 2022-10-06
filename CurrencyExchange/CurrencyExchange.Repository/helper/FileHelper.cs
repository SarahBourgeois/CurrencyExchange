namespace CurrencyExchange.Repository.helper;

using UI.consoleUI;
using UI.constant;

public static class FileHelper
{
    public static void CheckValidityOfFileValues(string[] subs)
    {
        if (subs[0].Length == 3 && subs[1].Length == 3 && subs[2] != "0") return;
        
        UiManagement.DisplayErrors(ErrorMessage.FileException);
        throw new Exception();
    }
}