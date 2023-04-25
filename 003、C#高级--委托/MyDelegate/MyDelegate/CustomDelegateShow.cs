using System;

namespace MyDelegate
{
    public class CustomDelegateShow
    {
        public static void Show()
        {
            //1、委托实例化
            //（1）通过New来实例化，要求传递一个和这个委托的参数和返回值完全匹配的方法
            NoReturnNoParaOutClass noReturnNoParaOutClass = new NoReturnNoParaOutClass(NoReturnNoParaMehtod);
            //（2）直接=一个方法，要求方法和这个委托的参数和返回值完全匹配，这个是编译器提供的语法糖
            NoReturnNoParaOutClass noReturnNoParaOutClass2 = NoReturnNoParaMehtod;
            //（3）直接=一个匿名委托，要求和这个委托的参数和返回值完全匹配
            NoReturnNoParaOutClass noReturnNoParaOutClass3 = delegate () { Console.WriteLine("这是一个无参数无返回值的方法。。。"); };
            //（4）直接=一个Lambda，要求和这个委托的参数和返回值完全匹配
            NoReturnNoParaOutClass noReturnNoParaOutClass4 = ()=> { Console.WriteLine("这是一个无参数无返回值的方法。。。"); };

            //无参无返回值委托实例化
            CustomDelegate.NoReturnNoPara noReturnNoPara = NoReturnNoParaMehtod;
            //带参数无返回值委托实例化
            CustomDelegate.NoReturnWithPara noReturnWithPara = NoReturnWithParaMehtod;
            //无参数带返回值委托实例化
            CustomDelegate.WithReturnNoPara withReturnNoPara = WithReturnNoParaMehtod;
            //带参数带返回值委托实例化
            CustomDelegate.WithReturnWithPara withReturnWithPara = WithReturnWithParaMehtod;

            //2、委托执行
            //（1）Inovke执行方法，如果委托定义没有参数，则Inovke也没有参数；委托没有返回值，则Inovke也没有返回值
            noReturnNoParaOutClass.Invoke();
            //（2）BeginInvoke开启一个新的线程去执行委托
            //NetCore不支持，NetFamework支持  NetCore有更好的多线程功能来支持实现类似功能
            //noReturnNoParaOutClass.BeginInvoke((a) => Console.WriteLine("方法调用结束。。。"), null);
            //（3）EndInvoke等待BeginInvoke方法执行完成后再执行EndInvoke后面的代码
            //NetCore不支持，NetFamework支持  NetCore有更好的多线程功能来支持实现类似功能
            //noReturnNoParaOutClass.EndInvoke(null);

            //无参无返回值委托执行
            noReturnNoPara.Invoke();
            //带参数无返回值委托执行
            noReturnWithPara.Invoke(1,2);
            //无参数带返回值委托执行
            int result=withReturnNoPara.Invoke();
            //带参数带返回值委托执行
            int x = 1;
            int y = 1;
            int result2 = withReturnWithPara.Invoke(out x, ref y);
        }

        private static void NoReturnNoParaMehtod()
        {
            Console.WriteLine("这是一个无参数无返回值的方法。。。");
        }

        private static void NoReturnWithParaMehtod(int x, int y)
        {
            Console.WriteLine($"这是一个带参数无返回值的方法。。。");
        }

        private static int WithReturnNoParaMehtod()
        {
            Console.WriteLine($"这是一个无参数带返回值的方法。。。");
            return default(int);
        }

        private static int WithReturnWithParaMehtod(out int x, ref int y)
        {
            Console.WriteLine($"这是一个带参数带返回值的方法。。。");
            x = 1;
            return default(int);
        }
    }
}
