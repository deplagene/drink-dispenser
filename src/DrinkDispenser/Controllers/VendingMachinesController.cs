using AutoMapper;
using DrinkDispenser.Application.Commands.VendingMachines;
using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Application.Extensions;
using DrinkDispenser.Application.Queries.VendingMachines;
using DrinkDispenser.Shared.Dtos;
using DrinkDispenser.Shared.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDispenser.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendingMachinesController(
    ISender sender,
    IMapper mapper,
    IVendingMachinesService vendingMachinesService) : ControllerBase
{
    [HttpPost(Name = "create-vendingMachine")]
    [ProducesResponseType(typeof(VendingMachineDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VendingMachineDto>> Create(
        [FromBody] Create.Request request,
        CancellationToken cancellationToken = default) =>
            await sender.Send(request, cancellationToken)
            .ThenAsync(mapper.Map<VendingMachineDto>)
            .ThenDoAsync(vendingMachine => CreatedAtAction(
                "get-vendingMachine",
                new { id = vendingMachine.Id },
                vendingMachine
            ));


    [HttpGet("{id:guid}", Name = "get-vendingMachine")]
    [ProducesResponseType(typeof(VendingMachineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<VendingMachineDto>> Get(
        [FromRoute] Get.Query query,
        CancellationToken cancellationToken = default) =>
            await sender.Send(query, cancellationToken)
            .ThenAsync(mapper.Map<VendingMachineDto>);

    [HttpDelete("{id:guid}", Name = "delete-vendingMachine")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Guid>> Delete(
        [FromRoute]Delete.Request request,
        CancellationToken cancellationToken = default) =>
            await sender.Send(request, cancellationToken)
            .ThenAsync(_ => Ok(request.Id));

    [HttpPost("{id:guid}/drinks", Name = "add-drink-to-vendingMachine")]
    [ProducesResponseType(typeof(VendingMachineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<VendingMachineDto> AddDrink([FromRoute]Guid id, [FromBody]AddDrinkRequest request, CancellationToken cancellationToken = default) =>
        await vendingMachinesService
            .AddDrink(id, request.DrinkId, cancellationToken)
            .ThenAsync(mapper.Map<VendingMachineDto>);


    [HttpGet("{id:guid}/drinks/{drinkId:guid}", Name = "buy-drink")]
    [ProducesResponseType(typeof(DrinkDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<DrinkDto> BuyDrink([FromRoute]Guid id,[FromRoute]Guid drinkId, CancellationToken cancellationToken = default) =>
        await vendingMachinesService
            .BuyDrink(id, drinkId, cancellationToken)
            .ThenAsync(mapper.Map<DrinkDto>);

    [HttpPost("{id:guid}/coins", Name = "add-coin-to-vendingMachine")]
    [ProducesResponseType(typeof(VendingMachineDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<VendingMachineDto> AddCoin([FromRoute]Guid id, [FromBody] AddCoinRequest request, CancellationToken cancellationToken = default) =>
        await vendingMachinesService
            .AddCoin(
                vendingMachineId: id,
                coinId: request.CoinId,
                cancellationToken)
            .ThenAsync(mapper.Map<VendingMachineDto>);
}