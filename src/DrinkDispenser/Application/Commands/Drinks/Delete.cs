using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Repositories;
using DrinkDispenser.Errors;
using MediatR;

namespace DrinkDispenser.Application.Commands.Drinks;

public class Delete
{
    public sealed record Request(Guid Id) : IRequest<Guid>;

    public sealed class Handler(
        IDrinkRepository repository,
        IUnitOfWork unitOfWork) : IRequestHandler<Request, Guid>
    {
        public async Task<Guid> Handle(Request request, CancellationToken cancellationToken)
        {
            var drink = await repository
                .GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new NotFoundException("Напиток не найден");

            repository.Remove(drink);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}