using System;

namespace MyGeneric
{
    public class GenericMethod
    {
        /// <summary>
        /// <summary>
        /// 泛型方法：方法名称后面加上尖括号，里面是类型参数
        ///           类型参数实际上就是一个类型T声明，方法就可以用这个类型T了
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
               typeof(GenericMethod), tParameter.GetType().Name, tParameter);
        }

        /// <summary>
        /// 泛型方法：为了一个方法满足不同的类型的需求
        ///           一个方法完成多实体的查询
        ///           一个方法完成不同的类型的数据展示
        /// 多类型参数：不要关键字，不要类名称重复
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public T Get<T, S, Model, Eleven, Null>(Eleven eleven)
        {
            GenericClass<int> genericClass = new GenericClass<int>();

            throw new Exception();
        }
    }
}