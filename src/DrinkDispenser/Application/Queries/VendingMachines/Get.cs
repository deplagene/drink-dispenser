using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Errors;
using DrinkDispenser.Domain.Repositories;
using ErrorOr;
using MediatR;

namespace DrinkDispenser.Application.Queries.VendingMachines;

public class Get
{
    public sealed record Query(Guid Id) : IRequest<ErrorOr<VendingMachine>>;

    public sealed class Handler(IReadVendingMachineRepository repository) : IRequestHandler<Query, ErrorOr<VendingMachine>>
    {
        public async Task<ErrorOr<VendingMachine>> Handle(Query request, CancellationToken cancellationToken)
        {
            var vendingMachine = await repository
                .GetByIdAsync(request.Id, cancellationToken);

            return vendingMachine is null ? Errors.VendingMachines.NotFound : vendingMachine;
        }
    }
}