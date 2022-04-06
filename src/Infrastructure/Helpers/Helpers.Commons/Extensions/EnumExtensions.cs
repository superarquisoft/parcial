using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace Helpers.Commons.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// GetDescription
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T enumeration) where T : IConvertible
        {
            if (enumeration is Enum)
            {
                Type type = enumeration.GetType();
                Array values = Enum.GetValues(type);

                foreach (int value in values)
                {
                    if (value == enumeration.ToInt32(CultureInfo.InvariantCulture))
                    {
                        MemberInfo[] publicMemberForValue = type.GetMember(type.GetEnumName(value));

                        DescriptionAttribute descriptionAttribute = publicMemberForValue[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }
            return string.Empty;
        }
    }
}
