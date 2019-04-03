using System;
using System.Collections.Generic;

namespace Betterfly.BetterCode
{
    public static partial class TypeEx
    {
        public static bool IsList(this Type listType)
        {
            return listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof(List<>);
        }

        public static Type GetListElementType(this Type listType)
        {
            if (listType.IsList())
            {
                return listType.GetGenericArguments()[0];
            }

            return null;
        }
        
        public static bool IsArrayOrList(this Type listType)
        {
            return listType.IsArray || listType.IsGenericType && listType.GetGenericTypeDefinition() == typeof (List<>);
        }
  
        public static Type GetArrayOrListElementType(this Type listType)
        {
            if (listType.IsArray)
            {
                return listType.GetElementType();
            }

            if (listType.IsList())
            {
                return listType.GetGenericArguments()[0];
            }
            
            return null;
        }
    }
}