using DrinkDispenser.Application.Services.CoinsService;
using DrinkDispenser.Contracts.Coins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDispenser.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CoinsController : ControllerBase
{
    private readonly ICoinService _coinService;

    public CoinsController(ICoinService coinService)
    {
        _coinService = coinService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateCoin([FromBody] CoinRequestWithId request, CancellationToken cancellationToken)
    {
        var coin = await _coinService.CreateCoin(request.Nominal, request.Currency, request.Id, cancellationToken);

        return coin.IsError ? BadRequest(coin.Errors) : Ok();
    }
}