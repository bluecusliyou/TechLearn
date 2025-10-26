using Castle.DynamicProxy;
using System;

namespace MyAutofac
{
    public class CustomInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("方法执行前。。。");
            //执行当前方法
            invocation.Proceed();
            Console.WriteLine("方法执行后。。。");
        }
    }
}
