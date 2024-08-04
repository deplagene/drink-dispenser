using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DrinkDispenser.Application.Queries.VendingMachines;

public class GetAvailableDrinks
{
    public sealed record Query(
        [FromRoute] Guid Id,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10) : IRequest<IReadOnlyCollection<Drink>>;

    public sealed class Handler(
        IReadVendingMachineRepository repository) : IRequestHandler<Query, IReadOnlyCollection<Drink>>
    {
        public async Task<IReadOnlyCollection<Drink>> Handle(Query query, CancellationToken cancellationToken) =>
            await repository
                .GetAvailableDrinksAsync(query.Id, query.page, query.pageSize, cancellationToken);
    }
}