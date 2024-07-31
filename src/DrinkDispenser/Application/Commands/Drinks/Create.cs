using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace DrinkDispenser.Application.Commands.Drinks;

public class Create
{
    public sealed record Request(string Name, decimal Price) : IRequest<Drink>;

    public sealed class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Имя не может быть пустым");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Цена должна быть больше нуля");
        }
    }

    public sealed class Handler(
        IWriteDrinkRepository repository,
        IUnitOfWork unitOfWork) : IRequestHandler<Request, Drink>
    {
        public async Task<Drink> Handle(Request request, CancellationToken cancellationToken)
        {
            var drink = Drink.Create(request.Name, request.Price);

            await repository.AddAsync(drink, cancellationToken);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return drink;
        }
    }
}