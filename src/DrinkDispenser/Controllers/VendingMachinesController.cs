using AutoMapper;
using DrinkDispenser.Application.Commands.VendingMachines;
using DrinkDispenser.Application.Extensions;
using DrinkDispenser.Application.Queries.VendingMachines;
using DrinkDispenser.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDispenser.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VendingMachinesController(
    ISender sender,
    IMapper mapper) : ControllerBase
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
            .ThenAsync(vendingMachine => mapper.Map<VendingMachineDto>(vendingMachine.Value));

    [HttpDelete("{id:guid}", Name = "delete-vendingMachine")]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Guid>> Delete(
        [FromRoute]Delete.Request request,
        CancellationToken cancellationToken = default) =>
            await sender.Send(request, cancellationToken)
            .ThenAsync(_ => Ok(request.Id));
}