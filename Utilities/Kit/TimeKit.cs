using UnityEngine;

namespace Betterfly.BetterCode{

	/// <summary>
	/// 时间工具类
	/// </summary>
	public partial class TimeKit {
		/// <summary>
		/// 暂停游戏
		/// </summary>
		public static void PauseGame(){
			Time.timeScale = 0F;
		}

		/// <summary>
		/// 开始游戏
		/// </summary>
		public static void StartGame()
		{
			Time.timeScale = 1F;
		}
	}
}