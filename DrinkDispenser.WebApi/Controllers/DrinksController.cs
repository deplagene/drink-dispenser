using AutoMapper;
using DrinkDispenser.Application.Services.DrinksService;
using DrinkDispenser.Contracts.Drinks;
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
        var drink = await _drinkService.CreateDrink(request.Name, request.Price, request.ImageUrl, cancellationToken);

        if (drink.IsError)
            return BadRequest(drink.Errors);

        return Ok();
    }
}