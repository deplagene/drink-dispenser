using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Errors;
using DrinkDispenser.Domain.Repositories;
using ErrorOr;
using MediatR;

namespace DrinkDispenser.Application.Queries.Drinks;

public class Get
{
    public sealed record Query(Guid Id) : IRequest<ErrorOr<Drink>>;

    public sealed class Handler(IReadDrinkRepository repository) : IRequestHandler<Query, ErrorOr<Drink>>
{
        public async Task<ErrorOr<Drink>> Handle(Query request, CancellationToken cancellationToken)
        {
            var drink = await repository.GetByIdAsync(request.Id, cancellationToken);

            return drink is null ? Errors.Drinks.NotFound : drink;
        }
    }
}