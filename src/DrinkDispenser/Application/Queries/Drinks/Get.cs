using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using MediatR;

namespace DrinkDispenser.Application.Queries.Drinks;

public class Get
{
    public sealed record Query(Guid Id) : IRequest<Drink>;

    public sealed class Handler(IReadDrinkRepository repository) : IRequestHandler<Query, Drink>
{
        public async Task<Drink> Handle(Query request, CancellationToken cancellationToken)
        {
            var drink = await repository
                .GetByIdAsync(request.Id, cancellationToken);

            return drink;
        }
    }
}