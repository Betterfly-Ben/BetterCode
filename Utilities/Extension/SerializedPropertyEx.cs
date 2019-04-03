#if UNITY_EDITOR
using System;
using System.Reflection;
using UnityEditor;

namespace Betterfly.BetterCode
{
    public static partial class SerializedPropertyEx
    {
        public static FieldInfo GetFieldInfo(this SerializedProperty property, out Type type)
        {
          Type typeFromProperty = property.GetScriptType();
          if (typeFromProperty != null)
          {
            return GetFieldInfoFromPropertyPath(typeFromProperty, property.propertyPath, out type);
          }
          type = null;
          return null;
        }
    
        public static Type GetScriptType(this SerializedProperty property)
        {
          SerializedProperty property1 = property.serializedObject.FindProperty("m_Script");
          if (property1 == null)
            return null;
          MonoScript objectReferenceValue = property1.objectReferenceValue as MonoScript;
          if (objectReferenceValue == null)
            return null;
          return objectReferenceValue.GetClass();
        }
    
        private static FieldInfo GetFieldInfoFromPropertyPath(Type host, string path, out Type type)
        {
          FieldInfo fieldInfo1 = null;
          type = host;
          string[] strArray = path.Split('.');
          for (int index = 0; index < strArray.Length; ++index)
          {
            string name = strArray[index];
            if (index < strArray.Length - 1 && name == "Array" && strArray[index + 1].StartsWith("data["))
            {
              if (type.IsArrayOrList())
                type = type.GetArrayOrListElementType();
              ++index;
            }
            else
            {
              FieldInfo fieldInfo2 = null;
              for (Type type1 = type; fieldInfo2 == null && type1 != null; type1 = type1.BaseType)
              {
                fieldInfo2 = type1.GetField(name, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
              }
              if (fieldInfo2 == null)
              {
                type = null;
                return null;
              }
              fieldInfo1 = fieldInfo2;
              type = fieldInfo1.FieldType;
            }
          }
          return fieldInfo1;
        }
    }
}
#endif