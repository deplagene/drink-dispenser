using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;

using ErrorOr;

using FluentValidation;
using MediatR;

namespace DrinkDispenser.Application.Commands.Coins;

public class Create
{
    public sealed record Request(int Nominal) : IRequest<Coin>;

    public sealed class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Nominal)
                .GreaterThan(0)
                .WithMessage("Номинал монеты не может быть равна нулю");
        }
    }

    public sealed class Handler(
        ICoinRepository repository,
        IUnitOfWork unitOfWork) : IRequestHandler<Request, Coin>
    {
        public async Task<Coin> Handle(Request request, CancellationToken cancellationToken)
        {
            var coin = Coin.Create(request.Nominal);

            await repository.AddAsync(coin, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return coin;
        }
    }
}