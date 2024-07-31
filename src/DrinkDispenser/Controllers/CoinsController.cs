using AutoMapper;
using DrinkDispenser.Application.Commands.Coins;
using DrinkDispenser.Application.Extensions;
using DrinkDispenser.Application.Queries.Coins;
using DrinkDispenser.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDispenser.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoinsController(
    ISender sender,
    IMapper mapper) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(CoinDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CoinDto>> Create(
        [FromBody] Create.Request request,
        CancellationToken cancellationToken = default) =>
            await sender.Send(request, cancellationToken)
                .ThenAsync(mapper.Map<CoinDto>)
                .ThenDoAsync(coin =>
                    CreatedAtAction(
                        actionName: "get-coin",
                        routeValues: new { id = coin.Id },
                        value: coin
                    ));

    [HttpGet("{id:guid}", Name = "get-coin")]
    [ProducesResponseType(typeof(CoinDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<CoinDto>> Get(
        [FromRoute] Get.Query query,
        CancellationToken cancellationToken = default) =>
            await sender.Send(query, cancellationToken)
                .ThenAsync(coin => mapper.Map<CoinDto>(coin.Value));

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Guid>> Delete(
        [FromRoute] Delete.Request request,
        CancellationToken cancellationToken = default) =>
            await sender.Send(request, cancellationToken)
                .ThenAsync(_ => Ok(request.Id));
}