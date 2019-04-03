namespace Betterfly.BetterCode
{
    public interface ICloneable<out TCloneable>
    {
        TCloneable Clone();
    }
}