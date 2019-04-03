namespace Betterfly.BetterCode
{
    public interface IDeepCloneable<out TDeepCloneable>
    {
        TDeepCloneable DeepClone();
    }
}