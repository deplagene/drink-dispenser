using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Errors;
using DrinkDispenser.Domain.Repositories;
using ErrorOr;
using MediatR;

namespace DrinkDispenser.Application.Commands.Drinks;

public class Delete
{
    public sealed record Request(Guid Id) : IRequest<ErrorOr<Guid>>;

    public sealed class Handler(
        IDrinkRepository repository,
        IUnitOfWork unitOfWork) : IRequestHandler<Request, ErrorOr<Guid>>
    {
        public async Task<ErrorOr<Guid>> Handle(Request request, CancellationToken cancellationToken)
        {
            var drink = await repository.GetByIdAsync(request.Id, cancellationToken);

            if(drink is null)
                return Errors.Drinks.NotFound;

            repository.Remove(drink);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}