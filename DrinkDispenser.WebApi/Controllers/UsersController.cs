using DrinkDispenser.Application.Services.UsersService;
using DrinkDispenser.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDispenser.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var result = await _userService.RegisterUser(request.UserName, request.Password, request.Email, cancellationToken);
        return result.IsError ? BadRequest(result.Errors) : Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, HttpContext httpContext, CancellationToken cancellationToken)
    {
        var result = await _userService.LoginUser(request.Email, request.Password, cancellationToken);

        httpContext.Response.Cookies.Append("yum-yum", result.Value.Token);

        return result.IsError ? BadRequest(result.Errors) : Ok(result.Value);
    }
}