using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Errors;
using DrinkDispenser.Domain.Repositories;
using ErrorOr;
using MediatR;

namespace DrinkDispenser.Application.Commands.Coins;

public class Delete
{
    public sealed record Request(Guid Id) : IRequest<ErrorOr<Guid>>;

    public sealed class Handler(
        ICoinRepository repository,
        IUnitOfWork unitOfWork) : IRequestHandler<Request, ErrorOr<Guid>>
    {
        public async Task<ErrorOr<Guid>> Handle(Request request, CancellationToken cancellationToken)
        {
            var coin = await repository
                .GetByIdAsync(request.Id, cancellationToken);

            if (coin is null)
                return Errors.Coins.NotFound;

            repository.Remove(coin);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
