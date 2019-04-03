using System;
using UnityEngine;

namespace Betterfly.BetterCode
{
	/// <summary>
	/// Color的扩展方法
	/// </summary>
	public static partial class ColorEx
	{
		/// <summary>
		/// 将Color转成十六进制string
		/// </summary>
		/// <param name="color">Color类型</param>
		/// <returns>color的hex格式</returns>
		public static string ToHex(this Color color)
		{
			//根据rgb值，四舍五入，限制在0到255，转化成16进制，若不够两位则在前补0
			string red = Convert.ToString(Mathf.Clamp((int)Math.Round(color.r * 255, 0, MidpointRounding.AwayFromZero), 0, 255), 16).PadLeft(2, '0');
			string green = Convert.ToString(Mathf.Clamp((int)Math.Round(color.g * 255, 0, MidpointRounding.AwayFromZero), 0, 255), 16).PadLeft(2, '0');
			string blue = Convert.ToString(Mathf.Clamp((int)Math.Round(color.b * 255, 0, MidpointRounding.AwayFromZero), 0, 255), 16).PadLeft(2, '0');
			string alpha = Convert.ToString(Mathf.Clamp((int)Math.Round(color.a * 255, 0, MidpointRounding.AwayFromZero), 0, 255), 16).PadLeft(2, '0');
			return "#" + red + green + blue + alpha;
		}
	}
}