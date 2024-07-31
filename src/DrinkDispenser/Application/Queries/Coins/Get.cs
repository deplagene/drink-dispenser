using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Errors;
using DrinkDispenser.Domain.Repositories;
using ErrorOr;
using MediatR;

namespace DrinkDispenser.Application.Queries.Coins;

public class Get
{
    public sealed record Query(Guid Id) : IRequest<ErrorOr<Coin>>;

    public sealed class Handler(IReadCoinRepository readCoinRepository) : IRequestHandler<Query, ErrorOr<Coin>>
    {
        public async Task<ErrorOr<Coin>> Handle(Query request, CancellationToken cancellationToken)
        {
            var coin = await readCoinRepository
                .GetByIdAsync(request.Id, cancellationToken);

            return coin is null ? Errors.Coins.NotFound : coin;
        }
    }
}