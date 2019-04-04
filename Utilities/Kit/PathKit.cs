namespace Betterfly.BetterCode
{
    public static class PathKit
    {
        public static string Join(params string[] element)
        {
            if (element.IsNullOrEmpty())
            {
                return string.Empty;
            }
            return element.JoinString("/");
        }
    }
}