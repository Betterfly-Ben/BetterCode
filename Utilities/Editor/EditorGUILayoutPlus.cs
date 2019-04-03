#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace Betterfly.BetterCode {
	public static class EditorGUILayoutPlus {
		/// <summary>
		/// 扩展EditorGUILayout.Space，使可以指定行数
		/// </summary>
		/// <param name="lineCount">Line count</param>
		public static void Space(int lineCount = 1)
		{
			int realLineCount = lineCount;
			if (realLineCount < 1)
			{
				realLineCount = 1;
			}

			for (int i = 0; i < realLineCount; ++i)
			{
				EditorGUILayout.Space();
			}
		}
	}
}
#endif