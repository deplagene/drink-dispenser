using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DrinkDispenser.Application.Commands.VendingMachines;

public class Create
{
    public sealed record Request(string Model) : IRequest<VendingMachine>;

    public sealed class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Model)
                .NotEmpty()
                .WithMessage("Model can't be empty");
        }
    }

    public sealed class Handler(
        IWriteVendingMachineRepository repository,
        IUnitOfWork unitOfWork) : IRequestHandler<Request, VendingMachine>
    {
        public async Task<VendingMachine> Handle(Request request, CancellationToken cancellationToken)
        {
            var vendingMachine = VendingMachine.Create(request.Model);

            await repository
                .AddAsync(vendingMachine, cancellationToken);

            await unitOfWork
                .SaveChangesAsync(cancellationToken);

            return vendingMachine;
        }
    }
}