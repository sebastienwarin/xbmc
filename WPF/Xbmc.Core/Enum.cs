#if V7

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xbmc.Core
{
    internal static class Enum
    {
        public static string[] GetNames(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException("Type '" + enumType.Name + "' is not an enum.");

            IEnumerable<FieldInfo> fields = enumType.GetFields().Where(field => field.IsLiteral);
            return fields.Select(field => field.GetValue(enumType)).Select(value => (string) value).ToArray();
        }
    }
}

#endif