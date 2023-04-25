using Autofac;
using Autofac.Configuration;
using Autofac.Extras.DynamicProxy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;
using System.Reflection;

namespace MyAutofac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                //1、概述
                //- Autofac是第三方IOC容器，是当前最流行的IOC容器。
                //-功能强大，比asp.netcore内置容器强大得多，支持属性注入和方法注入，支持AOP。
                //-官网地址：http://autofac.org/
                //-源码下载地址：https://github.com/autofac/Autofac
            }

            {
                //2、快速开始
                //（1）Nuget引入程序 Autofac
                //（2）定义抽象和实现
                //（3）创建容器，注册抽象与实现，容器创建对象
                {
                    ////创建一个容器建造者
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    ////注册普通各类
                    //containerBuilder.RegisterType<Honer>();
                    ////build一下，得到一个容器
                    //IContainer container = containerBuilder.Build();
                    ////基于容器来获取对象的实例
                    //Honer phone = container.Resolve<Honer>();
                }
            }

            {
                //3、多种注册类型
                {
                    ////(1)注册普通类
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<Honer>();
                    //IContainer container = containerBuilder.Build();
                    //Honer phone = container.Resolve<Honer>();
                }
                {
                    ////(2)注册抽象与实现
                    ////ContainerBuilder containerBuilder = new ContainerBuilder();
                    ////containerBuilder.RegisterType<Honer>().As<IPhone>();
                    ////IContainer container = containerBuilder.Build();
                    ////IPhone phone = container.Resolve<IPhone>();
                }
                {
                    ////(3)注册程序集
                    ////RegisterAssemblyTypes(程序集数组)，程序集必须是public的
                    ////AsImplementedInterfaces()：表示注册的类型，以接口的方式注册
                    ////PropertiesAutowired()：支持属性注入
                    ////Where：满足条件类型注册
                    //{
                    //    var basePath = AppContext.BaseDirectory;
                    //    var dll = Path.Combine(basePath, "MyAutofac.dll");
                    //    ContainerBuilder containerBuilder = new ContainerBuilder();
                    //    var assemblysServices = Assembly.LoadFrom(dll);
                    //    containerBuilder.RegisterAssemblyTypes(assemblysServices)
                    //        .Where(t => !t.Name.EndsWith("XXX"))
                    //        .AsImplementedInterfaces()
                    //        .PropertiesAutowired();                        
                    //    IContainer container = containerBuilder.Build();
                    //    ITeacher teacher = container.Resolve<ITeacher>();
                    //}
                }
            }

            {
                //4、三种注入方式
                //（1）构造函数注入
                //默认支持，无法用特性进行筛选，默认选参数最多的构造函数进行注入
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<Honer>().As<IPhone>();
                    //containerBuilder.RegisterType<Teacher>().As<ITeacher>();
                    //containerBuilder.RegisterType<Student>().As<IStudent>();
                    //IContainer container = containerBuilder.Build();
                    //ITeacher teacher = container.Resolve<ITeacher>();
                }
                //（2）全部属性注入
                //关键词PropertiesAutowired，这个对象所有属性全部注入
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<Honer>().As<IPhone>();
                    //containerBuilder.RegisterType<Teacher>().As<ITeacher>().PropertiesAutowired();
                    //containerBuilder.RegisterType<Student>().As<IStudent>();
                    //IContainer container = containerBuilder.Build();
                    //ITeacher teacher = container.Resolve<ITeacher>();
                }
                //（3）标记特性的属性注入
                //关键词PropertiesAutowired，定义特性选择器CustomPropertySelector
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<Honer>().As<IPhone>();
                    //containerBuilder.RegisterType<Teacher>().As<ITeacher>().PropertiesAutowired(new CustomPropertySelector());
                    //containerBuilder.RegisterType<Student>().As<IStudent>();
                    //IContainer container = containerBuilder.Build();
                    //ITeacher teacher = container.Resolve<ITeacher>();
                }
                //（4）方法注入
                //关键词OnActivated，指定调用方法
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<Honer>().As<IPhone>();
                    //containerBuilder.RegisterType<Teacher>().As<ITeacher>()
                    //    .OnActivated(p =>
                    //    {
                    //        p.Instance.SetStudent1(p.Context.Resolve<IStudent>());
                    //    });
                    //containerBuilder.RegisterType<Student>().As<IStudent>();
                    //IContainer container = containerBuilder.Build();
                    //ITeacher teacher = container.Resolve<ITeacher>();
                }
            }

            {
                //5、对象生命周期
                //（1）瞬时生命周期
                //每次获取都是全新的实例，关键词InstancePerDependency，默认的生命周期
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<Honer>().As<IPhone>().InstancePerDependency();
                    //IContainer container = containerBuilder.Build();
                    //IPhone phone1 = container.Resolve<IPhone>();
                    //IPhone phone2 = container.Resolve<IPhone>();
                    //bool isflg1 = object.ReferenceEquals(phone1, phone2);
                    //Console.WriteLine($"InstancePerDependency：phone1==phone2=>{isflg1}");
                }
                //（2）单例生命周期
                //同一个进程内都是同一个实例，关键词SingleInstance
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<Honer>().As<IPhone>().SingleInstance();
                    //IContainer container = containerBuilder.Build();
                    //IPhone phone1 = container.Resolve<IPhone>();
                    //IPhone phone2 = container.Resolve<IPhone>();
                    //bool isflg1 = object.ReferenceEquals(phone1, phone2);
                    //Console.WriteLine($"SingleInstance：phone1==phone2=>{isflg1}");
                    //using (var scope = container.BeginLifetimeScope())
                    //{
                    //    IPhone phone3 = scope.Resolve<IPhone>();
                    //    IPhone phone4 = scope.Resolve<IPhone>();
                    //    bool isflg2 = object.ReferenceEquals(phone3, phone4);
                    //    Console.WriteLine($"SingleInstance：phone3==phone4=>{isflg2}");
                    //    bool isflg3 = object.ReferenceEquals(phone1, phone3);
                    //    Console.WriteLine($"SingleInstance：phone1==phone3=>{isflg3}");
                    //}
                }
                //（3）作用域生命周期
                //同一个作用域内都是同一个实例，关键词InstancePerLifetimeScope
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<Honer>().As<IPhone>().InstancePerLifetimeScope();
                    //IContainer container = containerBuilder.Build();
                    //IPhone phone1 = container.Resolve<IPhone>();
                    //IPhone phone2 = container.Resolve<IPhone>();
                    //bool isflg1 = object.ReferenceEquals(phone1, phone2);
                    //Console.WriteLine($"InstancePerLifetimeScope：phone1==phone2=>{isflg1}");
                    //IPhone phone3 = null;
                    //IPhone phone4 = null;
                    //using (var scope = container.BeginLifetimeScope())
                    //{
                    //    phone3 = scope.Resolve<IPhone>();
                    //    phone4 = scope.Resolve<IPhone>();
                    //    bool isflg2 = object.ReferenceEquals(phone3, phone4);
                    //    Console.WriteLine($"InstancePerLifetimeScope：phone3==phone4=>{isflg2}");
                    //    bool isflg3 = object.ReferenceEquals(phone1, phone3);
                    //    Console.WriteLine($"InstancePerLifetimeScope：phone1==phone3=>{isflg3}");
                    //}
                    //IPhone phone5 = null;
                    //IPhone phone6 = null;
                    //using (var scope = container.BeginLifetimeScope())
                    //{
                    //    phone5 = scope.Resolve<IPhone>();
                    //    phone6 = scope.Resolve<IPhone>();
                    //    bool isflg2 = object.ReferenceEquals(phone5, phone6);
                    //    Console.WriteLine($"InstancePerLifetimeScope：phone5==phone6=>{isflg2}");
                    //    bool isflg3 = object.ReferenceEquals(phone1, phone5);
                    //    Console.WriteLine($"InstancePerLifetimeScope：phone1==phone5=>{isflg3}");
                    //}
                    //bool isflg4 = object.ReferenceEquals(phone3, phone5);
                    //Console.WriteLine($"InstancePerLifetimeScope：phone3==phone5=>{isflg4}");
                }
                //（4）作用域范围生命周期
                //在作用域范围外无法创建实例，在作用域范围里面，同一个作用域下面的对象是同一个，关键词InstancePerMatchingLifetimeScope
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<Honer>().As<IPhone>().InstancePerMatchingLifetimeScope("scope1", "scope2");
                    //IContainer container = containerBuilder.Build();
                    //IPhone phone1 = null;
                    //IPhone phone2 = null;
                    //using (var scope = container.BeginLifetimeScope("scope1"))
                    //{
                    //    phone1 = scope.Resolve<IPhone>();
                    //    phone2 = scope.Resolve<IPhone>();
                    //    bool isflg1 = object.ReferenceEquals(phone1, phone2);
                    //    Console.WriteLine($"InstancePerMatchingLifetimeScope：phone1==phone2=>{isflg1}");
                    //}
                    //IPhone phone3 = null;
                    //using (var scope = container.BeginLifetimeScope("scope2"))
                    //{
                    //    phone3 = scope.Resolve<IPhone>();
                    //}                   
                    //IPhone phone4 = null;
                    //using (var scope = container.BeginLifetimeScope("scope2"))
                    //{                        
                    //    phone4 = scope.Resolve<IPhone>();
                    //}
                    //bool isflg2 = object.ReferenceEquals(phone3, phone4);
                    //Console.WriteLine($"InstancePerMatchingLifetimeScope：phone3==phone4=>{isflg2}");
                    //bool isflg3 = object.ReferenceEquals(phone1, phone3);
                    //Console.WriteLine($"InstancePerMatchingLifetimeScope：phone1==phone3=>{isflg3}");
                }
                //（5）一次请求同一个对象
                //关键词InstancePerRequest，只能在web项目中调试，控制台报错
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //containerBuilder.RegisterType<Honer>().As<IPhone>().InstancePerRequest();
                    //IContainer container = containerBuilder.Build();
                    //IPhone phone1 = container.Resolve<IPhone>();
                    //IPhone phone2 = container.Resolve<IPhone>();
                    //bool isflg1 = object.ReferenceEquals(phone1, phone2);
                    //Console.WriteLine($"InstancePerRequest：phone1==phone2=>{isflg1}");
                }
            }

            {
                //6、支持配置文件注册
                //(1)nuget引入程序集
                //Autofac
                //Autofac.Configuration
                //Microsoft.Extensions.Configuration.Json
                //（2）配置文件autofac.json，属性->始终复制
                //（3）通过配置文件注册创建对象
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();
                    //IConfigurationBuilder config = new ConfigurationBuilder();
                    //IConfigurationSource autofacJsonConfigSource = new JsonConfigurationSource()
                    //{
                    //    Path = "Autofac/autofac.json",
                    //    Optional = false,//boolean,默认就是false,可不写
                    //    ReloadOnChange = true,//同上
                    //};
                    //config.Add(autofacJsonConfigSource);
                    //ConfigurationModule module = new ConfigurationModule(config.Build());
                    //containerBuilder.RegisterModule(module);
                    //IContainer container = containerBuilder.Build();
                    //IPhone phone1 = container.Resolve<IPhone>();
                    //IPhone phone2 = container.Resolve<IPhone>();
                    //bool isflg1 = object.ReferenceEquals(phone1, phone2);
                    //Console.WriteLine($"配置文件注册：phone1==phone2=>{isflg1}");
                }
            }
            {
                //7、支持面向切面编程
                //可以在不修改方法的前提下，在方法前后添加公共逻辑，日志、缓存等
                //（1）nuget引入程序集
                //Castle.Core
                //Autofac.Extras.DynamicProxy
                //（2）自定义一个切面类CustomInterceptor，实现IInterceptor
                //（3）在抽象/实现类上添加特性标记[Intercept(typeof(CustomInterceptor))]
                //（4）在容器中注册关系创建对象
                //EnableInterfaceInterceptors + 特性标记在抽象上，所有实现类都支持AOP
                //EnableInterfaceInterceptors + 特性标记到实现类上，标记的类就支持AOP
                //EnableClassInterceptors，要支持AOP的方法必须要是用virtual虚方法
                //EnableClassInterceptors + 特性标记在抽象上，所有实现类都支持AOP
                //EnableClassInterceptors + 特性标记到实现类上，标记的类就支持AOP
                {
                    //ContainerBuilder containerBuilder = new ContainerBuilder();                   
                    ////containerBuilder.RegisterType<Honer>().As<IPhone>().EnableInterfaceInterceptors();
                    //containerBuilder.RegisterType<Honer>().As<IPhone>().EnableClassInterceptors();
                    //containerBuilder.RegisterType(typeof(CustomInterceptor));
                    //IContainer container = containerBuilder.Build();
                    //IPhone phone = container.Resolve<IPhone>();
                    //phone.ShowName();
                }
            }
            {
                //8、单抽象多实现问题
                //注册的时候不标记名字，后注册的会覆盖先注册的
                //注册的时候标记下名字，创建对象的时候用名称来区分
                {
                    ContainerBuilder containerBuilder = new ContainerBuilder();
                    containerBuilder.RegisterType<Honer>().Named<IPhone>("Honer");
                    containerBuilder.RegisterType<Huawei>().Named<IPhone>("Huawei");
                    IContainer container = containerBuilder.Build();
                    IPhone honer = container.ResolveNamed<IPhone>("Honer");
                    IPhone huawei = container.ResolveNamed<IPhone>("Huawei");
                    honer.ShowName();
                    huawei.ShowName();
                }
            }
        }
    }
}
