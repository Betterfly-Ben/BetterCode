#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Betterfly.BetterCode.Editor
{
    [CustomPropertyDrawer(typeof(ReadOnlyInEditorAttribute))]
    public class ReadOnlyInEditorAttributeDrawer : PropertyDrawer
    {
        private bool isFoldout = false;

        private float foldoutHeight = 16F;
        private float arraySizeHeight = 16F;
        private float arrayElementHeight = 16F;
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            ReadOnlyInEditorAttribute readOnlyInEditorAttribute = attribute as ReadOnlyInEditorAttribute;

            if (readOnlyInEditorAttribute.labelText.IsNullOrEmpty() == false)
            {
                label.text = readOnlyInEditorAttribute.labelText;
            }
            
            //1 easy version
            EditorGUI.BeginDisabledGroup(true);
            EditorGUI.PropertyField(position, property, label, true);
            EditorGUI.EndDisabledGroup();
            
//            EditorGUI.LabelField(position,$"{property.serializedObject.targetObject.name} | {fieldInfo.Name} | {fieldInfo.FieldType.Name} | {fieldInfo.FieldType.IsArrayOrList()} | {property.name}");
            
//            EditorGUI.BeginDisabledGroup(true);
//            EditorGUI.LabelField(position,$"{property.name} | {property.propertyPath}");
//            EditorGUI.EndDisabledGroup();
            
//            if (property.isArray)
//            {
//                Debug.Log($"{property.name} IsArray");
//                EditorGUI.BeginDisabledGroup(true);
//                EditorGUI.LabelField(position, "IsArray");
//                EditorGUI.EndDisabledGroup();
//                
////                isFoldout = EditorGUI.Foldout(position, isFoldout, property.name);
////                if (isFoldout)
////                {
////                    float x = position.x;
////                    float y = position.y;
////                    float widht = position.width;
////                    float height = position.height;
////                    y += foldoutHeight;
////                    Rect sizeLabelRect = new Rect(x, y, widht / 2, height);
////                    Rect sizeFieldRect = new Rect(x + widht / 2, y, widht / 2, height);
////                    position.y = y;
////                    EditorGUI.BeginDisabledGroup(true);
////                    EditorGUI.LabelField(sizeLabelRect,"Size");
////                    EditorGUI.LabelField(sizeFieldRect,property.arraySize.ToString());
////                    for (int i = 0; i < property.arraySize; ++i)
////                    {
////                        EditorGUI.PropertyField(position, property.GetArrayElementAtIndex(i),true);
////                    }
////                    EditorGUI.EndDisabledGroup();
////                }
//            }
//            else
//            {
//                Debug.Log($"{property.name} isn't array");
//                EditorGUI.BeginDisabledGroup(true);
//                EditorGUI.PropertyField(position, property, label, true);    
//                EditorGUI.EndDisabledGroup();
//            }
        }
    }
}

#endif