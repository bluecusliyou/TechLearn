using Business.DB.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace MyReflecttion
{
    public class SimpleFactory
    {
        //创建SqlServerHelper的时候，没有出现SqlserverHelper；没有依赖SqlServerHelper
        //依赖的是两个字符串Business.DB.SqlServer.dll + Business.DB.SqlServer.SqlServerHelper，从配置文件读取。
        //去掉个对细节的依赖的：依赖于抽象，不再依赖于细节；依赖倒置原则； 增强代码的稳定性；
        public static IDBHelper CreateInstance()
        {  
            string ReflictionConfig = CustomConfigManager.GetConfig("ReflictionConfig"); 
            //Business.DB.SqlServer.SqlServerHelper,Business.DB.SqlServer.dll 
            string typeName = ReflictionConfig.Split(',')[0];
            string dllName = ReflictionConfig.Split(',')[1];

            //Assembly assembly = Assembly.LoadFrom("Business.DB.SqlServer.dll"); 
            //Type type = assembly.GetType("Business.DB.SqlServer.SqlServerHelper");

            Assembly assembly = Assembly.LoadFrom(dllName); 
            Type type = assembly.GetType(typeName);

            object? oInstance = Activator.CreateInstance(type);
            IDBHelper helper = oInstance as IDBHelper; 
            return helper; 
        }
    }

    public static class CustomConfigManager
    {
        //Core 读取配置文件：appsettings
        //1.Microsoft.Extensions.Configuration；
        //2.Microsoft.Extensions.Configuration.Json 
        public static string GetConfig(string key)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");  //默认读取  当前运行目录
            IConfigurationRoot configuration = builder.Build();
            string configValue = configuration.GetSection(key).Value;
            return configValue;
        }
    }
}
