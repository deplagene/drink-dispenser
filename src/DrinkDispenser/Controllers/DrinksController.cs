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
    public async Task<ActionResult<Guid>> Delete(
        [FromRoute]Delete.Request request,
        CancellationToken cancellationToken = default) =>
            await sender.Send(request, cancellationToken)
            .ThenAsync(_ => Ok(request.Id));

    [HttpGet("{id:guid}", Name = "get-drink")]
    public async Task<ActionResult<DrinkDto>> Get(
        [FromRoute] Get.Query query,
        CancellationToken cancellationToken = default) =>
            await sender.Send(query, cancellationToken)
            .ThenAsync(drink => mapper.Map<DrinkDto>(drink.Value));
}