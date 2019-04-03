using UnityEngine;
using System;
using System.Collections.Generic;

namespace Betterfly.BetterCode
{
	public static partial class StringEx
	{
		/// <summary>
		/// 默认的分隔符
		/// </summary>
		public const string DefaultSeparator = ", ";
		
		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}

		/// <summary>
		/// 将string转成enum
		/// </summary>
		/// <typeparam name="T">T必须是enum类型</typeparam>
		/// <param name="enumStr">想要转成enum的string</param>
		/// <returns>由string转化成的enum</returns>
		public static T GetEnum<T>(this string enumStr){
			return (T)Enum.Parse(typeof(T), enumStr);
		}

		/// <summary>
		/// 使用富文本（颜色）装饰string
		/// </summary>
		/// <param name="str">需要装饰的string</param>
		/// <param name="color">用于装饰的颜色</param>
		/// <returns>装饰好的string</returns>
		public static string DecorateByColor(this string str,Color color)
		{
			return string.Format("<color={0}>{1}</color>", color.ToHex(), str);
		}
		
		public static string JoinString(this IEnumerable<string> values, string separator = DefaultSeparator)
		{
			if (separator.IsNullOrEmpty())
			{
				return string.Join(DefaultSeparator, values);
			}

			return string.Join(separator, values);
		}
	}
}