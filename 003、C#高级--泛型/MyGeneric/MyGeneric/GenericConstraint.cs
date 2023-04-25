using System;

namespace MyGeneric
{
    /// <summary>
    /// 泛型约束
    /// </summary>
    public class GenericConstraint
    {
        /// <summary>
        /// object参数
        /// </summary>
        /// <param name="oParameter"></param>
        public static void ShowObject(object oParameter)
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
                typeof(GenericConstraint), oParameter.GetType().Name, oParameter);
            People people = (People)oParameter;
            Console.WriteLine($"{people.Id}  {people.Name}");
        }

        /// <summary>
        /// 基类约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void ShowP<T>(T tParameter) where T : People
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
               typeof(GenericConstraint), tParameter.GetType().Name, tParameter);

            Console.WriteLine($"{tParameter.Id}  {tParameter.Name}");
            tParameter.Hi();
        }

        /// <summary>
        /// 接口约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void ShowPI<T>(T tParameter) where T : ISports
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
               typeof(GenericConstraint), tParameter.GetType().Name, tParameter);

            tParameter.Pingpang();
        }

        /// <summary>
        /// 引用类型约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T Get<T>(T t) where T : class
        {
            return t;
        }

        /// <summary>
        /// 值类型类型约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T GetStruct<T>(T t) where T : struct
        {
            return t;
        }

        /// <summary>
        /// 无参数构造函数约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T GetNew<T>(T t) where T : new()
        {
            return t;
        }

        /// <summary>
        /// 泛型约束也可以同时约束多个
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tParameter"></param>
        public static void Show<T>(T tParameter) where T : People, ISports, IWork, new()
        {
            Console.WriteLine("This is {0},parameter={1},type={2}",
               typeof(GenericConstraint), tParameter.GetType().Name, tParameter);

            Console.WriteLine($"{tParameter.Id}  {tParameter.Name}");
            tParameter.Hi();
        }

        public static T GetT<T, S>()
            //where T : class//引用类型约束
            //where T : struct//值类型
            where T : new()//无参数构造函数
            where S : class
        {
            //return null;
            //return default(T);//default是个关键字，会根据T的类型去获得一个默认值
            return new T();
            //throw new Exception();
        }
    }
}
