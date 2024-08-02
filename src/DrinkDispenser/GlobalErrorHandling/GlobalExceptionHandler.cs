using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDispenser.GlobalErrorHandling;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails
        {
            Status =StatusCodes.Status500InternalServerError,
            Title = "Упс, что-то пошло не так"
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}
