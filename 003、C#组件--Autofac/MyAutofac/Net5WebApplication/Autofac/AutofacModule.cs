using Autofac;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Module = Autofac.Module;

namespace Net5WebApplication
{
    public class AutofacModule : Module
    {
        /// <summary>
        /// 重写Autofac管道中的Load方法，在这里注入注册的内容
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //注册抽象与实现
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<UserService>().As<IUserService>();

            //注册所有控制器类
            var controllersTypesInAssembly = typeof(Startup).Assembly.GetExportedTypes()
             .Where(type => typeof(ControllerBase).IsAssignableFrom(type)).ToArray();
            //实现属性注入，这边无法实现方法注入
            builder.RegisterTypes(controllersTypesInAssembly).PropertiesAutowired();

            //单抽象多实现注册,名称区分
            builder.RegisterType<TestServiceA>().Named<ITestService>("a");
            builder.RegisterType<TestServiceB>().Named<ITestService>("b");
        }
    }
}
