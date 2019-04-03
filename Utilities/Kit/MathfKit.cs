using UnityEngine;

namespace Betterfly.BetterCode
{
    /// <summary>
    /// Mathf工具单位
    /// </summary>
    public partial class MathfKit
    {
        /// <summary>
        /// 默认的阈值
        /// </summary>
        public const float DefaultThreshold = 0.01F;

        /// <summary>
        /// float近似值的计算
        /// </summary>
        /// <param name="current">当前float</param>
        /// <param name="target">目标float</param>
        /// <param name="threshold">阈值</param>
        /// <returns>是否为近似值</returns>
        public static bool Approximately(float current, float target, float threshold = DefaultThreshold)
        {
            if (Mathf.Abs(current - target) > threshold)
            {
                return false;
            }
            return true;
        }

        public static void Swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        public static void Swap(ref float a, ref float b)
        {
            //1
//            a = a + b;
//            b = a - b;
//            a = a - b;
            //2
//            b = a + 0 * (a = b);
            float temp = a;
            a = b;
            b = temp;
        }
    }

}

