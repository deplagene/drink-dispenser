namespace DrinkDispenser.Domain.Common.Models;

public class Entity { }

public class Entity<TKey> : Entity
    where TKey : IEquatable<TKey>
{
    public TKey? Id { get; private set; }
}