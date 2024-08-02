using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Repositories;
using DrinkDispenser.Errors;
using MediatR;

namespace DrinkDispenser.Application.Commands.Coins;

public class Delete
{
    public sealed record Request(Guid Id) : IRequest<Guid>;

    public sealed class Handler(
        ICoinRepository repository,
        IUnitOfWork unitOfWork) : IRequestHandler<Request, Guid>
    {
        public async Task<Guid> Handle(Request request, CancellationToken cancellationToken)
        {
            var coin = await repository
                .GetByIdAsync(request.Id, cancellationToken)
                    ?? throw new NotFoundException("Монета не найдена");

            repository.Remove(coin);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return request.Id;
        }
    }
}
