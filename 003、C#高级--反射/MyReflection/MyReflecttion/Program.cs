using Business.DB.Interface;
using Business.DB.Model;
using Business.DB.SqlServer;
using System;
using System.Reflection;

namespace MyReflecttion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                {
                    //一、什么是反射/反编译
                    //1、C#编译运行过程
                    //高级语言->编译->dll / exe文件->CLR / JIT->机器码
                    //2、原理解析
                    //metadata：元数据数据清单，记录了dll中包含了哪些东西,是一个描述。
                    //IL：中间语言，编译把高级语言编译后得到的C#中最真实的语言状态，面向对象语言。
                    //反射：来自于System.Reflection，是一个帮助类库，可以读取dll/exe中metadata，使用metadata创建对象。
                    //Emit：一种反射技术，可以动态创建dll/exe。
                    //反编译工具：ILSpy可以反编译dll/exe，查看对应的C#/IL代码。
                }
                {
                    ////二、反射创建对象
                    ////传统工艺是直接new对象，使用方法
                    ////IDBHelper dBHelper = new SqlServerHelper();
                    ////IDBHelper dBHelper = new MySqlHelper();
                    ////dBHelper.Query();

                    ////dBHelper.Get(); 
                    ////反射创建对象
                    ////1、动态读取dll
                    ////2、获取某一个具体的类型
                    ////3、创建对象
                    ////4、类型转换
                    ////5、调用方法

                    ////1、动态读取dll的三种方式
                    ////（1）LoadFrom：dll全名称，需要后缀                        
                    //Assembly assembly = Assembly.LoadFrom("Business.DB.SqlServer.dll");
                    ////（2）LoadFile：全路径，需要dll后缀
                    ////Assembly assembly1 = Assembly.LoadFile(@"dll文件全路径");
                    ////（3）Load：dll名称 不需要后缀
                    ////Assembly assembly2 = Assembly.Load("Business.DB.SqlServer");                    

                    ////2、获取某一个具体的类型，参数需要是类的全名称
                    //Type type1 = assembly.GetType("Business.DB.SqlServer.SqlServerHelper");

                    ////3、创建对象
                    ////（1）直接传类型
                    //object? oInstance = Activator.CreateInstance(type1);
                    ////（2）重载方法，传dll的全名称
                    ////object? oInstanc1= Activator.CreateInstance("Business.DB.SqlServer.dll", "Business.DB.SqlServer.SqlServerHelper");
                    ////a.oInstance.Query();//报错了：因为oInstance当做是一个object类型，object类型是没有Query方法；C#语言是一种强类型语言；编译时决定你是什么类型,以左边为准；不能调用是因为编译器不允许；实际类型一定是SqlServerHelper；
                    ////b.如果使用dynamic 作为类型的声明，在调用的时候，没有限制；
                    ////c.dynamic :动态类型：不是编译时决定类型，避开编译器的检查；运行时决定是什么类型
                    ////d.dynamic dInstance = Activator.CreateInstance(type);
                    ////e.dInstance.Query();
                    ////f.dInstance.Get(); //报错了--因为SqlServerHelper没有Get方法

                    ////4、类型转换
                    //// SqlServerHelper helper = (SqlServerHelper)oInstance; //不建议这样转换--如果真实类型不一致--会报报错； 
                    //IDBHelper helper = oInstance as IDBHelper;//如果类型一直，就转换，如果不一致；就返回null

                    ////5、调用方法
                    //helper.Query();
                    ////经过5步骤；千辛万苦--终于调用到了Query方法；
                }

                {
                    ////三、反射创建对象封装
                    ////问题：反射创建对象代码很多。
                    ////其实除了dll的名称和类的全名称都是一样的代码，可以封装反射创建对象帮助类。
                    ////传入的参数都是字符串，考虑做成配置项，提高代码的扩展性和灵活性，可以做到不修改代码而改变程序的功能。
                    //1、反射创建对象封装
                    //创建SqlServerHelper的时候，没有出现SqlserverHelper；没有依赖SqlServerHelper
                    //依赖的是两个字符串Business.DB.SqlServer.dll + Business.DB.SqlServer.SqlServerHelper，从配置文件读取。
                    //去掉个对细节的依赖的：依赖于抽象，不再依赖于细节；依赖倒置原则； 增强代码的稳定性；
                    //2、配置文件
                    //"ReflictionConfig": "Business.DB.Orcale.OrcaleHelper,Business.DB.Orcale.dll"
                    //3、程序调用
                    //（1）传统方式，必须要修改代码，然后必须要重新编译发布，步骤很多
                    //（2）反射实现：断开了对普通类的依赖；依赖于配置文件 + 接口（抽象），做到了程序的可配置
                    //（3）反射实现的步骤：按照接口约定实现一个Mysql帮助类库，Copy dll 文件到执行目录下，修改配置文件
                    //IDBHelper helper1 = SimpleFactory.CreateInstance();
                    //helper1.Query();
                }

                {
                    ////四、反射创建对象之破环单例
                    ////除了反射之外，没有其他的方法来调用私有化构造函数的；私有化的方法就只能从内部访问；元数据中只要有的，反射都可以给找出来； 完全不用关注权限问题；
                    ////1、单例类代码  Singleton
                    //{
                    //    //2、传统手艺创建单例类对象
                    //    Console.WriteLine("********************传统单例***************************");
                    //    Singleton singleton1 = Singleton.GetInstance();
                    //    Singleton singleton2 = Singleton.GetInstance();
                    //    Singleton singleton3 = Singleton.GetInstance();
                    //    Singleton singleton4 = Singleton.GetInstance();
                    //    Console.WriteLine(object.ReferenceEquals(singleton1, singleton2));
                    //    Console.WriteLine(object.ReferenceEquals(singleton2, singleton3));
                    //    Console.WriteLine(object.ReferenceEquals(singleton1, singleton4));
                    //    Console.WriteLine("********************传统单例***************************");
                    //}                    
                    //{
                    //    //3、反射方式创建单例类对象
                    //    Console.WriteLine("********************反射单例***************************");
                    //    Assembly assembly = Assembly.LoadFrom("MyReflecttion.dll");
                    //    Type type = assembly.GetType("MyReflecttion.Singleton");
                    //    Singleton singleton1 = (Singleton)Activator.CreateInstance(type, true);
                    //    Singleton singleton2 = (Singleton)Activator.CreateInstance(type, true);
                    //    Singleton singleton3 = (Singleton)Activator.CreateInstance(type, true);
                    //    Singleton singleton4 = (Singleton)Activator.CreateInstance(type, true);
                    //    Console.WriteLine(object.ReferenceEquals(singleton1, singleton2));
                    //    Console.WriteLine(object.ReferenceEquals(singleton2, singleton3));
                    //    Console.WriteLine(object.ReferenceEquals(singleton1, singleton4));
                    //    Console.WriteLine("********************反射单例***************************");
                    //}
                }
                {
                    ////五、反射创建对象详解
                    ////1、创建测试类  ReflectionTest
                    ////2、创建对象
                    ////（1）调用无参数构造函数的
                    //{
                    //    Assembly assembly = Assembly.LoadFrom("MyReflecttion.dll");
                    //    Type type = assembly.GetType("MyReflecttion.ReflectionTest");
                    //    object noParaObject = Activator.CreateInstance(type);
                    //}
                    ////（2）调用有参数构造函数的
                    ////需要传递一个object类型的数组作为参数，参数按照从昨往右严格匹配，如果没有匹配的报异常
                    //{
                    //    Assembly assembly = Assembly.LoadFrom("MyReflecttion.dll");
                    //    Type type = assembly.GetType("MyReflecttion.ReflectionTest");
                    //    object paraObject = Activator.CreateInstance(type, new object[] { 123 });
                    //    object paraObject1 = Activator.CreateInstance(type, new object[] { "三三" });
                    //    object paraObject2 = Activator.CreateInstance(type, new object[] { 234, "四四" });
                    //    object paraObject3 = Activator.CreateInstance(type, new object[] { "五五", 456 });
                    //}
                }

                {
                    ////六、反射调用方法详解
                    ////获取方法MethodInfo,执行MethodInfo的Invoke方法，传递方法所在的类的实例对象+参数
                    //{
                    //    //1、调用无参数的方法
                    //    Assembly assembly = Assembly.LoadFrom("MyReflecttion.dll");
                    //    Type type = assembly.GetType("MyReflecttion.ReflectionTest");
                    //    object oInstance = Activator.CreateInstance(type);
                    //    MethodInfo show1 = type.GetMethod("Show1");
                    //    show1.Invoke(oInstance, new object[] { });
                    //    show1.Invoke(oInstance, new object[0]);
                    //    show1.Invoke(oInstance, null);
                    //}

                    //{
                    //    //2、调用有参数的方法
                    //    //需要通过方法参数类型类区别方法，传递参数，严格匹配参数类型
                    //    Assembly assembly = Assembly.LoadFrom("MyReflecttion.dll");
                    //    Type type = assembly.GetType("MyReflecttion.ReflectionTest");
                    //    object oInstance = Activator.CreateInstance(type);
                    //    MethodInfo show2 = type.GetMethod("Show2");
                    //    show2.Invoke(oInstance, new object[] { 123 });
                    //    MethodInfo show31 = type.GetMethod("Show3", new Type[] { typeof(string), typeof(int) });
                    //    show31.Invoke(oInstance, new object[] { "一一一", 234 });
                    //    MethodInfo show32 = type.GetMethod("Show3", new Type[] { typeof(int) });
                    //    show32.Invoke(oInstance, new object[] { 345 });
                    //    MethodInfo show33 = type.GetMethod("Show3", new Type[] { typeof(string) });
                    //    show33.Invoke(oInstance, new object[] { "二二二" });
                    //    MethodInfo show34 = type.GetMethod("Show3", new Type[0]);
                    //    show34.Invoke(oInstance, null);
                    //}

                    //{
                    //    //3、调用私有方法
                    //    //在获取方法的时候，加上参数BindingFlags.NonPublic | BindingFlags.Instance
                    //    Assembly assembly = Assembly.LoadFrom("MyReflecttion.dll");
                    //    Type type = assembly.GetType("MyReflecttion.ReflectionTest");
                    //    object oInstance = Activator.CreateInstance(type);
                    //    MethodInfo show4 = type.GetMethod("Show4", BindingFlags.NonPublic | BindingFlags.Instance);
                    //    show4.Invoke(oInstance, new object[] { "String" });
                    //}

                    //{
                    //    //4、调用静态方法
                    //    //不需要创建对象也可以调用
                    //    Assembly assembly = Assembly.LoadFrom("MyReflecttion.dll");
                    //    Type type = assembly.GetType("MyReflecttion.ReflectionTest");
                    //    MethodInfo show5 = type.GetMethod("Show5");
                    //    show5.Invoke(null, new object[] { "String" });
                    //}

                    //{
                    //    //5、调用普通类的泛型方法
                    //    Assembly assembly = Assembly.LoadFrom("MyReflecttion.dll");
                    //    Type type = assembly.GetType("MyReflecttion.GenericMethod");
                    //    object oInstance = Activator.CreateInstance(type);
                    //    MethodInfo show = type.GetMethod("Show");
                    //    //获取到泛型方法后需要先确定类型
                    //    MethodInfo genericshow = show.MakeGenericMethod(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                    //    genericshow.Invoke(oInstance, new object[] { 123, "三三三", DateTime.Now });
                    //}

                    //{
                    //    //6、调用泛型类的普通方法
                    //    Assembly assembly = Assembly.LoadFrom("MyReflecttion.dll");
                    //    //泛型类的类型需要在类后面加占位符
                    //    Type type = assembly.GetType("MyReflecttion.GenericClass`3");
                    //    //泛型类获取到类型后需要先确定类型
                    //    Type generType = type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                    //    object oInstance = Activator.CreateInstance(generType);
                    //    MethodInfo show = generType.GetMethod("Show");
                    //    show.Invoke(oInstance, new object[] { 123, "四四四", DateTime.Now });
                    //}

                    //{
                    //    //7、调用泛型类的泛型方法
                    //    Assembly assembly = Assembly.LoadFrom("MyReflecttion.dll");
                    //    //泛型类的类型需要在类后面加占位符
                    //    Type type = assembly.GetType("MyReflecttion.GenericDouble`1");
                    //    //泛型类获取到类型后需要先确定类型
                    //    Type generType = type.MakeGenericType(new Type[] { typeof(int) });
                    //    object oInstance = Activator.CreateInstance(generType);
                    //    MethodInfo show = generType.GetMethod("Show");
                    //    //获取到泛型方法后需要先确定类型
                    //    MethodInfo genericMethod = show.MakeGenericMethod(new Type[] { typeof(string), typeof(DateTime) });
                    //    genericMethod.Invoke(oInstance, new object[] { 123, "五五五", DateTime.Now });
                    //}
                }

                {
                    ////七、反射操作属性字段
                    ////普通方法调用属性字段简单快捷，反射操作麻烦点。
                    ////类增加一个字段呢，普通方法调用需要修改代码，重新编译发布，代码不稳定，反射赋值没啥优势，反射取值不需要修改代码，代码就更加稳定。
                    ////type.GetProperties()获取属性，type.GetFields()获取字段。
                    ////1、创建测试类  People
                    ////2、传统手艺赋值取值
                    //{
                    //    
                    //    Console.WriteLine("***********传统手艺赋值取值*************");
                    //    People people = new People();
                    //    people.Id = 134;
                    //    people.Name = "WWWW";
                    //    people.Age = 25;
                    //    people.Description = "XXX";
                    //    Console.WriteLine($"people.Id={people.Id}");
                    //    Console.WriteLine($"people.Name={people.Name}");
                    //    Console.WriteLine($"people.Age={people.Age}");
                    //    Console.WriteLine($"people.Description={people.Description}");
                    //}
                    ////3、反射方式赋值取值
                    //{
                    //    Console.WriteLine("***********反射方式赋值取值*************");
                    //    Type type = typeof(People);
                    //    object pObject = Activator.CreateInstance(type);
                    //    foreach (var prop in type.GetProperties())
                    //    {
                    //        if (prop.Name.Equals("Id"))
                    //        {
                    //            prop.SetValue(pObject, 134);
                    //        }
                    //        else if (prop.Name.Equals("Name"))
                    //        {
                    //            prop.SetValue(pObject, "WWWW");
                    //        }
                    //        else if (prop.Name.Equals("Age"))
                    //        {
                    //            prop.SetValue(pObject, 25);
                    //        }                            
                    //    }                        
                    //    foreach (var prop in type.GetProperties())
                    //    {
                    //        Console.WriteLine($"people.{prop.Name}={prop.GetValue(pObject)}");
                    //    }
                    //}
                }

                {
                    ////八、反射的局限/性能问题
                    ////1、测试用例：普通方式循环100000次，创建对象+方法调用：17毫秒
                    ////             反射方式循环100000次，加载dll+创建对象+方法调用：6300毫秒
                    ////2、加载dll放到循环外面，创建对象+方法调用放循环里面，泛型方法：60毫秒
                    ////3、使用反射的建议：1.反射确实有性能问题，但是差别没有那么大，在需要的地方可以放心使用
                    //Monitor.Show();
                }

                {
                    ////九、反射实现ORM框架
                    ////ORM：对象关系映射，通过对象查询数据库数据
                    ////1、创建测试类，继承基类  SysCompany : BaseModel
                    ////2、使用泛型方法来兼容不同的对象查询
                    ////3、使用反射获取字段
                    ////4、使用反射来对结果赋值
                    ////5、使用泛型缓存来缓存sql
                    ////6、反射多种应用场景
                    ////（1）IOC容器：反射+ 配置文件+ 工厂
                    ////（2）MVC框架：反射调用类型方法
                    ////（3）ORM：反射+泛型+Ado.Net
                    ////（4）AOP：在方法的前面后面添加处理内容
                    //SqlServerHelper sqlServer = new SqlServerHelper();
                    //SysCompany sysCompany = sqlServer.Find<SysCompany>(1);
                }

                {
                    //十、Emit技术
                    //在运行时去动态的生成dll、exe包括dll内部的方法、属性、字段等内容
                    //偏向于底层，学习成本比较高 除非是非常复杂的业务逻辑，一般情况，用的比较少；
                    ReflectionEmit.Show();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
