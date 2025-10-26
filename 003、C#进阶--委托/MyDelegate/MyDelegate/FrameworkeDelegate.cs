using System;

namespace MyDelegate
{
    public class FrameworkeDelegate
    {
        //参数不够自己定义
        public delegate void Action<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14, in T15, in T16, in T17>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17);

        //参数不够自己定义
        public delegate TResult Func<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, in T13, in T14, in T15, in T16, in T17, out TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, T17 arg17);

        /// <summary>
        /// 框架内置委托
        /// </summary>
        public void Show()
        {
            //1、Action
            //（1）Action是来自于System.RunTime的一个声明好的可以带有一个或者多个参数无返回值的委托 
            //（2）最多支持16个入参，正常使用足够
            //（3）想要支持更多的参数呢，可以自己定义
            Action action = new Action(NoreturnNopara);
            Action<int> action1 = new Action<int>(DoNothingInt);

            //2、Func
            //（1）Func是来自于System.RunTime的一个声明好有返回值的委托，也可以有参数 
            //（2）如果既然有参数也有返回值，前面是输入参数类型，最后面的作为返回值类型
            //（3）最多支持16个入参，正常足够使用
            //（4）想要支持更多的参数呢，可以自己定义
            Func<int> func = new Func<int>(ReturnNopara);
            Func<int, int> func1 = new Func<int, int>(ToInt);
            Func<int, string, int> func2 = new Func<int, string, int>(DoNothingIntAndStringNew);

            //3、为什么系统框架要给我们提供这样的两个委托呢？
            //（1）委托的本质是类，定义多个委托，其实就是新增了多个类，定义好的两个委托参数和返回值都是一致的，但是因为是不同的类，没有继承不能通用
            //（2）既然是系统框架给我们定义好了这两个委托，自然是希望我们在以后的开发中，都去使用这两个委托，这样就可以把委托类型做到统一
            //（3）那之前定义好的委托是去不掉的，这被称之为历史包袱
        }

        private void DoNothingInt(int i)
        {
            Console.WriteLine("This is DoNothing");
        }        

        private int DoNothingIntAndStringNew(int i, string j)
        {
            Console.WriteLine("This is DoNothing");
            return 0;
        }

        private int ToInt(int i)
        {
            return 0;
        }

        private int ReturnNopara()
        {
            return 0;
        }

        private void NoreturnNopara()
        {

        }
    }
}
