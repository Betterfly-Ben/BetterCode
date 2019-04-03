using UnityEngine;

namespace Betterfly.BetterCode
{
    /// <summary>
    /// Vector2的扩展方法
    /// </summary>
    public static partial class Vector2Ex
    {

        /// <summary>
        /// Vector2近似值的计算
        /// </summary>
        /// <param name="current">当前Vector2</param>
        /// <param name="target">目标Vector2</param>
        /// <param name="threshold">阈值</param>
        /// <returns>是否为近似值</returns>
        public static bool Approximately(this Vector2 current, Vector2 target, float threshold = MathfKit.DefaultThreshold)
        {
            if (MathfKit.Approximately(current.x,target.x,threshold)
             && MathfKit.Approximately(current.y, target.y, threshold))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 转化为Vector3
        /// </summary>
        /// <param name="current">当前Vector2</param>
        /// <param name="zValue">z轴的值</param>
        /// <returns>Vector3</returns>
        public static Vector3 ToVector3(this Vector2 current,float zValue = 0F){
            return current.FromXY(zValue); // 默认从XY中产生
        }

        /// <summary>
        /// 转化为Vector3（Vector2做XY）
        /// </summary>
        /// <param name="current">当前Vector2</param>
        /// <param name="zValue">z轴的值</param>
        /// <returns>Vector3</returns>
        public static Vector3 FromXY(this Vector2 current,float zValue = 0F){
            return new Vector3(current.x,current.y,zValue);
        }

        /// <summary>
        /// 转化为Vector3（Vector2做XZ）
        /// </summary>
        /// <param name="current">当前Vector2</param>
        /// <param name="yValue">y轴的值</param>
        /// <returns>Vector3</returns>
        public static Vector3 FromXZ(this Vector2 current,float yValue = 0F){
            return new Vector3(current.x,yValue,current.y);
        }

        /// <summary>
        /// 转化为Vector3（Vector2做YZ）
        /// </summary>
        /// <param name="current">当前Vector2</param>
        /// <param name="xValue">x轴的值</param>
        /// <returns>Vector3</returns>
        public static Vector3 FromYZ(this Vector2 current,float xValue = 0F){
            return new Vector3(xValue,current.x,current.y);
        }

        public static Vector2 ChangeX(this Vector2 current, float newX)
        {
            current.Set(newX,current.y);
            return current;
        }

        public static Vector2 ChangeY(this Vector2 current, float newY)
        {
            current.Set(current.x,newY);
            return current;
        }
    }

}
