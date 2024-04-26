namespace DrinkDispenser.Infrastructure.Authentication;

public class JwtOptions
{
    public const string SectionName = "JwtOptions";
    public string Secret { get; set; } = default!;

    public int ExpressionInHours { get; set; }
}