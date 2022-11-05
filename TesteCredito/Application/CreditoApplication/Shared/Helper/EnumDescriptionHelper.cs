using System.ComponentModel;
using System.Globalization;

namespace CreditoApplication.Shared.Helper
{
    public static class EnumDescriptionHelper
    {
        public static string GetDescription<T>(this T e)
        {
            string str = null;

            if (e is Enum)
            {
                Type type = e.GetType();
                foreach (int num in Enum.GetValues(type))
                {
                    if (num == Convert.ToInt32(e, CultureInfo.InvariantCulture))
                    {
                        object[] customAttributes = type.GetMember(type.GetEnumName(num))[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false);
                        if ((uint)customAttributes.Length > 0U)
                        {
                            str = ((DescriptionAttribute)customAttributes[0]).Description;
                        }

                        break;
                    }
                }
            }

            return str;
        }

        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
            // Or return default(T);
        }
    }
}