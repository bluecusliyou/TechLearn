using System;

namespace MyAutofac
{
    /// <summary>
    /// 标记属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SelectPropAttribute : Attribute
    {
    }
}
