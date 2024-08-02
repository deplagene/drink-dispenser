using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using MediatR;

namespace DrinkDispenser.Application.Queries.VendingMachines;

public class Get
{
    public sealed record Query(Guid Id) : IRequest<VendingMachine>;

    public sealed class Handler(IReadVendingMachineRepository repository) : IRequestHandler<Query, VendingMachine>
    {
        public async Task<VendingMachine> Handle(Query request, CancellationToken cancellationToken)
        {
            var vendingMachine = await repository
                .GetByIdAsync(request.Id, cancellationToken);

            return vendingMachine;
        }
    }
}