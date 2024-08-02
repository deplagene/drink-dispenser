using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Repositories;
using DrinkDispenser.Errors;
using MediatR;

namespace DrinkDispenser.Application.Commands.VendingMachines;

public class Delete
{
    public sealed record Request(Guid Id) : IRequest<Guid>;

    public sealed class Handler(
        IVendingMachineRepository repository,
        IUnitOfWork unitOfWork) : IRequestHandler<Request, Guid>
    {
        public async Task<Guid> Handle(Request request, CancellationToken cancellationToken)
        {
            var vendingMachine = await repository
                .GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new NotFoundException("Автомат не найден");

            repository
                .Remove(vendingMachine);

            await unitOfWork
                .SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}