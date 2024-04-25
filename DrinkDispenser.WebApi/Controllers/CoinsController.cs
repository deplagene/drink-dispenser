using DrinkDispenser.Application.Services.CoinsService;
using DrinkDispenser.Contracts.Coins;
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
    public async Task<IActionResult> CreateCoin([FromBody] CoinRequestWithId request, CancellationToken cancellationToken)
    {
        var coin = await _coinService.CreateCoin(request.Nominal, request.Currency, request.Id, cancellationToken);

        return coin.IsError ? BadRequest(coin.Errors) : Ok();
    }
}