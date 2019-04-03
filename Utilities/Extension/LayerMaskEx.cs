using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Betterfly.BetterCode
{
    public static partial class LayerMaskEx
    {
        public static bool Contains(this LayerMask layerMask, GameObject gameObject)
        {
            return layerMask.Contains(1 << gameObject.layer);
        }

        public static bool Contains(this LayerMask layerMask, int val)
        {
            return (layerMask.value & val) != 0;
        }
    }
}