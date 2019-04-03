using UnityEngine;

namespace Betterfly.BetterCode {
    /// <summary>
    /// Vector3的扩展方法
    /// </summary>
    public static partial class Vector3Ex {

        /// <summary>
        /// Vector3近似值的计算
        /// </summary>
        /// <param name="current">当前Vector3</param>
        /// <param name="target">目标Vector3</param>
        /// <param name="threshold">阈值</param>
        /// <returns>是否为近似值</returns>
        public static bool Approximately(this Vector3 current,Vector3 target,float threshold = MathfKit.DefaultThreshold)
        {
            if(MathfKit.Approximately(current.x, target.x, threshold)
             && MathfKit.Approximately(current.y, target.y, threshold)
              && MathfKit.Approximately(current.z, target.z, threshold))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 转化为Vector2
        /// </summary>
        /// <param name="current">当前Vector3</param>
        /// <returns>Vector2</returns>
        public static Vector2 ToVector2(this Vector3 current){
            return current.ToXY(); // 默认保留XY
        }

        /// <summary>
        /// 保留X、Y
        /// </summary>
        /// <param name="current">当前Vector3</param>
        /// <returns>Vector2</returns>
        public static Vector2 ToXY(this Vector3 current){
            return new Vector2(current.x,current.y);
        }

        /// <summary>
        /// 保留X、Z
        /// </summary>
        /// <param name="current">当前Vector3</param>
        /// <returns>Vector2</returns>
        public static Vector2 ToXZ(this Vector3 current){
            return new Vector2(current.x,current.z);
        }

        /// <summary>
        /// 保留Y、Z
        /// </summary>
        /// <param name="current">当前Vector3</param>
        /// <returns>Vector2</returns>
        public static Vector2 ToYZ(this Vector3 current){
            return new Vector2(current.y,current.z);
        }

        public static Vector3 ChangeX(this Vector3 current, float newX)
        {
//            return new Vector3(newX,current.y,current.z);
            current.Set(newX, current.y, current.z);
            return current;
        }

        public static Vector3 ChangeY(this Vector3 current, float newY)
        {
            current.Set(current.x,newY,current.z);
            return current;
        }

        public static Vector3 ChangeZ(this Vector3 current, float newZ)
        {
            current.Set(current.x,current.y,newZ);
            return current;
        }
    }

}
