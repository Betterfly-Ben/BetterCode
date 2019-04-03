using UnityEngine;

namespace Betterfly.BetterCode{
	/// <summary>
	/// UGUI工具单位
	/// </summary>
	public partial class UGUIKit {
		/// <summary>
		/// 将RectTransform的Anchor的大小重置为Scale的大小，获得较好的自适应
		/// </summary>
		/// <param name="rectTran">需要重置Scale的RectTransform</param>
		public static void SetAnchorToScale(RectTransform rectTran){
            if(rectTran == null || rectTran.parent == null)
            {
                return;
            }

            RectTransform parRect = rectTran.parent.GetComponent<RectTransform>();
            if (!parRect)
            {
				return;
			}

			//记录parent的宽度、高度
			float parWidth = parRect.rect.width;
			float parHeight = parRect.rect.height;
			//记录当前锚点的Min的(x,y)和Max的(x,y)
			float anchorMinX = parWidth * rectTran.anchorMin.x;
			float anchorMaxX = parWidth * rectTran.anchorMax.x;
			float anchorMinY = parHeight * rectTran.anchorMin.y;
			float anchorMaxY = parHeight * rectTran.anchorMax.y;
			//计算当前rectTran的Min的(x,y)和Max的(x,y)
			float rectMinX = anchorMinX + rectTran.offsetMin.x;
			float rectMaxX = anchorMaxX + rectTran.offsetMax.x;
			float rectMinY = anchorMinY + rectTran.offsetMin.y;
			float rectMaxY = anchorMaxY + rectTran.offsetMax.y;
			//记录当前的锚点信息，用于后期的处理
			float newAnchorMinX = rectMinX;
			float newAnchorMaxX = rectMaxX;
			float newAnchorMinY = rectMinY;
			float newAnchorMaxY = rectMaxY;

			//规范化锚点，Min锚点不能小于(0,0)，Max锚点不能小于Min、不能大于parent的最大区域
			newAnchorMinX = Mathf.Clamp(newAnchorMinX, 0F, parWidth);
			newAnchorMaxX = Mathf.Clamp(newAnchorMaxX, newAnchorMinX, parWidth);
			newAnchorMinY = Mathf.Clamp(newAnchorMinY, 0F, parHeight);
			newAnchorMaxY = Mathf.Clamp(newAnchorMaxY, newAnchorMinY, parHeight);

			//记录新的offsetMin和offsetMax
			float offsetMinX = rectMinX - newAnchorMinX;
			float offsetMaxX = rectMaxX - newAnchorMaxX;
			float offsetMinY = rectMinY - newAnchorMinY;
			float offsetMaxY = rectMaxY - newAnchorMaxY;

			//计算新锚点的比例值
			float anchorMinXRatio = newAnchorMinX / parWidth;
			float anchorMaxXRatio = newAnchorMaxX / parWidth;
			float anchorMinYRatio = newAnchorMinY / parHeight;
			float anchorMaxYRatio = newAnchorMaxY / parHeight;

			//更新锚点的比例值
			rectTran.anchorMin = new Vector2(anchorMinXRatio, anchorMinYRatio);
			rectTran.anchorMax = new Vector2(anchorMaxXRatio, anchorMaxYRatio);
			//通过更新锚点之后，必须更新rectTran，以保持原来的位置
			rectTran.offsetMin = new Vector2(offsetMinX,offsetMinY);
			rectTran.offsetMax = new Vector2(offsetMaxX,offsetMaxY);
		}
	}
}