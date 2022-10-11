namespace CurrencyExchange.Business.helper;

public static class ConverterRules
{
    public static decimal RoundDecimal(decimal value)
    {
        return Math.Round(value, 4, MidpointRounding.AwayFromZero);
    }
    
    public static int RoundInt(decimal value)
    {
        return (int)Math.Round(value, 0);
    }
}