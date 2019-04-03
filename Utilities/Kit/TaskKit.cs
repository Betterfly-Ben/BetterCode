using System;
using System.Threading.Tasks;

namespace Betterfly.BetterCode
{
    public static class TaskKit
    {
        public static async Task WaitUntil(Func<bool> condition, int millisecondsDelay = 50)
        {
            if (condition == null)
            {
                return;
            }

            while (condition.Invoke() == false)
            {
                await Task.Delay(millisecondsDelay);
            }
        }
    }
}