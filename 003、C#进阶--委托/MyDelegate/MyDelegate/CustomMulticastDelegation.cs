using System;

namespace MyDelegate
{
    /// <summary>
    /// 多播委托
    /// </summary>
    public class CustomMulticastDelegation
    {
        /// <summary>
        /// 多播委托
        /// </summary>
        public void Show()
        {
            //注册方法链
            Action action = new Action(DoNothing);
            action += DoNothingStatic;
            action += DoNothing;//同一个方法注册两次会执行两次
            action += () =>
            {
                Console.WriteLine("this is Lambda。。。");
            };
            //action.BeginInvoke();//开启一个新的线程去执行委托，如果注册有多个方法的委托，不能使用BeginInvoke
            //action.Invoke();
            //注册有多个方法的委托想要开启新线程去执行委托，可以通过action.GetInvocationList()获取到所有的委托，然后循环，每个方法执行的时候可以BeginInvoke
            foreach (Action action1 in action.GetInvocationList())
            {
                action1.Invoke();
                //action1.BeginInvoke(null,null);
            }
        }

        /// <summary>
        /// 委托移除
        /// </summary>
        public void Show2()
        {
            //注册方法链
            Action action = new Action(DoNothing);
            action += DoNothingStatic;
            action += new CustomMulticastDelegation().DoNothing2;
            action += CustomMulticastDelegation.DoNothingStatic2;
            action += DoNothing;
            action += () =>
            {
                Console.WriteLine("this is Lambda。。。");
            };
            //移除方法链方法
            action -= DoNothing;//是从后往前，逐个匹配，如果匹配不到，就不做任何操作，如果匹配到，就把当前这个移除，且停止去继续往后匹配
            action -= new CustomMulticastDelegation().DoNothing2; //没有移除掉，因为不是同一个实例的方法，引用的地址是不同的
            action -= CustomMulticastDelegation.DoNothingStatic2;//静态方法是同一个方法，可以移除掉
            action -= () => //没有移除，因为不同同一个方法，每个lambda表达式在底层会生成不同的方法名的，看起来一样实际不同
            {
                Console.WriteLine("this is Lambda。。。");
            };
            action.Invoke();
        }

        private void DoNothing()
        {
            Console.WriteLine("This is DoNothing");
        }

        private void DoNothing2()
        {
            Console.WriteLine("This is DoNothing2");
        }

        private static void DoNothingStatic()
        {
            Console.WriteLine("This is DoNothingStatic");
        }

        private static void DoNothingStatic2()
        {
            Console.WriteLine("This is DoNothingStatic2");
        }
    }
}
