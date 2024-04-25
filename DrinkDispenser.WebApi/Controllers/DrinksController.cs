using AutoMapper;
using DrinkDispenser.Application.Services.DrinksService;
using DrinkDispenser.Contracts.Drinks;
using DrinkDispenser.Contracts.Drinks.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDispenser.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DrinksController : ControllerBase
{
    private readonly IDrinkService _drinkService;
    private readonly IMapper _mapper;

    public DrinksController(IDrinkService drinkService, IMapper mapper)
    {
        _drinkService = drinkService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDrink([FromBody] DrinkRequest request, CancellationToken cancellationToken)
    {
        var drink = await _drinkService.CreateDrink(request.Name, request.Price, request.ImageUrl, request.VendingMachineId, cancellationToken);

        if (drink.IsError)
            return BadRequest(drink.Errors);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetDrinks(CancellationToken cancellationToken)
    {
        var drinks = await _drinkService.GetAllDrinks(cancellationToken);

        if (drinks.IsError)
            return BadRequest(drinks.Errors);

        return Ok(drinks.Value);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableDrinks(CancellationToken cancellationToken)
    {
        var drinks = await _drinkService.GetAvailableDrinks(cancellationToken);

        if (drinks.IsError)
            return BadRequest(drinks.Errors);

        return Ok(drinks.Value);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDrinkById(Guid id, CancellationToken cancellationToken)
    {
        var drink = await _drinkService.GetDrinkById(id, cancellationToken);

        if (drink.IsError)
            return BadRequest(drink.Errors);

        return Ok(drink.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDrink(Guid id, CancellationToken cancellationToken)
    {
        var drink = await _drinkService.DeleteDrink(id, cancellationToken);

        if (drink.IsError)
            return BadRequest(drink.Errors);

        return Ok();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateDrink(Guid DrinkId,[FromBody] DrinkPatchRequest request, CancellationToken cancellationToken)
    {
        var drink = await _drinkService.UpdateDrink(DrinkId, request.Name, request.Price, request.ImageUrl, cancellationToken);

        if (drink.IsError)
            return BadRequest(drink.Errors);

        return Ok();
    }

    [HttpPatch("{id}/availability")]
    public async Task<IActionResult> UpdateDrinkAvailability(Guid drinkId, [FromBody] bool? isAvailable, CancellationToken cancellationToken)
    {
        var drink = await _drinkService.UpdateDrinkAvailability(drinkId, isAvailable, cancellationToken);

        if (drink.IsError)
            return BadRequest(drink.Errors);

        return Ok();
    }
}