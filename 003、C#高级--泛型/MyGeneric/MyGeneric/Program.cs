using System;

namespace MyGeneric
{
    /// <summary>
    /// 1 泛型是什么
    /// 2 为什么使用泛型
    /// 3 泛型运行原理
    /// 4 泛型应用范围
    /// 5 泛型约束
    /// 6 泛型的协变和逆变
    /// 7 泛型缓存
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //int iValue = 123;
                //string sValue = "456";
                //DateTime dtValue = DateTime.Now;
                //object oValue = "678";

                //Console.WriteLine("***********************Common***********************");
                //CommonMethod.ShowInt(iValue);
                //CommonMethod.ShowString(sValue);
                //CommonMethod.ShowDateTime(dtValue);

                //Console.WriteLine("***********************Object***********************");
                //CommonMethod.ShowObject(oValue);
                //CommonMethod.ShowObject(iValue);
                //CommonMethod.ShowObject(sValue);
                //CommonMethod.ShowObject(dtValue);

                //Console.WriteLine("***********************Generic***********************");
                //GenericMethod.Show<int>(iValue);//调用泛型，需要指定类型参数
                //GenericMethod.Show(iValue);//如果可以从参数类型推断，可以省略类型参数---语法糖(编译器提供的功能)
                //GenericMethod.Show<string>(sValue);
                ////GenericMethod.Show<int>(sValue);//类型错了
                //GenericMethod.Show<DateTime>(dtValue);
                //GenericMethod.Show<object>(oValue);

                //泛型原理
                //Console.WriteLine(typeof(List<>));
                //Console.WriteLine(typeof(Dictionary<,>));

                //泛型性能测试
                //Monitor.Show();

                //哪里用泛型？ 泛型到底是干嘛的？
                //泛型方法：为了一个方法满足不同的类型的需求
                //泛型类：一个类，满足不同类型的需求  List Dictionary
                //泛型接口：一个接口，满足不同类型的需求
                //泛型委托：一个委托，满足不同类型的需求
                //泛型类
                //// T是int类型
                //GenericClass<int> genericInt = new GenericClass<int>();
                //genericInt._T = 123;
                //// T是string类型
                //GenericClass<string> genericString = new GenericClass<string>();
                //genericString._T = "123";

                //People people = new People()
                //{
                //    Id = 123,
                //    Name = "Jon"
                //};
                //Chinese chinese = new Chinese()
                //{
                //    Id = 234,
                //    Name = "一生为你"
                //};
                //Hubei hubei = new Hubei()
                //{
                //    Id = 345,
                //    Name = "木头"
                //};
                //Japanese japanese = new Japanese()
                //{
                //    Id = 456,
                //    Name = "苍老师"
                //};

                //GenericConstraint.ShowObject(people);
                //GenericConstraint.ShowObject(chinese);
                //GenericConstraint.ShowObject(hubei);
                ////没有约束，任何类型都能传递进来，所以可能不安全
                //GenericConstraint.ShowObject(japanese);

                //GenericConstraint.ShowP<People>(people);
                //GenericConstraint.ShowP<Chinese>(chinese);
                //GenericConstraint.ShowP<Hubei>(hubei);
                ////japanese不是people或者people的子类，所以编译直接报错
                ////GenericConstraint.ShowP<Japanese>(japanese);

                //创建对象,逆变，协变
                //GenericCCTest.Show();

                {
                    //泛型缓存
                    Console.WriteLine("*******************GenericCache********************");
                    GenericCacheTest.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
