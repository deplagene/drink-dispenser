namespace DrinkDispenser.Errors;

public class BadRequestException(string message)
    : ServiceException(StatusCodes.Status400BadRequest,message)
{
}