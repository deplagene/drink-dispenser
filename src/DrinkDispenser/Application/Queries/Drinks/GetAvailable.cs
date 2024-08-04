using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDispenser.Application.Queries.Drinks;

public class GetAvailable
{
    public sealed record Query(
        [FromQuery]int Page = 1,
        [FromQuery]int PageSize = 10) : IRequest<IReadOnlyCollection<Drink>>;

    public sealed class Handler(IReadDrinkRepository repository) : IRequestHandler<Query, IReadOnlyCollection<Drink>>
    {
        public async Task<IReadOnlyCollection<Drink>> Handle(Query request, CancellationToken cancellationToken)
        {
            var drinks = await repository
                .GetAvailableDrinksAsync(
                    request.Page,
                    request.PageSize,
                    cancellationToken);

            return drinks;
        }
    }
}