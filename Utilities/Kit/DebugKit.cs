using UnityEngine;

namespace Betterfly.BetterCode{
	/// <summary>
	/// Debug工具单位
	/// </summary>
	public partial class DebugKit {
		/// <summary>
		/// 输出指定颜色的调试信息
		/// </summary>
		/// <param name="color">颜色</param>
		/// <param name="message">调试信息</param>
		public static void Log(Color color, string message){
            //使用富文本输出
            Debug.Log(message.DecorateByColor(color));
		}

        /// <summary>
        /// 输出指定颜色指定格式的调试信息
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="format">格式化标准</param>
        /// <param name="args">格式化参数</param>
        public static void LogFormat(Color color, string format, params object[] args)
        {
            //获得格式化文本
            string message = string.Format(format, args);
            //输出文本
            DebugKit.Log(color, message);
        }

        /// <summary>
        /// 输出指定颜色的调试信息（Warning）
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="message">调试信息</param>
        public static void LogWarning(Color color,string message)
        {
            //使用富文本输出
            Debug.LogWarning(message.DecorateByColor(color));
        }

        /// <summary>
        /// 输出指定颜色指定格式的调试信息（Warning）
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="format">格式化标准</param>
        /// <param name="args">格式化参数</param>
        public static void LogWarningFormat(Color color, string format,params object[] args)
        {
            //获得格式化文本
            string message = string.Format(format, args);
            //输出文本
            DebugKit.LogWarning(color, message);
        }

        /// <summary>
        /// 输出指定颜色的调试信息（Error）
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="message">调试信息</param>
        public static void LogError(Color color, string message)
        {
            //使用富文本输出
            Debug.LogError(message.DecorateByColor(color));
        }

        /// <summary>
        /// 输出指定颜色指定格式的调试信息（Error）
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="format">格式化标准</param>
        /// <param name="args">格式化参数</param>
        public static void LogErrorFormat(Color color,string format,params object[] args)
        {
            //获得格式化文本
            string message = string.Format(format, args);
            //输出文本
            DebugKit.LogError(color, message);
        }

		/// <summary>
		/// 绘制箭头
		/// </summary>
		/// <param name="origin">箭头的起点</param>
		/// <param name="direction">箭头的方向，包括长度</param>
		/// <param name="arrowColor">箭头的颜色</param>
		/// <param name="arrowLength">箭头头部的长度</param>
		/// <param name="arrowRadius">箭头头部的半径</param>
		/// <param name="arrowCount">箭头头部的绘制次数</param>
		public static void DrawArrow(Vector3 origin, Vector3 direction, Color arrowColor, float arrowLength = 0.35F, float arrowRadius = 0.2F, int arrowCount = 32)
		{
			Vector3 directionNormalized = direction.normalized;
			Vector3 directionUp, directionRight; // 定义相对Direction的Up和Right
			if (directionNormalized.Approximately(Vector3.up) == false && directionNormalized.Approximately(Vector3.down) == false)
			{
				// 以WorldUp为PlaneUp确认PlaneRight
				// Unity是左手坐标系，所以是 up x forward = right
				directionRight = Vector3.Cross(Vector3.up, direction).normalized;
				// forward x right = up
				directionUp = Vector3.Cross(direction, directionRight).normalized;
			}
			else
			{
				// 以WorldRight为PlaneRight确认PlaneUp
				// Unity是左手坐标系，所以是 forward x right = up
				directionUp = Vector3.Cross(direction, Vector3.right).normalized;
				// up x forward = right
				directionRight = Vector3.Cross(directionUp, direction).normalized;
			}
			
			// 画直线
			Debug.DrawRay(origin,direction,arrowColor);
			Vector3 arrowHead = origin + direction;
			Vector3 arrowFoot = origin + direction - arrowLength / direction.magnitude * direction;
			// 画箭头
			float arrowStart = 0F;
			float arrowOffset = Mathf.PI * 2F / arrowCount;
			for (int i = 0; i < arrowCount; i++)
			{
				Vector3 arrowCurrent = arrowFoot + Mathf.Sin(arrowStart) * arrowRadius * directionUp + Mathf.Cos(arrowStart) * arrowRadius * directionRight;
				Debug.DrawLine(arrowFoot,arrowCurrent,arrowColor);
				Debug.DrawLine(arrowHead,arrowCurrent,arrowColor);
				arrowStart += arrowOffset;
			}
		}
	}
}
