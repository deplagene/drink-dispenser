using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using MediatR;

namespace DrinkDispenser.Application.Queries.Coins;

public class Get
{
    public sealed record Query(Guid Id) : IRequest<Coin>;

    public sealed class Handler(IReadCoinRepository readCoinRepository) : IRequestHandler<Query, Coin>
    {
        public async Task<Coin> Handle(Query request, CancellationToken cancellationToken)
        {
            var coin = await readCoinRepository
                .GetByIdAsync(request.Id, cancellationToken);

            return coin;
        }
    }
}