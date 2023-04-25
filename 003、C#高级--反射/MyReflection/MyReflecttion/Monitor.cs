using Business.DB.Interface;
using Business.DB.SqlServer;
using System;
using System.Diagnostics;
using System.Reflection;

namespace MyReflecttion
{
    public class Monitor
    {
        public static void Show()
        {
            Console.WriteLine("*******************Monitor*******************");
            long commonTime = 0;
            long reflectionTime = 0;
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1000_000; i++) //1000000000
                {
                    IDBHelper iDBHelper = new SqlServerHelper();
                    iDBHelper.Query();
                }
                watch.Stop();
                commonTime = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                //优化代码，加载dll放到循环外面
                Assembly assembly = Assembly.Load("Business.DB.SqlServer");//1 动态加载
                Type dbHelperType = assembly.GetType("Business.DB.SqlServer.SqlServerHelper");//2 获取类型
                for (int i = 0; i < 1000_000; i++)
                {
                    //创建对象+方法调用
                    object oDBHelper = Activator.CreateInstance(dbHelperType);//3 创建对象
                    IDBHelper dbHelper = (IDBHelper)oDBHelper;//4 接口强制转换
                    dbHelper.Query();//5 方法调用
                }
                watch.Stop();
                reflectionTime = watch.ElapsedMilliseconds;
            }

            Console.WriteLine($"commonTime={commonTime} reflectionTime={reflectionTime}");
        }
    }
}
