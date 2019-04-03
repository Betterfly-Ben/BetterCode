using System;
using UnityEngine;

namespace Betterfly.BetterCode
{
    public class ReadOnlyInEditorAttribute : PropertyAttribute
    {
        public string labelText;
        public ReadOnlyInEditorAttribute(){}

        public ReadOnlyInEditorAttribute(string labelText)
        {
            this.labelText = labelText;
        }
    }
}