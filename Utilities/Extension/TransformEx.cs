using UnityEngine;

namespace Betterfly.BetterCode
{
    public static class TransformEx
    {
        public static void ResetLocal(this Transform trans)
        {
            trans.localPosition = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = Vector3.one;
        }

        public static void ResetLocalPosition(this Transform trans)
        {
            trans.localPosition = Vector3.zero;
        }

        public static void ResetLocalRotation(this Transform trans)
        {
            trans.localRotation = Quaternion.identity;
        }

        public static void ResetLocalScale(this Transform trans)
        {
            trans.localScale = Vector3.one;
        }
    }
}