using System;

namespace MyGeneric
{
    public class CommonMethod
    {
        /// <summary>
        /// 打印个int值
        /// 声明方法时，指定了参数类型，确定了只能传递某个类型
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, iParameter.GetType().Name, iParameter);
        }

        /// <summary>
        /// 打印个string值
        /// </summary>
        /// <param name="sParameter"></param>
        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, sParameter.GetType().Name, sParameter);
        }

        /// <summary>
        /// 打印个DateTime值
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowDateTime(DateTime dtParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod).Name, dtParameter.GetType().Name, dtParameter);
        }

        /// <summary>
        /// 打印个object值
        /// 1 任何父类出现的地方，都可以用子类来代替
        /// 2 object是一切类型的父类 
        /// 
        /// 2个问题：
        /// 1 装箱拆箱
        /// 2 类型安全
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(CommonMethod), oParameter.GetType().Name, oParameter);
        }
        /// <summary>
        /// 泛型方法：方法名称后面加上尖括号，里面是类型参数
        ///           类型参数实际上就是一个类型T声明，方法就可以用这个类型T了
        ///           
        /// 思考下，泛型为什么也可以，支持多种不同类型的参数？
        /// 泛型声明方法时，并没有写死类型，T是什么，不知道
        /// T要等着调用的时候才指定
        /// 单身狗---随心随缘  亡五(拥有整片大森林，凤姐 芙蓉  小月月  章子怡 )
        /// 正是因为没有写死，才拥有了无限的可能！！
        /// 
        /// 设计思想--延迟声明：推迟一切可以推迟的，一切能晚点再做的事儿，就晚点再做
        /// 深入一下，泛型的原理
        /// 
        /// 泛型在代码编译时，究竟生成了一个什么东西
        /// 泛型不是一个简单的语法糖，是框架升级支持的
        /// 
        /// 泛型方法的性能跟普通方法一致，是最好的，
        /// 而且还能一个方法满足多个不同类型
        /// 又叫马儿跑，又叫马儿不吃草，是因为框架的升级支持的！！
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)//, T t = default(T
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
               typeof(CommonMethod), tParameter.GetType().Name, tParameter);
        }

        //WebServices WCF 都不能用泛型，为什么？
        //跨语言的，别的语言也能用，不支持泛型。。
        //服务在发布的时候是必须确定的，泛型在编译时确定不了


    }
}
