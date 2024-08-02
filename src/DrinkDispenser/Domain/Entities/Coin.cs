using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.ValueObjects;

namespace DrinkDispenser.Domain.Entities;

public class Coin : Entity<Guid>
{
    private Coin() { }
    private Coin(Nominal nominal)
    {
        Nominal = nominal;
    }

    public Nominal Nominal { get; private set; } = null!;

    public VendingMachine VendingMachine { get; private set; } = null!;

    public Guid? VendingMachineId { get; private set; }

    public static Coin Create(int nominal)
    {
        return new Coin(Nominal.Create(nominal));
    }
}