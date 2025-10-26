using System;

namespace MyLambdaLinq
{
    /// <summary>
    /// 2、Lambda的演变过程
    /// </summary>
    public class LambdaShow
    {
        /// <summary>
        /// 声明委托
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public delegate void NoReturnWithPara(int x, string y);

        /// <summary>
        /// 声明方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void PrintParam(int x, string y)
        {
            Console.WriteLine(x);
            Console.WriteLine(y);
        }

        public void Show()
        {
            //2、Lambda的演变过程
            {
                //（1）.Netframework1.0/1.1，原始方法
                NoReturnWithPara method = new NoReturnWithPara(PrintParam);
            }

            {
                //（2）.NetFramework2.0，匿名方法
                //增加了一个delegate关键字,可以访问到除了参数以外的局部变量
                int i = 0;
                NoReturnWithPara method = new NoReturnWithPara(delegate (int x, string y)
                {
                    Console.WriteLine(x);
                    Console.WriteLine(y);
                    Console.WriteLine(i);
                });
            }

            {
                //（3）.NetFramework3.0，=>
                //去掉delegate关键字，在参数的后增加了一个=>  goes to
                int i = 0;
                NoReturnWithPara method = new NoReturnWithPara((int x, string y) =>
                {
                    Console.WriteLine(x);
                    Console.WriteLine(y);
                    Console.WriteLine(i);
                });
            }

            {
                //（4）.NetFramework3.0后期，简化参数类型
                //去掉了匿名方法中的参数类型，这个是编译器提供的语法糖，编译器可以根据委托类型定义的参数类型推导出参数类型
                int i = 0;
                NoReturnWithPara method = new NoReturnWithPara((x, y) =>
                {
                    Console.WriteLine(x);
                    Console.WriteLine(y);
                    Console.WriteLine(i);
                });
            }

            {
                //（5）如果方法体中只有一行代码，可以省略方法体大括号                
                NoReturnWithPara method = (x, y) => Console.WriteLine(x);
            }

            {
                //（6）如果方法只有一个参数，省略参数小括号                
                Action<string> method = x => Console.WriteLine(x);
            }
            {
                //（7）如果方法体中只有一行代码，且有返回值，可以省略return;
                Func<int, string> method = i => i.ToString();
            }
        }
    }
}
