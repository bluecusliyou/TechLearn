using System;

namespace MyAttribute.EnumExtend
{
    /// <summary>
    /// Remark特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class RemarkAttribute : Attribute
    {
        public string Remark { get; private set; }
        public RemarkAttribute(string remark)
        {
            this.Remark = remark;
        }
    }
}
