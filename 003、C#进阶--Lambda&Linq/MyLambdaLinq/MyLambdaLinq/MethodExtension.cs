using System;

namespace MyLambdaLinq
{
    /// <summary>
    /// 扩展方法三要素
    /// 静态类，静态方法，this关键字
    /// </summary>
    public static class MethodExtension2
    {
        /// <summary>
        /// 扩展方法
        /// </summary>
        /// <param name="student"></param>
        public static void StudyFramework2(this Student student)
        {
            Console.WriteLine($"{student.Id} {student.Name}扩展方法。。。。");
        }

        /// <summary>
        /// 普通类扩展方法
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string IntToString(this int i)
        {
            return i.ToString();
        }

        /// <summary>
        /// 泛型类扩展方法
        /// </summary>
        public static int GenericeExtend<T>(this T t)
        {
            if (t is int)
            {
                return Convert.ToInt32(t);
            }
            else if (t is object)
            {

            }
            return 0;
        }

        /// <summary>
        /// object类扩展方法
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int ObjectToInt(this object t)
        {
            if (t is int)
            {
                return Convert.ToInt32(t);
            }
            else if (t is object)
            {

            }
            return 0;
        }
    }

    /// <summary>
    /// 扩展方法
    /// </summary>
    public class MethodExtension
    {
        /// <summary>
        /// 方法封装
        /// </summary>
        /// <param name="student"></param>
        public static void StudyFramework1(Student student)
        {            
            Console.WriteLine($"{student.Id} {student.Name}方法封装。。。。");
        }
        

        public static void Show()
        {
            //三、扩展方法
            //1、需求：给一个类增加一个功能
            //（1）方案1：类上直接添加一个方法
            //需要修改原类，类一旦修改，类就需要重新发布编译，违背了开闭原则，如果要新增一个功能，尽量做到不去修改之前的代码
            //自己的类要修改还是可以修改的，但是系统框架的类无法去修改的
            {
                Console.WriteLine("*****************方案1：类上直接添加一个方法**************");
                Student student = new Student()
                {
                    Id = 123,
                    Name = "张三",
                    Age = 25,
                    ClassId = 1
                };
                student.StudyFramework();
                Console.WriteLine("*****************方案1：类上直接添加一个方法**************");
            }
            //（2）方案2：添加一个外部类方法，把当前类作为参数传入
            //不需要修改原类，就可以获取到传递过来的这个实体中的各种数据
            //调用方法需要调用其他类的方法，还要把当前类实例作为参数传进去，还是麻烦
            {
                Console.WriteLine("*****************方案2：添加一个外部类方法，把当前类作为参数传入**************");
                Student student = new Student()
                {
                    Id = 123,
                    Name = "张三",
                    Age = 25,
                    ClassId = 1
                };
                MethodExtension.StudyFramework1(student);
                Console.WriteLine("*****************方案2：添加一个外部类方法，把当前类作为参数传入**************");
            }

            //（3）方案3：扩展方法
            //把传入的当前实例参数放在第一个参数，参数前面加this关键字，就可以直接用当前实例调用扩展方法，就像调用实例自己的方法一样
            //扩展方法三要素：静态类，静态方法，第一个参数this关键字
            {
                Console.WriteLine("*****************方案3：扩展方法**************");
                Student student = new Student()
                {
                    Id = 123,
                    Name = "张三",
                    Age = 25,
                    ClassId = 1
                };
                student.StudyFramework2();
                Console.WriteLine("*****************方案3：扩展方法**************");
            }
            //2、可以为哪些类扩展方法
            //（1）普通类扩展方法
            {
                Console.WriteLine("*****************普通类扩展方法**************");
                int aa = 0;
                aa.IntToString();
                Console.WriteLine("*****************普通类扩展方法**************");
            }
            //（2）泛型类扩展方法
            //可以，但是扩展泛型类，会有侵入性，相当于让任何一个类型，都拥有了这个方法，覆盖的访问太广
            {
                Console.WriteLine("*****************泛型类扩展方法**************");
                int bb = 3;
                bb.GenericeExtend<int>();
                string str = "张三";
                str.GenericeExtend<string>();
                Console.WriteLine("*****************泛型类扩展方法**************");
            }
            //（3）Object类扩展方法
            //可以，但是扩展泛型类，会有侵入性，因为任何一个类型都是object的子类，扩展object，就相当于给所有的类型扩展了一个方法，可能会让一些类型，存在了一些不应该存在的行为
            {
                Console.WriteLine("*****************Object类扩展方法**************");
                int cc = 3;
                cc.ObjectToInt();
                Console.WriteLine("*****************Object类扩展方法**************");
            }
            //（4）扩展方法调用优先级
            //如果增加了扩展方法，同时也在类的内部增加了一个同样的方法，在调用的时候，会优先调用类内部的方法
            //3、扩展方法应用场景                    
            //（1）扩展第三方的类库
            //第三方类库通过dll方式引入进来的，我们是不能直接取修改代码的，可以通过扩展方法，给第三方的类库中的某个类型增加功能呢，扩展功能
            //（2）原有功能的扩展
            //在系统做维护的的时候，需要做到不修改之前的代码，想要增加功能的时候
        }
    }
}
