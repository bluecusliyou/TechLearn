using System;

namespace MyAutofac
{
    //标记构造方法
    [AttributeUsage(AttributeTargets.Constructor)]
    public class SelectCtorAttribute : Attribute
    {
    }
}
