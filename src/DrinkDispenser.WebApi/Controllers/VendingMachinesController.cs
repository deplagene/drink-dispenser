using DrinkDispenser.Application.Services.VendingMachinesService;
using DrinkDispenser.Contracts.Coins;
using DrinkDispenser.Contracts.Drinks;
using DrinkDispenser.Domain.Coins;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDispenser.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class VendingMachinesController : ControllerBase
{
    private readonly IVendingMachineService _vendingMachineService;

    public VendingMachinesController(IVendingMachineService vendingMachineService)
    {
        _vendingMachineService = vendingMachineService;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateVendingMachine( CancellationToken cancellationToken)
    {
        var vendingMachine = await _vendingMachineService.CreateVendingMachine(cancellationToken);
        return vendingMachine.IsError ? BadRequest(vendingMachine.Errors) : Ok();
    }

    [HttpPost("{vendingMachineId}/coins")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> AddCoinToVendingMachine(Guid vendingMachineId, [FromBody]CoinRequest request, CancellationToken cancellationToken)
    {
        var vendingMachine = await _vendingMachineService.AddCoinToVendingMachine(vendingMachineId, request.Nominal, request.Currency, cancellationToken);
        return vendingMachine.IsError ? BadRequest(vendingMachine.Errors) : Ok();
    }

    [HttpPost("{vendingMachineId}/drinks")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddDrinkToVendingMachine(
        Guid vendingMachineId,
        [FromBody] DrinkRequest request,
        CancellationToken cancellationToken)
    {
        var vendingMachine = await _vendingMachineService.AddDrinkToVendingMachine(
            vendingMachineId,
            request.Name,
            request.Price,
            request.ImageUrl,
            cancellationToken);

        return vendingMachine.IsError ? BadRequest(vendingMachine.Errors) : Ok();
    }

    [HttpPost("{vendingMachineId}/drinks/{drinkId}")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> BuyDrink(Guid vendingMachineId, Guid drinkId, CancellationToken cancellationToken)
    {
        var vendingMachine = await _vendingMachineService.BuyDrink(vendingMachineId, drinkId, cancellationToken);
        return vendingMachine.IsError ? BadRequest(vendingMachine.Errors) : Ok();
    }
}