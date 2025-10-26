using System;
using System.Reflection;

namespace MyAttribute.EnumExtend
{
    public static class AttributeExtend
    {
        public static string GetRemark(this Enum value)
        {
            Type type = value.GetType();
            var field = type.GetField(value.ToString());
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute.Remark;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
