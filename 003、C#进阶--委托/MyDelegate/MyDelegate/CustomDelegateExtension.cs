using System;
using System.Linq;
using System.Reflection;

namespace MyDelegate
{
    //声明委托
    public delegate void ShowDelegate();

    /// <summary>
    /// 普通类
    /// </summary>
    public class CustomClass
    {
        public void Method()
        {
            Console.WriteLine("朴素嵌套业务核心");
        }
    }

    /// <summary>
    /// 普通类  方法标记特性
    /// </summary>
    public class CustomClass2
    {
        [DelegateLog]
        [DelegateError]
        [DelegateAuth]
        public void Method()
        {
            Console.WriteLine("花式嵌套业务核心");
        }
    }

    /// <summary>
    /// 委托嵌套使用
    /// </summary>
    public class CustomDelegateExtension
    {
        /// <summary>
        /// 委托朴素嵌套实现
        /// </summary>
        public static void Show()
        {
            ShowDelegate showMthod1 = new ShowDelegate(() =>
            {
                Console.WriteLine("showMthod1执行前");
                new CustomClass().Method();
                Console.WriteLine("showMthod1执行后");
            });

            ShowDelegate showMthod2 = new ShowDelegate(() =>
            {
                Console.WriteLine("showMthod2执行前");
                showMthod1.Invoke();
                Console.WriteLine("showMthod2执行后");
            });

            ShowDelegate showMthod3 = new ShowDelegate(() =>
            {
                Console.WriteLine("showMthod3执行前");
                showMthod2.Invoke();
                Console.WriteLine("showMthod3执行后");
            });

            showMthod3.Invoke();
        }

        /// <summary>
        /// 委托花式嵌套实现
        /// </summary>
        public static void Show2()
        {
            //反射获取类的方法信息
            CustomClass2 invokerAction = new CustomClass2();
            Type type = invokerAction.GetType();
            MethodInfo methodInfo = type.GetMethod("Method");

            //给委托赋值，初始委托方法
            ShowDelegate showMethod = new ShowDelegate(() =>
            {
                invokerAction.Method();
            });
            
            //判断是否定义特性对每个特性进行执行
            //继承自父类的特性都算
            if (methodInfo.IsDefined(typeof(AbstractMethodAttribute), true))
            {
                //Reverse越靠近方法越先执行
                foreach (AbstractMethodAttribute attribute in methodInfo.GetCustomAttributes().Reverse())
                {
                    //把初始方法传入，返回封装好的委托再作为下一个参数传入
                    showMethod = attribute.Do(showMethod);
                }
            }

            //执行委托
            showMethod.Invoke();
        }
    }
}
