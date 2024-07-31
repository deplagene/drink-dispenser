using AutoMapper;
using DrinkDispenser.Application.Commands.Drinks;
using DrinkDispenser.Application.Extensions;
using DrinkDispenser.Application.Queries.Drinks;
using DrinkDispenser.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDispenser.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DrinksController(
    ISender sender,
    IMapper mapper) : ControllerBase
{
    [HttpPost(Name = "create-drink")]
    [ProducesResponseType(typeof(DrinkDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DrinkDto>> Create(
        [FromBody] Create.Request request,
        CancellationToken cancellationToken = default) =>
            await sender.Send(request, cancellationToken)
            .ThenAsync(mapper.Map<DrinkDto>)
            .ThenDoAsync(drink => CreatedAtAction
                ("get-drink",
                new { id = drink.Id },
                drink));

    [HttpDelete("{id:guid}", Name = "delete-drink")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Guid>> Delete(
        [FromRoute]Delete.Request request,
        CancellationToken cancellationToken = default) =>
            await sender.Send(request, cancellationToken)
            .ThenAsync(_ => Ok(request.Id));

    [HttpGet("{id:guid}", Name = "get-drink")]
    [ProducesResponseType(typeof(DrinkDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<DrinkDto>> Get(
        [FromRoute] Get.Query query,
        CancellationToken cancellationToken = default) =>
            await sender.Send(query, cancellationToken)
            .ThenAsync(drink => mapper.Map<DrinkDto>(drink.Value));
}