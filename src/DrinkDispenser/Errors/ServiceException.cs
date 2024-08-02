namespace DrinkDispenser.Errors;

public class ServiceException(int statusCode, string message)  : Exception(message)
{
    public int StatusCode { get; } = statusCode;
}