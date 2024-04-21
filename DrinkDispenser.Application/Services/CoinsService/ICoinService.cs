using DrinkDispenser.Domain.Coins;
using ErrorOr;

namespace DrinkDispenser.Application.Services.CoinsService;

public interface ICoinService
{
    Task<ErrorOr<Created>> CreateCoin(int nominal, string currency, CancellationToken cancellationToken = default);
}