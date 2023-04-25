using System;

namespace MyLambdaLinq
{
    /// <summary>
    /// 二、匿名类
    /// </summary>
    public class AnonymousClassShow
    {
        public static void Show()
        {
            //二、匿名类
            //1、形如new {}，new一个对象，不需要类名称了，NETFramework3.0出现的
            //2、匿名类+object
            //object去接匿名类，无法访问属性值，因为C#是强类型语言，object是在编译时确定类型，因为Object没有这个属性 
            {
                Console.WriteLine("*****************匿名类+object**************");
                object model = new
                {
                    Id = 1,
                    Name = "张三",
                    Age = 30,
                    ClassId = 2
                };
                //无法访问属性值
                //model.Id = 134;
                //Console.WriteLine(model.Id);
                Console.WriteLine("*****************匿名类+object**************");
            }
            //3、匿名类+dynamic
            //dynamic(动态类型)可以避开编译器检查，.NETFramework 4.0出现的
            //dynamic去接匿名类，可以访问属性值，因为dynamic是运行时才检查的，但是访问不存在的属性也不报错，运行时才报异常
            {
                Console.WriteLine("*****************匿名类+dynamic**************");
                dynamic dModel = new
                {
                    Id = 1,
                    Name = "张三",
                    Age = 30,
                    ClassId = 2
                };
                //可以访问属性值
                dModel.Id = 134;
                Console.WriteLine(dModel.Id);
                //但是访问不存在的属性也不报错，运行时才报异常
                dModel.abccc = 1234;
                Console.WriteLine("*****************匿名类+dynamic**************");
            }
            //4、匿名类+var
            //var去接匿名类，可以读取属性，不能给属性重新赋值，只能在初始化的时候给定一个值
            //var是编译器的语法糖，由编译器自动推算类型
            //var声明的变量必须初始化，必须能推算出类型，var aa = null;或者var aa;都是不正确的
            //var缺陷：阅读麻烦，建议能明确类型的还是明确类型，优点：简化代码
            {
                Console.WriteLine("*****************匿名类+var**************");
                var vmodel = new
                {
                    Id = 1,
                    Name = "张三",
                    Age = 30,
                    ClassId = 2
                };
                //不能给属性重新赋值
                //vmodel.Id = 134;
                //可以读取属性
                Console.WriteLine(vmodel.Id);
                Console.WriteLine("*****************匿名类+var**************");
            }
        }
    }
}
