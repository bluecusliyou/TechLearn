using System;

namespace MyAutofac
{
    /// <summary>
    /// 标记方法
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SelectMethodAttribute : Attribute
    {
    }
}
