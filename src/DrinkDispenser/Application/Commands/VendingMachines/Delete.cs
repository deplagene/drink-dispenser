using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Errors;
using DrinkDispenser.Domain.Repositories;
using ErrorOr;
using MediatR;

namespace DrinkDispenser.Application.Commands.VendingMachines;

public class Delete
{
    public sealed record Request(Guid Id) : IRequest<ErrorOr<Guid>>;

    public sealed class Handler(
        IVendingMachineRepository repository,
        IUnitOfWork unitOfWork) : IRequestHandler<Request, ErrorOr<Guid>>
    {
        public async Task<ErrorOr<Guid>> Handle(Request request, CancellationToken cancellationToken)
        {
            var vendingMachine = await repository
                .GetByIdAsync(request.Id, cancellationToken);

            if (vendingMachine is null)
                return Errors.VendingMachines.NotFound;

            repository
                .Remove(vendingMachine);

            await unitOfWork
                .SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}