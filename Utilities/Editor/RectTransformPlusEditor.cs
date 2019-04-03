namespace Betterfly.BetterCode {
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// 往RectTransform的Menu添加功能
    /// </summary>
    public partial class RectTransformContextMenu
    {
        /// <summary>
        /// 判断SetAnchorToScale是否可以执行
        /// </summary>
        /// <param name="command">MenuCommand</param>
        /// <returns>是否可以执行SetAnchorToScale</returns>
        [MenuItem("CONTEXT/RectTransform/Set Anchor To Scale",true)]
        // isValidateFunction为true，则在执行SetAnchorToScale之前，先检测是否可以执行SetAnchorToScale，
        // 执行体为CheckSetAnchorToScale，必须保证CheckSetAnchorToScale和SetAnchorToScale的MenuItem的itemName相同，
        // 返回值必须为bool类型，否则不起效果
        static bool CheckSetAnchorToScale(MenuCommand command)
        {
            RectTransform rectTran = command.context as RectTransform;
            if (rectTran == null || rectTran.parent == null)
            {
                return false;
            }

            RectTransform parRectTran = rectTran.parent.GetComponent<RectTransform>();
            if (parRectTran == null)
            {
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// 将RectTransform的Anchor的大小重置为Scale的大小，获得较好的自适应
        /// </summary>
        /// <param name="command">MenuCommand</param>
        [MenuItem("CONTEXT/RectTransform/Set Anchor To Scale")]
        static void SetAnchorToScale(MenuCommand command)
        {
            RectTransform rectTran = command.context as RectTransform;
            UGUIKit.SetAnchorToScale(rectTran);
        }

        /// <summary>
        /// 将RectTransform的Scale的大小重置为Anchor的大小
        /// </summary>
        /// <param name="command">MenuCommand</param>
        [MenuItem("CONTEXT/RectTransform/Set Scale To Anchor")]
        static void SetScaleToAnchor(MenuCommand command){
            RectTransform rectTran = command.context as RectTransform;

            if(rectTran == null){
                return;
            }

            //设置Scale与Anchor重合
            rectTran.offsetMax = Vector2.zero;
            rectTran.offsetMin = Vector2.zero;
        }

        /// <summary>
        /// 输出RectTransform的信息
        /// </summary>
        /// <param name="command"></param>
        [MenuItem("CONTEXT/RectTransform/Log RectTransform Data")]
        static void LogRectTransformData(MenuCommand command){
            RectTransform rectTran = command.context as RectTransform;
            
            if(rectTran == null){
                return;
            }

            Debug.Log(
                (rectTran.gameObject.name + "  RectTransform Data : ").DecorateByColor(Color.red)
                + "\n\tanchoredPosition: " + rectTran.anchoredPosition
                + "\n\tanchorMin: " + rectTran.anchorMin
                + "\n\tanchorMax: " + rectTran.anchorMax
                + "\n\toffsetMin: " + rectTran.offsetMin
                + "\n\toffsetMax: " + rectTran.offsetMax
                + "\n\tpivot: " + rectTran.pivot
                + "\n\tsizeDelta: " + rectTran.sizeDelta
                + "\n\trect.center: " + rectTran.rect.center
                + "\n\trect.width: " + rectTran.rect.width
                + "\n\trect.height: " + rectTran.rect.height
                + "\n\trect.min: " + rectTran.rect.min
                + "\n\trect.max: " + rectTran.rect.max
                + "\n\trect.size: " + rectTran.rect.size
                + "\n\trect.x: " + rectTran.rect.x
                + "\n\trect.xMin: " + rectTran.rect.xMin
                + "\n\trect.xMax: " + rectTran.rect.xMax
                + "\n\trect.y: " + rectTran.rect.y
                + "\n\trect.yMin: " + rectTran.rect.yMin
                + "\n\trect.yMax: " + rectTran.rect.yMax);
        }
    }

}