using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Domain.Coins;
using DrinkDispenser.Domain.Common.Abstractions;
using ErrorOr;

namespace DrinkDispenser.Application.Services.CoinsService;

public class CoinService : ICoinService
{
    private readonly ICoinRepository _coinRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CoinService(ICoinRepository coinRepository, IUnitOfWork unitOfWork)
    {
        _coinRepository = coinRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Created>> CreateCoin(int nominal, string currency, Guid vendingMachineId, CancellationToken cancellationToken = default)
    {
        var coin = Coin.Create(nominal, currency, vendingMachineId);

        await _coinRepository.AddAsync(coin.Value, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Created;

        //todo: fix coin creation
    }
}
